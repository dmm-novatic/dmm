
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Models.CRM;
using Novatic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novatic.Util;
using Novatic.Models.CRM.RequestForm;
using A2F.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : BaseController
    {
        ITransactionsRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IShopRepository shopRepository;
        IOrdersRepository ordersRepository;
        IOrderItemRepository orderItemRepository;
        IProductItemRepository productItemRepository;
        IOrderTransactionRepository ordersTransactionRepository;
        INotificationRepository notificationRepository;

        public TransactionsController(ITransactionsRepository _repository, IOrderTransactionRepository _orderTransactionRepository, IShopRepository _shopRepository, IOrderItemRepository _orderItemRepository, IOrdersRepository _ordersRepository, IProductItemRepository _productItemRepository,INotificationRepository _notificationRepository ,ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper) : base(cacheHelper)
        {

            repository = _repository;
            ordersTransactionRepository = _orderTransactionRepository;
            shopRepository = _shopRepository;
            ordersRepository = _ordersRepository;
            orderItemRepository = _orderItemRepository;
            productItemRepository = _productItemRepository;
            notificationRepository = _notificationRepository;
            repositorySystemConfig = _repositorySystemConfig;
        }


        [HttpGet]
        [Route("admin/List")]
        public async Task<IActionResult> AdminList()
        {
            try
            {
                var dataList = await repository.List();

                if (dataList == null || dataList.Count == 0)
                {
                    //return NotFound();
                }


                ViewBag.entities = dataList;
                return View(dataList);

                //var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                ////var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                //return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/List")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> List()
        {
            try
            {
                int AccountId = 0;
                int AccountTypeId = 0;
                string UserIdSessionString = this.GetLoggedInUserId().ToString();
                string AccountTypeIdString = this.GetLoggedInAccountTypeId().ToString();
                AccountId = Convert.ToInt32(UserIdSessionString);
                AccountTypeId = Convert.ToInt32(AccountTypeIdString);
                //get ShopData if account is shop Manager, otherwise this is systemAdmin
                var dataShop = await shopRepository.DetailByAccountId(AccountId);
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER && (dataShop == null || dataShop.Count == 0))
                {
                    //Shop data not found
                    return NotFound();
                }
                int shopId = dataShop[0].Id;

                var dataList = new List<Transactions>();
                //Case 1/2 systemAdmin
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SYSTEM_ADMIN)
                {
                    dataList = await repository.List();
                }
                //Case 2/2 shopManager
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER)
                {
                    //filer data
                    //var dataListTotal = await repository.List();
                    //var dataOrder = await ordersRepository.ListByShopId(shopId);
                    //var dataOrderTransaction = await ordersTransactionRepository.List();

                    //dataList = dataListTotal.Where( t => dataOrderTransaction.Any( ot => ot.TransactionId == t.Id 
                    //&& dataOrder.Any(o => o.Id == ot.OrderId && o.ShopId == shopId) ) ).ToList();
                    dataList = await repository.ListByShopId(shopId);

                }
                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/Detail/{Id}")]
        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var dataList = await repository.Detail(Id);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/Search")]
        public async Task<IActionResult> Search(string keyword)
        {
            try
            {
                var dataList = await repository.Search(keyword);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/ListPaging")]
        public async Task<IActionResult> ListPaging(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.ListPaging(pageIndex, pageSize);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpPost]
        [Route("api/Add")]
        public async Task<IActionResult> Add([FromBody] List<TransactionsRequestForm> request)
        {
            List<Transactions> Transactions = new List<Transactions>();
            if (ModelState.IsValid)
            {
                //1. business logic

                foreach (TransactionsRequestForm model in request)
                {      //data validation
                    Transactions transactions = new Transactions();
                    if (model.Name.Length == 0)
                    {
                        return BadRequest();
                    }

                    //auto correct
                    transactions.Active = 1;
                    transactions.Name = model.Name;
                    transactions.TransactionStatusId = 1000002;
                    transactions.TransactionTypeId = 1000001;
                    transactions.Description = model.Description;
                    transactions.Info = model.Info;
                    transactions.ReceiverInfo = model.ReceiverInfor;
                    transactions.CreatedTime = DateTime.Now;
                    Orders orders = ordersRepository.GetORdersByOrderId(model.OrderId);
                    if (orders != null)
                    {

                        Shop shop = shopRepository.GetShopbyID(orders.ShopId);
                        transactions.SenderInfo = shop.Name;
                        transactions.Amount = orders.TotalPrice;


                    }
                    else
                    {
                        var novaticResponse1 = NovaticResponse.NotFoundMesage("Not found Order");
                        return Ok(novaticResponse1);
                    }
                    //2. add new object
                    try
                    {
                        var newObj = await repository.Add(transactions);
                        Transactions.Add(transactions);
                        if (newObj.Id > 0)
                        {
                            OrderTransaction transaction = new OrderTransaction();
                            transaction.TransactionId = newObj.Id;
                            transaction.OrderId = model.OrderId;
                            transaction.Name = model.Name;
                            transaction.Description = model.Description;
                            transaction.Active = 1;
                            transaction.CreatedTime = DateTime.Now;
                            await ordersTransactionRepository.Add(transaction);

                        }

                        else
                        {
                            return NotFound();
                        }
                    }
                    catch (Exception e)
                    {

                        return BadRequest(e.Message + " - " + e.InnerException);
                    }

                }
                var novaticResponse = NovaticResponse.SUCCESS(Transactions);
                return Ok(novaticResponse);
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody] Transactions model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 


                    //2. update object
                    await repository.Update(model);

                    var novaticResponse = NovaticResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/Delete")]
        public async Task<IActionResult> Delete([FromBody] Transactions model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic
                    //set Active to 0
                    model.Active = 0;

                    //2. logically delete object
                    await repository.Delete(model);

                    var novaticResponse = NovaticResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/DeletePermanently")]
        public async Task<IActionResult> DeletePermanently([FromBody] Transactions model)
        {
            int result = 0;

            if (!(model.Id > 0))
            {
                return BadRequest();
            }

            try
            {
                //physically delete object
                result = await repository.DeletePermanently(model.Id);
                if (result == 0)
                {
                    return NotFound();
                }
                var novaticResponse = NovaticResponse.SUCCESS(model);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/Count")]
        public int CountTransactions()
        {
            int result = repository.CountTransactions();
            return result;
        }

        [HttpPost]
        [Route("api/AcceptOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> acceptOrder([FromBody] Orders Order)
        {


            if (ModelState.IsValid)
            {
                // Defind
                Orders request = ordersRepository.GetORdersByOrderId(Order.Id);
                Transactions transactions = repository.GetById(ordersTransactionRepository.GetByOrderId(Order.Id).TransactionId);
                if (request == null || transactions == null)
                {
                    var novaticResponse = NovaticResponse.NotFoundMesage("not found datata");
                    return Ok(novaticResponse);
                }
                ProductItem productItem = new ProductItem();
                //0.Auto Fix for Order
                request.OrderStatusId = 1000005;
                request.OrderPaymentStatusId = 1000001;
                //Auto fix for Transaction
                transactions.TransactionStatusId = 1000001;
                Notification notification = new Notification();
                notification.Active = 1;
                notification.Description = "Thank you my customer";
                notification.CreatedTime = DateTime.Now;
                notification.AccountId = Order.AccountId;
                notification.SenderId = Order.ShopId;
                notification.Name = Order.Name;
                notification.NotificationStatusId = 1000002;

                //2. add new object
                try
                {
                    await repository.Update(transactions);
                    await ordersRepository.Update(request);
                    await notificationRepository.Add(notification);
                    var dataList = await orderItemRepository.ListByOrderId(Order.Id);

                    foreach (var x in dataList)
                    {
                        productItem = productItemRepository.GetById(x.ProductItemId);
                        if (productItem.Quantity > x.Quantity)
                        {
                            productItem.Quantity -= x.Quantity;
                        }
                        else
                        {
                            var novaticResponse1 = NovaticResponse.NotFoundMesage("Over Quantity");
                            return Ok(novaticResponse1);

                        }

                        await productItemRepository.Update(productItem);

                    }
                    var novaticResponse = NovaticResponse.SUCCESS("Accpet Order successfully");
                    return Ok(novaticResponse);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message + " - " + e.InnerException);
                }

            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/CancelOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CancelOrder([FromBody] Orders Order)
        {


            if (ModelState.IsValid)
            {
                // Defind
                Orders request = ordersRepository.GetORdersByOrderId(Order.Id);
                OrderTransaction orderTransaction = ordersTransactionRepository.GetByOrderId(Order.Id);
                Transactions transactions = repository.GetById(orderTransaction.TransactionId);
                if (request == null || transactions == null || orderTransaction == null)
                {
                    var novaticResponse = NovaticResponse.NotFoundMesage("not found datata");
                    return Ok(novaticResponse);
                }

                //Auto fix for Transaction
                transactions.Active = 0;
                orderTransaction.Active = 0;
                request.Active = 0;

                //auto set notification
                Notification notification = new Notification();
                notification.Active = 1;
                notification.Description = "your order Was be cancel";
                notification.CreatedTime = DateTime.Now;
                notification.AccountId = Order.AccountId;
                notification.SenderId = Order.ShopId;
                notification.Name = Order.Name;
                notification.NotificationStatusId = 1000002;
                
                //2. add new object
                try
                {


                    var dataList = await orderItemRepository.ListByOrderId(Order.Id);
                    ProductItem productItem = new ProductItem();
                    foreach (var x in dataList)
                    {
                        productItem = productItemRepository.GetById(x.ProductItemId);

                        productItem.Quantity += x.Quantity;
                        await productItemRepository.Update(productItem);

                    }
                    await repository.Delete(transactions);
                    await ordersTransactionRepository.Delete(orderTransaction);
                    await ordersRepository.Delete(request);
                    await notificationRepository.Add(notification);
                    var novaticResponse = NovaticResponse.SUCCESS("Cancel Order successfully");
                    return Ok(novaticResponse);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message + " - " + e.InnerException);
                }

            }
            return BadRequest();
        }
    }

}

