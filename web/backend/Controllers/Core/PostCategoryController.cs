
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
    public class PostCategoryController : BaseController
    {

        IPostCategoryRepository repository;
        IPostRepository repositoryPost;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;

        public PostCategoryController(
            ICacheHelper cacheHelper,
            ISystemConfigRepository _repositorySystemConfig,
            IPostCategoryRepository _repository, IAccountRepository _repositoryAccount, IPostRepository _repositoryPost) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositoryPost = _repositoryPost;
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

        [HttpGet]
        [Route("api/ListByNews")]
        public async Task<IActionResult> ListByNews()
        {
            try
            {
                var dataList = await repository.ListByNews();

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
        [Route("api/ListByPhuluc5")]
        public async Task<IActionResult> ListByPhuluc5()
        {
            try
            {
                var dataList = await repository.ListByPhuluc5();

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
        [Route("api/ListByLessonLearned")]
        public async Task<IActionResult> ListByLessonLearned()
        {
            try
            {
                var dataList = await repository.ListByLessonLearned();

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
        [Route("api/ListByEvents")]
        public async Task<IActionResult> ListByEvents()
        {
            try
            {
                var dataList = await repository.ListByEvents();

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
        [Route("api/ListByLibrary")]
        public async Task<IActionResult> ListByLibrary()
        {
            try
            {
                var dataList = await repository.ListByLibrary();

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
        public async Task<IActionResult> Add([FromBody]PostCategory model)
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
        public async Task<IActionResult> Update([FromBody]PostCategory model)
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
        public async Task<IActionResult> Delete([FromBody]PostCategory model)
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
        public async Task<IActionResult> DeletePermanently([FromBody]PostCategory model)
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
        [Route("api/UpdateAllPostCategoryPostCount")]
        public async Task<IActionResult> UpdateAllPostCategoryPostCount()
        {
            try
            {
                var dataList = await repository.List();
                List<PostCategory> newData = new List<PostCategory>();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }
                for (int i = 0; i < dataList.Count; i++)
                {
                    //new code
                    //1. get postCount value
                    int PostCount = repositoryPost.CountPost(dataList[i].Id);

                    //2. update tag object
                    dataList[i].PostCount = PostCount;
                    await repository.Update(dataList[i]);

                }

                var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    
        [HttpPost]
        [Route("api/UpdatePostCategoryPostCount/{PostCategoryID1}/{PostCategoryID2}")]
        public async Task<IActionResult> UpdatePostCategoryPostCount(int PostCategoryID1, int PostCategoryID2)
        {
            try
            {
                var obj1 = await repository.Detail(PostCategoryID1);
                List<PostCategory> newData = new List<PostCategory>();

                if (obj1 == null || obj1.Count == 0)
                {
                    return NotFound();
                }

                obj1[0].PostCount = obj1[0].PostCount + 1;
                await repository.Update(obj1[0]);

                //nếu là upadte thì trừ ở cate cũ đi 1
                if (PostCategoryID2 > 0)
                {
                    var obj2 = await repository.Detail(PostCategoryID2);
                    if (obj2 == null || obj2.Count == 0)
                    {
                        return NotFound();
                    }
                    if (obj2[0].PostCount > 0)
                    {
                        obj2[0].PostCount = obj2[0].PostCount - 1;
                    }
                    await repository.Update(obj2[0]);
                }

                var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
