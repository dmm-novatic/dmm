
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostTopicController : BaseController
    {
        IPostTopicRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        IPostRepository repositoryPost;
        public PostTopicController(ICacheHelper cacheHelper,
            ISystemConfigRepository _repositorySystemConfig, 
            IPostTopicRepository _repository, 
            IAccountRepository _repositoryAccount,
            IPostRepository _repositoryPost) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositoryPost = _repositoryPost;
        }


        [HttpGet]
        [Route("admin/List/{TopicID}")]
        public async Task<IActionResult> AdminList(int TopicID)
        {
            try
            {
                var dataList = await repository.ListByTopicId(TopicID);

                if (dataList == null || dataList.Count == 0)
                {
                    PostTopic obj = new PostTopic();
                    obj.Id = 0;
                    obj.TopicId = TopicID; 
                    return View(obj);
                }


                ViewBag.entities = dataList;
                return View(dataList[0]);

                //var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                ////var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                //return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/ListByTopicId/{TopicId}")]
        public async Task<IActionResult> ListByTopicId(int TopicId)
        {
            try
            {
                var dataList = await repository.ListByTopicId(TopicId);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("api/Add")]
        public async Task<IActionResult> Add([FromBody]PostTopic model)
        {
            if (ModelState.IsValid)
            {
                //1. business logic

                //data validation
                //if (model.Name.Length == 0)
                //{
                //    return BadRequest();
                //}

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
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody]PostTopic model)
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
        public async Task<IActionResult> Delete([FromBody]PostTopic model)
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
        public async Task<IActionResult> DeletePermanently([FromBody]PostTopic model)
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
            catch (Exception)
            {
                return BadRequest();
            }
        }
    
        [HttpGet]
        [Route("api/AutoCreatePostTopic/{optionConditional}/{topicId}")]
        public async Task<IActionResult> AutoCreatePostTopic(string optionConditional, int topicId)
        {
            try
            {
                var listPost = await repositoryPost.ListPostTopic(optionConditional);
                //int result = await repository.CheckExistForAutoCreate(28775, 100060);
                for (int i = 0; i < listPost.Count; i++)
                {
                    int result = await repository.CheckExistForAutoCreate(listPost[i].Id, topicId);
                    if (result == 0)
                    {
                        PostTopic obj = new PostTopic();
                        obj.PostId = listPost[i].Id;
                        obj.TopicId = topicId;
                        obj.Active = 1;
                        obj.Name = optionConditional;
                        obj.Description = optionConditional;
                        obj.CreatedTime = DateTime.Now;

                        var newObj = await repository.Add(obj);
                    }
                }
                List<PostTopic> newData = new List<PostTopic>();
                var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    
        [HttpPost]
        [Route("api/LoadTable/{topicId}")]
        public async Task<IActionResult> LoadTable([FromBody]DTParameters dtParameters, int topicId)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListViewModelByTopicId(topicId) : await repository.SearchViewModelByTopicId(topicId,searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là để search nếu có tham số search
            //if (!string.IsNullOrEmpty(searchBy))
            //{
            //    result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.FirstSurname != null && r.FirstSurname.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.SecondSurname != null && r.SecondSurname.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.Street != null && r.Street.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.Phone != null && r.Phone.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.ZipCode != null && r.ZipCode.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.Country != null && r.Country.ToUpper().Contains(searchBy.ToUpper()) ||
            //                               r.Notes != null && r.Notes.ToUpper().Contains(searchBy.ToUpper()))
            //        .ToList();
            //}

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountByTopicId(topicId);

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });

            //return Json(new
            //{
            //    draw = dtParameters.Draw,
            //    recordsTotal = totalResultsCount,
            //    recordsFiltered = filteredResultsCount,
            //    data = result.ToList()
            //});
        }
    }
}
