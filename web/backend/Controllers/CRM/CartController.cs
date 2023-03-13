
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novatic.Util;
using Novatic.Models.CRM;
using Novatic.Models.CRM.ProductMetaRessponse;
using Novatic.Models.CRM.RequestForm;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CartController : BaseController
    {
        ICartRepository repository;

        IShopRepository shopRepository;
        IProductRepository productRepository;

        ISystemConfigRepository repositorySystemConfig;
        public CartController(ICartRepository _repository, IShopRepository _shopRepository, IProductRepository _productRepository, ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
            shopRepository = _shopRepository;
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
                var dataList = await repository.List();

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
        public async Task<IActionResult> Add([FromBody] CartRequestForm request)
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
            Cart model = new Cart();
            model.AccountId = AccountID;
            model.ProductId = request.ProductId;
            model.Description = request.Description;
            model.Quantity = request.Quantity;
            model.Name = request.Name;
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

                //auto time = now 
                model.CreatedTime = DateTime.Now;

                //2. add new object
                try
                {
                    int shopID = productRepository.getListId(model.ProductId).ShopId;
                    int accountID = shopRepository.GetShopbyID(shopID).AccountId;
                    if(accountID == AccountID)
                    {
                        var novaticResponse = NovaticResponse.BadRequestMessage("CAn not by your shop");
                        return Ok(novaticResponse);

                    }
                    Cart currentCart = repository.checkExisProduct(model.ProductId, AccountID);
                    if (currentCart != null)
                    {
                        currentCart.Quantity += model.Quantity;
                        await repository.Update(currentCart);
                        var novaticResponse = NovaticResponse.SUCCESS(currentCart);
                        return Ok(novaticResponse);
                    }
                    else
                    {
                        var newObj = await repository.Add(model);
                        if (newObj.Id > 0)
                        {
                           var  novaticResponse = NovaticResponse.CREATED(model);
                            return Created("", novaticResponse);
                        }
                        else
                        {
                            var novaticResponse = NovaticResponse.NotFound("not found");
                            return Ok(novaticResponse);
                        }
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
        public async Task<IActionResult> Update([FromBody] Cart model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 
                    model.CreatedTime = DateTime.Now;   
                    

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

        public async Task<IActionResult> Delete([FromBody] Cart model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] Cart model)
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
        public int CountCart()
        {
            int result = repository.CountCart();
            return result;
        }

        [HttpGet]
        [Route("api/ListbyAccountID")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListByAcountId()
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
            try
            {

                List<CartResponseForm> cartResponseForms = new List<CartResponseForm>();
                var dataList = await repository.List(AccountID);

                dataList.Select(x =>
                {
                    CartResponseForm cartResponseForm = new CartResponseForm();
                    var product = productRepository.getListId(x.ProductId);
                    string shopName = shopRepository.GetShopbyID(product.ShopId).Name;
                    cartResponseForm.ProductName = product.Name;
                    cartResponseForm.img = product.Photo;
                    cartResponseForm.ShopId = product.ShopId;
                    cartResponseForm.ShopName = shopName;
                    cartResponseForm.Id = x.Id;
                    cartResponseForm.AccountId = x.AccountId;
                    cartResponseForm.ProductId = x.ProductId;
                    cartResponseForm.CreatedTime = x.CreatedTime;
                    cartResponseForm.Description = x.Description;
                    cartResponseForm.Active = x.Active;
                    cartResponseForm.Name = x.Name;
                    cartResponseForm.Quantity = x.Quantity;
                    cartResponseForm.price = product.Price;
                    cartResponseForms.Add(cartResponseForm);
                    return x;
                }).ToList();


                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.SUCCESS("Không có thông tin");
                    //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                    return Ok(novaticResponse1);
                }

                var novaticResponse = NovaticResponse.SUCCESS(cartResponseForms.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                var novaticResponse1 = NovaticResponse.NotFoundMesage("error : "+e.Message);
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse1);
            }
        }

        [HttpGet]
        [Route("api/CountCart")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int CountCartByAccountID()
        {
            string UserIDSession = this.GetLoggedInUserId().ToString();
        
            int AccountID = Convert.ToInt32(UserIDSession);
            int result = repository.CountCartByAccountID(AccountID);
            return result;
        }

        [HttpPost]
        [Route("api/DeleteListCart")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> DeleteListCart( List<int> cartID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (int i in cartID)
                    {
                        Cart cart = repository.GetCartById(i);
                        cart.Active = 0;                      
                        await repository.Delete(cart);
                    }                
                    var novaticResponse = NovaticResponse.SUCCESS("delete successfull");
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
        [Route("api/GetListCart")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> GetListCart(List<int> cartID)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Cart> list = new List<Cart>();
                    foreach (int i in cartID)
                    {
                        Cart cart = repository.GetCartById(i);
                       list.Add(cart);
                    }
                    var novaticResponse = NovaticResponse.SUCCESS(list);
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
    }
}