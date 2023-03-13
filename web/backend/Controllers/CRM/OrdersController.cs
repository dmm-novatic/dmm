
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Novatic.ViewModel;
using A2F.Util;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        IOrdersRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IOrderItemRepository orderItemrepository;
        ICartRepository cartRepository;
        IProductItemRepository productItemRepository;
        IVoucherRepository voucherRepository;
        IOrderPaymentStatusRepository orderPaymentStatusRepository;
        IOrderStatusRepository orderStatusRepository;
        ITransactionsRepository transactionsRepository;
        IOrderTransactionRepository orderTransactionRepository;
        IShopRepository shopRepository;
        INotificationRepository notificationRepository;
        public OrdersController(IOrdersRepository _repository,
            IOrderItemRepository _orderItemRepository,
            INotificationRepository _notificationRepository,
            ICartRepository _cartRepository,
            IVoucherRepository _voucherRepository,
            IShopRepository _shopRepository,
            IOrderStatusRepository _orderStatusRepository,
            IOrderTransactionRepository _orderTransactionRepository,
            ITransactionsRepository _transactionsRepository,
            IOrderPaymentStatusRepository _orderPaymentStatusRepository,
            IProductItemRepository _productItemRepository,
            ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
            orderItemrepository = _orderItemRepository;
            notificationRepository = _notificationRepository;
            cartRepository = _cartRepository;
            orderStatusRepository = _orderStatusRepository;
            productItemRepository = _productItemRepository;
            voucherRepository = _voucherRepository;
            orderTransactionRepository = _orderTransactionRepository;
            transactionsRepository = _transactionsRepository;
            orderPaymentStatusRepository = _orderPaymentStatusRepository;
            shopRepository = _shopRepository;
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
        [Route("admin/ListWaitingOrder")]
        public async Task<IActionResult> ListWaitingOrder()
        {
            try
            {
                //var dataList = await repository.ListByShopId();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.entities = dataList;
                //return View(dataList);
                return View();

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
        [Route("admin/ListCancelOrder")]
        public async Task<IActionResult> ListCancelOrder()
        {
            try
            {
                //var dataList = await repository.List();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.entities = dataList;
                //return View(dataList);
                return View();

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

                var dataList = new List<Orders>();
                //Case 1/2 systemAdmin
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SYSTEM_ADMIN)
                {
                    dataList = await repository.List();
                }
                //Case 2/2 shopManager
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER)
                {
                    //filer data
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add([FromBody] List<OrderRequestForm> model)
        {
            string UserIDSession = this.GetLoggedInUserId().ToString();
            string AccountTypeId = this.GetLoggedInAccountTypeId().ToString();
            if (AccountTypeId.Equals("10001"))
            {
                var novaticResponse1 = NovaticResponse.BadRequestMessage("account không có quyền vào trang này này");
                return Ok(novaticResponse1);
            }
            if (UserIDSession == null)
            {
                var novaticResponse1 = NovaticResponse.BadRequestMessage("đăng nhập để thực hiện chức năng này");
                return Ok(novaticResponse1);

            }
            int AccountID = Convert.ToInt32(UserIDSession);

            List<int> ListOrderID = new List<int>();
            if (model != null)
            {

                foreach (var request in model)
                {
                    if (ModelState.IsValid)
                    {
                        Orders orders = new Orders();
                        //1. business logic

                        //data validation
                        if (request.Name.Length == 0)
                        {
                            return BadRequest();
                        }

                        //auto correct
                        orders.Active = 1;

                        //auto set 

                        orders.OrderStatusId = 1000004;
                        orders.OrderPaymentStatusId = 1000002;
                        orders.CreatedTime = DateTime.Now;

                        // set data from request
                       
                        orders.OrderTypeId = request.OrderTypeId;
                        orders.AccountId = AccountID;
                        orders.ShopId = request.ShopId;
                        orders.Voucher = request.Voucher;
                        orders.Price = request.Price;
                        orders.TotalPrice = request.TotalPrice;
                        orders.Description = request.Description;
                        orders.Discount = request.Discount;
                        orders.FinalPrice = request.FinalPrice;
                        orders.Name = request.Name;
                        orders.Info = request.Info;
                        orders.Feedback = request.Feedback;
                        orders.GuId = request.GuId;
                        orders.ShippingUnit = request.ShippingUnit;


                        //2. add new object
                        try
                        {
                            var newObj = await repository.Add(orders);
                            List<OrderItem> orderItems = new List<OrderItem>();
                            foreach (OrderCartFormRequest x in request.ListCart)
                            {
                                if (x.Active != 0)
                                {
                                    ProductItem productItem = productItemRepository.GetByProductID(x.ProductId);
                                    if (productItem != null)
                                    {
                                        OrderItem item = new OrderItem();
                                        item.OrderId = newObj.Id;
                                        item.Active = 1;
                                        item.Name = x.Name;
                                        item.Description = x.Description;
                                        item.ProductItemId = productItem.Id;
                                        item.Quantity = x.Quantity;
                                        item.Price = x.Price;
                                        item.TotalPrice = request.TotalPrice;
                                        item.Description = request.Description;
                                        item.CreatedTime = DateTime.Now;

                                        if (productItem.QuantityAvailable < x.Quantity)
                                        {
                                            var novaticResponse = NovaticResponse.NotFoundMesage("Over Quantity .Sorry my customer !");
                                            return Ok(novaticResponse);
                                        }
                                        orderItems.Add(item);
                                        productItem.QuantityAvailable -= x.Quantity;
                                        await productItemRepository.Update(productItem);
                                        if (orders.OrderTypeId == 1000002)
                                        {
                                            Cart cart = cartRepository.GetCartById(x.Id);
                                            cart.Active = 0;
                                            await cartRepository.Delete(cart);
                                        }

                                    }
                                    else
                                    {

                                        var novaticResponse = NovaticResponse.NotFoundMesage("Over Product Item Sorry My customer");
                                        Cart cart = cartRepository.GetCartById(x.Id);
                                        cart.Active = 0;
                                        await cartRepository.Delete(cart);
                                        return Ok(novaticResponse);
                                    }

                                }
                                else
                                {
                                    var novaticResponse = NovaticResponse.NotFoundMesage("Can not find Cart");
                                    return Created("", novaticResponse);
                                }


                            }
                            await orderItemrepository.AddRange(orderItems);
                            // logic add notification
                            Notification notification = new Notification();
                            notification.Active = 1;
                            notification.Description = "order Successfull";
                            notification.CreatedTime = DateTime.Now;
                            notification.AccountId = AccountID;
                            notification.SenderId = request.ShopId;
                            notification.Name = request.Name;
                            notification.NotificationStatusId = 1000002;
                            await notificationRepository.Add(notification);


                            if (request.Voucher != "")
                            {
                                Voucher voucher = voucherRepository.GetVoucher(request.voucherCode);
                                if (voucher == null)
                                {
                                    var novaticResponse = NovaticResponse.NotFoundMesage("Your Voucher is Over");
                                    return Ok(novaticResponse);
                                }
                                voucher.Quantity = voucher.Quantity - 1;
                                if (voucher.Quantity == 0)
                                {
                                    voucher.VoucherStatusId = 1000002;
                                    voucher.Active = 0;
                                }
                                await voucherRepository.Update(voucher);
                            }
                            ListOrderID.Add(newObj.Id);

                        }
                        catch (Exception e)
                        {
                            var novaticResponse = NovaticResponse.NotFoundMesage("Error : " + e.Message);
                            return Ok(novaticResponse);
                        }
                    }

                }
                var novaticResponse1 = NovaticResponse.SUCCESS(ListOrderID);
                return Created("", novaticResponse1);

            }
            return BadRequest();

        }


        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody] Orders model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 
                    var orderItems = await orderItemrepository.ListByOrderId(model.Id);
                    foreach (OrderItem item in orderItems)
                    {
                        ProductItem productItem = productItemRepository.GetByProductID(item.ProductItemId);
                        productItem.QuantityAvailable += item.Quantity;
                        await productItemRepository.Update(productItem);

                    }

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Delete([FromBody] Orders model)
        {
            if (ModelState.IsValid)
            {
                OrderTransaction orderTransaction = orderTransactionRepository.GetByOrderId(model.Id);
                Transactions transactions = transactionsRepository.GetById(orderTransaction.TransactionId);

                try
                {

                    //1. business logic
                    //set Active to 0
                    model.Active = 0;
                    transactions.Active = 0;
                    orderTransaction.Active = 0;
                    Notification notification = new Notification();
                    notification.Active = 1;
                    notification.Description = "your order Was be cancel";
                    notification.CreatedTime = DateTime.Now;
                    notification.AccountId = model.AccountId;
                    notification.SenderId = model.ShopId;
                    notification.Name = model.Name;
                    notification.NotificationStatusId = 1000002;

                    //2. logically delete object
                    var dataList = await orderItemrepository.ListByOrderId(model.Id);
                    ProductItem productItem = new ProductItem();
                    foreach (var x in dataList)
                    {
                        productItem = productItemRepository.GetById(x.ProductItemId);

                        productItem.Quantity += x.Quantity;
                        await productItemRepository.Update(productItem);

                    }
                    await repository.Delete(model);
                    await transactionsRepository.Delete(transactions);
                    await orderTransactionRepository.Delete(orderTransaction);
                    await notificationRepository.Add(notification);
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
        public async Task<IActionResult> DeletePermanently([FromBody] Orders model)
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
        public int CountOrders()
        {
            int result = repository.CountOrders();
            return result;
        }

        [HttpGet]
        [Route("api/SearchOrderByAcount")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SearchOrderByAcount(int orderStatusId)
        {
            try
            {
                string UserIDSession = this.GetLoggedInUserId().ToString();
                string AccountTypeId = this.GetLoggedInAccountTypeId().ToString();
                if (AccountTypeId.Equals("10001"))
                {
                    var novaticResponse1 = NovaticResponse.BadRequestMessage("account không có quyền vào trang này này");
                    return Ok(novaticResponse1);
                }
                if (UserIDSession == null)
                {
                    var novaticResponse1 = NovaticResponse.BadRequestMessage("đăng nhập để thực hiện chức năng này");
                    return Ok(novaticResponse1);

                }
                int AccountID = Convert.ToInt32(UserIDSession);

                var dataList = await repository.GetOrderByAcount(AccountID, orderStatusId);
                dataList.Select(x =>
                {
                    OrderPaymentStatus status = orderPaymentStatusRepository.GetById(x.OrderPaymentStatusId);
                    OrderStatus orderStatus = orderStatusRepository.GetById(x.OrderStatusId);
                    x.OrderPaymentStatus = status;
                    x.OrderStatus = orderStatus;
                    return x;
                }).ToList();

                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Không có dữ liệu");
                    return Ok(novaticResponse1);
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
        [Route("api/GetOrderById")]
        public async Task<IActionResult> GetOrderById(int OrderId)
        {
            try
            {
                Orders orders = repository.GetORdersByOrderId(OrderId);

                if (orders == null)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Không có dữ liệu");
                    return Ok(novaticResponse1);
                }

                var novaticResponse = NovaticResponse.SUCCESS(orders);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }

        [HttpPost]
        [Route("api/CancelOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CancelOrder([FromBody] Orders Order)
        {
            string UserIDSession = this.GetLoggedInUserId().ToString();

            if (ModelState.IsValid)
            {
                // Defind
                Orders request = repository.GetORdersByOrderId(Order.Id);
                Transactions transactions = transactionsRepository.GetById(orderTransactionRepository.GetByOrderId(Order.Id).TransactionId);
                if (request == null || transactions == null)
                {
                    var novaticResponse = NovaticResponse.NotFoundMesage("not found datata");
                    return Ok(novaticResponse);
                }
                ProductItem productItem = new ProductItem();
                //0.Auto Fix for Order
                request.OrderStatusId = 1000002;
                request.OrderPaymentStatusId = 1000004;
                //Auto set notìication
                Notification notification = new Notification();
                notification.Active = 1;
                notification.Description = "you cancel your order successfull";
                notification.CreatedTime = DateTime.Now;
                notification.AccountId = Order.AccountId;
                notification.SenderId = Order.ShopId;
                notification.Name = Order.Name;
                notification.NotificationStatusId = 1000002;

                //2. add new object
                try
                {
                    await repository.Update(request);
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
        [HttpGet]
        [Route("api/ListByOrderStatus")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListByOrderStatus(int orderStatusId)
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

                var dataList = new List<Orders>();
                //Case 2/2 shopManager
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER)
                {
                    //filer data
                    dataList = await repository.ListByShopId(shopId, orderStatusId);
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

        [HttpPost]
        [Route("api/AcceptOrder")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> acceptOrder([FromBody] Orders Order)
        {


            if (ModelState.IsValid)
            {
                // Defind
                Orders request = repository.GetORdersByOrderId(Order.Id);              
                ProductItem productItem = new ProductItem();
                //0.Auto Fix for Order
                request.OrderStatusId = 1000003;
                //Auto set notification
                Notification notification = new Notification();
                notification.Active = 1;
                notification.Description = "your order was be accepted";
                notification.CreatedTime = DateTime.Now;
                notification.AccountId = Order.AccountId;
                notification.SenderId = Order.ShopId;
                notification.Name = Order.Name;
                notification.NotificationStatusId = 1000002;

                //2. add new object
                try
                {
                    await repository.Update(request);
                    await notificationRepository.Add(notification);
                    var novaticResponse = NovaticResponse.SUCCESS("Accept Order successfully");
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
