
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
using Novatic.Models.CRM.ResponseForm;
using A2F.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        IProductRepository repository;
        IShopRepository shopRepository;
        IProductItemRepository productItemRepository;
        ISystemConfigRepository repositorySystemConfig;

        public ProductController(IProductRepository _repository, IShopRepository _shopRepository,IProductItemRepository _productItemRepository ,ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
            productItemRepository = _productItemRepository;
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
        [Route("api/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var dataList = await repository.List();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }
                int quantity;
                List<ProductResponseForm> productResponseForms = new List<ProductResponseForm>();
                dataList.Select(x =>
                {
                    string ShopName = shopRepository.GetShopbyID(x.ShopId).Name;
                    
                    ProductItem productItem = productItemRepository.GetByProductID(x.Id);
                    if(productItem == null)
                    {
                        quantity = 0;

                    }
                    else
                    {
                        quantity = productItem.Quantity;
                    }
                   

                    ProductResponseForm productResponseForm = new ProductResponseForm(x.Id, x.ShopId, ShopName, quantity, x.ProductTypeId, x.ProductStatusId, x.ProductCategoryId, x.ProductBrandId, x.ProductDiscountTypeId, x.Name, x.Origin, x.Description, x.Active, x.Photo, x.Price, x.Info, x.CreatedTime);
                    productResponseForms.Add(productResponseForm);


                    return x;
                }).ToList();

                var novaticResponse = NovaticResponse.SUCCESS(productResponseForms.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }


        [HttpGet]
        [Route("api/ListAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListAdmin()
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

                var dataList = new List<Product>();
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
                int quantity;
                List<ProductResponseForm> productResponseForms = new List<ProductResponseForm>();
                dataList.Select(x =>
                {
                    string ShopName = shopRepository.GetShopbyID(x.ShopId).Name;

                    ProductItem productItem = productItemRepository.GetByProductID(x.Id);
                    if (productItem == null)
                    {
                        quantity = 0;

                    }
                    else
                    {
                        quantity = productItem.Quantity;
                    }


                    ProductResponseForm productResponseForm = new ProductResponseForm(x.Id, x.ShopId, ShopName, quantity, x.ProductTypeId, x.ProductStatusId, x.ProductCategoryId, x.ProductBrandId, x.ProductDiscountTypeId, x.Name, x.Origin, x.Description, x.Active, x.Photo, x.Price, x.Info, x.CreatedTime);
                    productResponseForms.Add(productResponseForm);


                    return x;
                }).ToList();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(productResponseForms.Cast<object>().ToList());
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
        public async Task<IActionResult> Add([FromBody] Product model)
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
        public async Task<IActionResult> Update([FromBody] Product model)
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
        public async Task<IActionResult> Delete([FromBody] Product model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] Product model)
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
        public int CountProduct()
        {
            int result = repository.CountProduct();
            return result;
        }


        [HttpGet]
        [Route("api/list/categoryId")]
        public async Task<IActionResult> getProductBycate(int cateID, int pageIndex, int pageSize)
        {

            if (pageIndex < 0 || pageSize < 0) return BadRequest();

            try
            {
                var dataList = await repository.getListProductByCate(cateID, pageIndex, pageSize);
                int total = repository.CountProductByCategory(cateID);
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Data is null");
                    return Ok(novaticResponse1);

                }

                int quantity;
                List<ProductResponseForm> productResponseForms = new List<ProductResponseForm>();
                dataList.Select(x =>
                {
                    string ShopName = shopRepository.GetShopbyID(x.ShopId).Name;

                    ProductItem productItem = productItemRepository.GetByProductID(x.Id);
                    if (productItem == null)
                    {
                        quantity = 0;

                    }
                    else
                    {
                        quantity = productItem.Quantity;
                    }


                    ProductResponseForm productResponseForm = new ProductResponseForm(x.Id, x.ShopId, ShopName, quantity, x.ProductTypeId, x.ProductStatusId, x.ProductCategoryId, x.ProductBrandId, x.ProductDiscountTypeId, x.Name, x.Origin, x.Description, x.Active, x.Photo, x.Price, x.Info, x.CreatedTime);
                    productResponseForms.Add(productResponseForm);


                    return x;
                }).ToList();

                var novaticResponse = NovaticResponse.SUCCESS(productResponseForms.Cast<object>().ToList(), total);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                var novaticResponse1 = NovaticResponse.NotFoundMesage("Error " + e.Message);
                return Ok(novaticResponse1);
            }
        }

        [HttpGet]
        [Route("api/list/SearchbyCategoryIdAndName")]
        public async Task<IActionResult> SearchbyCategoryIdAndName(int cateID, int pageIndex, int pageSize, string textSearch,int shopId)
        {
            int totalPage;
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.getListProductByCateAndName(cateID, pageIndex, pageSize, textSearch,shopId);
                int total = repository.CountProduct();
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.SUCCESS();
                    return Ok(novaticResponse1);
                }
                totalPage = total / pageSize;
                if (totalPage % pageSize != 0)
                {
                    totalPage = totalPage + 1;
                }
                int quantity;
                List<ProductResponseForm> productResponseForms = new List<ProductResponseForm>();
                dataList.Select(x =>
                {
                    string ShopName = shopRepository.GetShopbyID(x.ShopId).Name;

                    ProductItem productItem = productItemRepository.GetByProductID(x.Id);
                    if (productItem == null)
                    {
                        quantity = 0;

                    }
                    else
                    {
                        quantity = productItem.Quantity;
                    }


                    ProductResponseForm productResponseForm = new ProductResponseForm(x.Id, x.ShopId, ShopName, quantity, x.ProductTypeId, x.ProductStatusId, x.ProductCategoryId, x.ProductBrandId, x.ProductDiscountTypeId, x.Name, x.Origin, x.Description, x.Active, x.Photo, x.Price, x.Info, x.CreatedTime);
                    productResponseForms.Add(productResponseForm);


                    return x;
                }).ToList();
                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList(), totalPage);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                var novaticResponse1 = NovaticResponse.NotFoundMesage("Error " + e.Message);
                return Ok(novaticResponse1);
            }
        }

        [HttpGet]
        [Route("api/list/countProduct")]
        public async Task<IActionResult> countProductbyCate(int cateID)
        {

            try
            {
                var dataList = repository.CountProductbyCate(cateID);

                if (dataList == null || dataList == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Data is null ");
                    return Ok(novaticResponse1);
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }

        [HttpGet]
        [Route("api/list/BrandId")]
        public async Task<IActionResult> getProductByBrandID(int brandId, int pageIndex, int pageSize)
        {

            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.getListProductByBrand(brandId, pageIndex, pageSize);
                int total = repository.CountProductByBrand(brandId);
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Data is null ");
                    return Ok(novaticResponse1);
                }
                int quantity;
                List<ProductResponseForm> productResponseForms = new List<ProductResponseForm>();
                dataList.Select(x =>
                {
                    string ShopName = shopRepository.GetShopbyID(x.ShopId).Name;

                    ProductItem productItem = productItemRepository.GetByProductID(x.Id);
                    if (productItem == null)
                    {
                        quantity = 0;

                    }
                    else
                    {
                        quantity = productItem.Quantity;
                    }


                    ProductResponseForm productResponseForm = new ProductResponseForm(x.Id, x.ShopId, ShopName, quantity, x.ProductTypeId, x.ProductStatusId, x.ProductCategoryId, x.ProductBrandId, x.ProductDiscountTypeId, x.Name, x.Origin, x.Description, x.Active, x.Photo, x.Price, x.Info, x.CreatedTime);
                    productResponseForms.Add(productResponseForm);


                    return x;
                }).ToList();
                var novaticResponse = NovaticResponse.SUCCESS(productResponseForms.Cast<object>().ToList(), total);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }
        [HttpGet]
        [Route("api/list/FilterByShop")]
        public async Task<IActionResult> FilterByShop(int ShopID, int pageIndex, int pageSize)
        {

            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.getListProductByShopID(ShopID, pageIndex, pageSize);
                int total = repository.CountProductByShopID(ShopID);
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Data is null ");
                    return Ok(novaticResponse1);
                }
                int quantity;
                List<ProductResponseForm> productResponseForms = new List<ProductResponseForm>();
                dataList.Select(x =>
                {
                    string ShopName = shopRepository.GetShopbyID(x.ShopId).Name;

                    ProductItem productItem = productItemRepository.GetByProductID(x.Id);
                    if (productItem == null)
                    {
                        quantity = 0;

                    }
                    else
                    {
                        quantity = productItem.Quantity;
                    }


                    ProductResponseForm productResponseForm = new ProductResponseForm(x.Id, x.ShopId, ShopName, quantity, x.ProductTypeId, x.ProductStatusId, x.ProductCategoryId, x.ProductBrandId, x.ProductDiscountTypeId, x.Name, x.Origin, x.Description, x.Active, x.Photo, x.Price, x.Info, x.CreatedTime);
                    productResponseForms.Add(productResponseForm);


                    return x;
                }).ToList();

                var novaticResponse = NovaticResponse.SUCCESS(productResponseForms.Cast<object>().ToList(), total);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }
    }
}
