
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

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoucherController : BaseController
    {
        IVoucherRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IPromotionRepository promotionRepository;
        IShopRepository shopRepository;
        public VoucherController(IVoucherRepository _repository,
            IPromotionRepository _promotionRepository,
            ISystemConfigRepository _repositorySystemConfig,
            IShopRepository _shopRepository,
            ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
            promotionRepository = _promotionRepository;
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

                var dataList = new List<Voucher>();
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
                    var dataPromotion = await promotionRepository.ListByShopId(shopId);

                    for (int i = 0; i < dataListTotal.Count; i++)
                    {
                        for (int j = 0; j < dataPromotion.Count; j++)
                        {
                            if (dataListTotal[i].PromotionId == dataPromotion[j].Id)
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
        public async Task<IActionResult> Add([FromBody] Voucher model)
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
        public async Task<IActionResult> Update([FromBody] Voucher model)
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
        public async Task<IActionResult> Delete([FromBody] Voucher model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] Voucher model)
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
        public int CountVoucher()
        {
            int result = repository.CountVoucher();
            return result;
        }


        [HttpGet]
        [Route("api/GetByCode")]
        public async Task<IActionResult> GetVoucherByCode(string CodeVoucher ,int ShopID)
        {
            try
            {
                Voucher voucher = repository.GetVoucher(CodeVoucher);

                if (voucher == null)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("sai mã giảm giá vui lòng nhập lại");
                    return Ok(novaticResponse1);
                }
                int CurrentShop = promotionRepository.getByPromationID(voucher.PromotionId).ShopId;
                if(CurrentShop != ShopID)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("sai mã giảm giá không phải của cửa hàng vui lòng nhập lại");
                    return Ok(novaticResponse1);
                }
                

                var novaticResponse = NovaticResponse.SUCCESS(voucher);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }
        //[HttpGet]
        //[Route("api/GetvoucherDMMByCode")]
        //public async Task<IActionResult> GetvoucherDMMByCode(string CodeVoucher)
        //{
        //    try
        //    {
        //        Voucher voucher = repository.GetVoucher(CodeVoucher);

        //        if (voucher == null)
        //        {
        //            var novaticResponse1 = NovaticResponse.NotFoundMesage("sai mã giảm giá vui lòng nhập lại");
        //            return Ok(novaticResponse1);
        //        }
        //        int ShopID = promotionRepository.getByPromationID(voucher.PromotionId).ShopId;

        //        if (ShopID != 0)
        //        {
        //            var novaticResponse1 = NovaticResponse.NotFoundMesage("sai mã giảm giá không phải của sàn vui lòng nhập lại");
        //            return Ok(novaticResponse1);
        //        }

        //        var novaticResponse = NovaticResponse.SUCCESS(voucher);
        //        return Ok(novaticResponse);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message + " - " + e.InnerException);
        //    }
        //}
    }
}
