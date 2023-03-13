
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using Novatic.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagController : BaseController
    {
        ITagRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        IPostTagRepository repositoryPostTag;
        public TagController(ICacheHelper cacheHelper,
    ISystemConfigRepository _repositorySystemConfig, ITagRepository _repository, IAccountRepository _repositoryAccount, IPostTagRepository _repositoryPostTag) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositoryPostTag = _repositoryPostTag;
        }

        [HttpGet]
        [Route("admin/List")]
        public async Task<IActionResult> AdminList()
        {
            //// lấy session user info
            //int UserID = 0;
            //int UserTypeID = 0;
            //try
            //{
            //    string UserIDSession = HttpContext.Session.GetString("UserID");
            //    if (UserIDSession != null && UserIDSession != "")
            //    {
            //        UserID = Convert.ToInt32(UserIDSession);

            //        List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
            //        AccountViewModel accountObj = AccountDataList[0];
            //        ViewBag.UserTypeID = accountObj.AccountTypeID;

            //        UserTypeID = accountObj.AccountTypeID;
            //    }
            //}
            //catch (Exception) { throw; }

            //// kiểm tra nếu không phải admin thì điều hướng 403
            //if (UserTypeID != 10001)
            //{
            //    return Redirect("/403.html");
            //}
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

        [HttpPost]
        [Route("api/LoadTable")]
        public async Task<IActionResult> LoadTable([FromBody]DTParameters dtParameters)
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
            var result = (searchBy.Length == 0 ? await repository.List() : await repository.Search(searchBy));
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
            var totalResultsCount = repository.CountTag();

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
        public async Task<IActionResult> Add([FromBody]Tag model)
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
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody]Tag model)
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
        public async Task<IActionResult> Delete([FromBody]Tag model)
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
        public async Task<IActionResult> DeletePermanently([FromBody]Tag model)
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
        [Route("api/UpdateAllTagPostCount")]
        public async Task<IActionResult> UpdateAllTagPostCount()
        {
            try
            {
                var dataList = await repository.List();
                List<Tag> newData = new List<Tag>();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }
                for(int i = 0; i < dataList.Count; i++)
                {
                    //new code
                    //1. get postCount value
                    int PostCount = repositoryPostTag.CountPost(dataList[i].Id);

                    //2. update tag object
                    dataList[i].PostCount = PostCount;
                    await repository.Update(dataList[i]);

                    //old code
                    //List<PostTag> PostTagList = await repositoryPostTag.DetailByTagID(dataList[i].Id);
                    //if (PostTagList.Count > 0)
                    //{
                    //    List<Tag> Obj = await repository.Detail(PostTagList[0].TagId);
                    //    if (Obj.Count > 0)
                    //    {
                    //        Obj[0].PostCount = PostTagList.Count;
                    //        await repository.Update(Obj[0]);
                    //        newData.Add(Obj[0]);
                    //    }
                    //}
                }

                var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/UpdateTagPostCount")]
        public async Task<IActionResult> UpdateTagPostCount(int PostId, int TagId)
        {
            try
            {
                List<Tag> newData = new List<Tag>();
                if (TagId < 0 || PostId<0)
                {
                    return NotFound();
                }
                
                List<PostTag> PostTagList = await repositoryPostTag.DetailByPostIDAndTagID(PostId, TagId);
                 if (PostTagList.Count > 0)
                 {
                    List<Tag> Obj = await repository.Detail(TagId);
                    if (Obj.Count > 0)
                      {
                         Obj[0].PostCount = Obj[0].PostCount +1;
                         await repository.Update(Obj[0]);
                         newData.Add(Obj[0]);
                    }
                  }

                var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
                return Ok(novaticResponse);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Count")]
        public int CountTag()
        {
            int result = repository.CountTag();
            return result;
        }
    }
}
