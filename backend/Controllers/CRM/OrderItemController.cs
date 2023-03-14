
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using A2F.Util;
using Novatic.Models.CRM.ResponseForm;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderItemController : BaseController
    {
        IOrderItemRepository repository;
        ICartRepository cartRepository;
        IShopRepository shopRepository;
        IOrdersRepository orderRepository;
        IProductItemRepository productItemRepository;
        IProductRepository productRepository;
        ISystemConfigRepository repositorySystemConfig;
        public OrderItemController(IOrderItemRepository _repository, 
            ICartRepository _cartRepository, 
            IProductItemRepository _productItemRepository, 
            ISystemConfigRepository _repositorySystemConfig,
            IOrdersRepository _orderRepository,
            IShopRepository _shopRepository,
            IProductRepository _productRepository,
            ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
            cartRepository = _cartRepository;
            shopRepository = _shopRepository;
            orderRepository = _orderRepository;
            productItemRepository = _productItemRepository; 
            productRepository = _productRepository;
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

                var dataList = new List<OrderItem>();
                //Case 1/2 systemAdmin
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SYSTEM_ADMIN)
                {
                    dataList = await repository.List();
                }
                //Case 2/2 shopManager
                if (AccountTypeId == SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER)
                {
                    //filer data
                    var dataListTotal = await repository.List();
                    var dataOrder = await orderRepository.ListByShopId(shopId);

                    for (int i = 0; i < dataListTotal.Count; i++)
                    {
                        for (int j = 0; j < dataOrder.Count; j++)
                        {
                            if (dataListTotal[i].OrderId == dataOrder[j].Id)
                            {
                                dataList.Add(dataListTotal[i]);
                                break;
                            }
                        }
                    }
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
        public async Task<IActionResult> Add([FromBody] OrderItem model)
        {
            if (ModelState.IsValid)
            {
                //1. business logic

                //data validation
                if (model.Name.Length == 0)
                {
                    return BadRequest();
                }

                //auto correct
                model.Active = 1;

                //2. add new object
                try
                {
                    var newObj = await repository.Add(model);
                    if (newObj.Id > 0)
                    {
                        var novaticResponse = NovaticResponse.CREATED(model);
                        return Created("", novaticResponse);
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
            return BadRequest();
        }


        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody] OrderItem model)
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
        public async Task<IActionResult> Delete([FromBody] OrderItem model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] OrderItem model)
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
        public int CountOrderItem()
        {
            int result = repository.CountOrderItem();
            return result;
        }

        [HttpGet]
        [Route("api/GetListByOrderId")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListByOrderId(int OrderID)
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
            try
            {
                var dataList = await repository.ListByOrderId(OrderID);
                List< detailsOrderResponse>  detailsOrderResponses = new List< detailsOrderResponse>();

                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Không có dữ liệu");
                    return Ok(novaticResponse1);
                }
                dataList.Select(x =>
                {
                    detailsOrderResponse detailsOrderResponse = new detailsOrderResponse();
                    detailsOrderResponse.TotalPrice = x.TotalPrice;
                    detailsOrderResponse.Price = x.Price;
                    detailsOrderResponse.Quantity = x.Quantity;
                    detailsOrderResponse.CreatedTime = x.CreatedTime;
                    detailsOrderResponse.Id = x.Id;
                    detailsOrderResponse.Description = x.Description;
                    detailsOrderResponse.Active = x.Active;
                    detailsOrderResponse.ProductItemId = x.ProductItemId;
                    detailsOrderResponse.Name = x.Name;
                    int productID = productItemRepository.GetById(x.ProductItemId).ProductId;
                    detailsOrderResponse.Photo = productRepository.getListId(productID).Photo;
                    detailsOrderResponses.Add(detailsOrderResponse);

                    return x;
                }).ToList();
                var novaticResponse = NovaticResponse.SUCCESS(detailsOrderResponses.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }
    }
}
