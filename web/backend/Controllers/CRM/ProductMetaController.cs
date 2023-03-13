
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
using Novatic.Models.CRM.ProductMetaRessponse;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductMetaController : BaseController
    {
        IProductMetaRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        public ProductMetaController(IProductMetaRepository _repository, ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
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
        public async Task<IActionResult> Add([FromBody] ProductMeta model)
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
        public async Task<IActionResult> Update([FromBody] ProductMeta model)
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
        public async Task<IActionResult> Delete([FromBody] ProductMeta model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] ProductMeta model)
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
        public int CountProductMeta()
        {
            int result = repository.CountProductMeta();
            return result;
        }

        [HttpGet]
        [Route("api/listProductMeta/ProductId")]
        public async Task<IActionResult> getProductBycate(int productId)
        {
            try
            {
                ProductmetaResponseForm productmetaResponseForm = new ProductmetaResponseForm();
                var dataList = await repository.ListByProductMeta(productId);
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Data is null");
                    return Ok(novaticResponse1);
                }


                dataList.Select(x =>
                {
                    switch (x.Key)
                    {
                        case "img":
                            productmetaResponseForm.img.Add(x.Value);
                            break;
                        case "style":
                            productmetaResponseForm.Style.Add(x.Value);
                            break;
                        case "wireless":
                            productmetaResponseForm.Wireless.Add(x.Value);
                            break;
                        case "dimensitons":
                            productmetaResponseForm.Dimensions.Add(x.Value);
                            break;
                        case "weight":
                            productmetaResponseForm.Weight.Add(x.Value);
                            break;
                        case "batteryLife":
                            productmetaResponseForm.BatteryLife.Add(x.Value);
                            break;
                        case "bluetooth":
                            productmetaResponseForm.bluetooth.Add(x.Value);
                            break;
                        case "color":
                            productmetaResponseForm.Color.Add(x.Value);
                            break;
                    }

                    return x;
                }).ToList();
                var novaticResponse = NovaticResponse.SUCCESS(productmetaResponseForm);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }
    }
}
