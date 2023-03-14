
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
    public class PostTagController : BaseController
    {
        IPostTagRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        ITagRepository repositoryTag;
        public PostTagController(ICacheHelper cacheHelper,
    ISystemConfigRepository _repositorySystemConfig, IPostTagRepository _repository, IAccountRepository _repositoryAccount, ITagRepository _repositoryTag) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositoryTag = _repositoryTag;
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
        [Route("api/DetailPost/{Id}")]
        public async Task<IActionResult> DetailPost(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var dataList = await repository.DetailPost(Id);

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
        public async Task<IActionResult> Add([FromBody]PostTag model)
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
        public async Task<IActionResult> Update([FromBody]PostTag model)
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




        [HttpGet]
        [Route("api/updatePostTag")]
        public async Task<IActionResult> UpdatePostTag(int postID, string tagData)
        {
            if (postID < 0 || tagData.Length < 0) return BadRequest();
            try
            {
                //get postTag list 
                var dataList = await repository.DetailPost(postID);
                var tagIDList = tagData.Split("|");

                //1. xử lý update từng tagID 
                for (int i = 0; i < tagIDList.Length; i++)
                {
                    int tagID = 0;
                    if(Int32.TryParse(tagIDList[i], out tagID)){
                        //kiểm tra trong list đã có tag này chưa
                        int tagExistingFlag = 0;
                        for (int j = 0; j < dataList.Count; j++)
                        {
                            if(dataList[j].TagId == tagID && dataList[j].Active == 1)
                            {
                                tagExistingFlag = 1;
                                break;
                            }
                        }

                        //nếu chưa tồn tại thì insert
                        if(tagExistingFlag == 0)
                        {
                            List<Tag> tempTagList = await repositoryTag.Detail(tagID);
                            Tag t = tempTagList[0];

                            PostTag pt = new PostTag();
                            pt.PostId = postID;
                            pt.TagId = tagID;
                            pt.Active = 1;
                            pt.Id = 0;
                            pt.Name = t.Name;
                            pt.Description = t.Description;
                            pt.CreatedTime = DateTime.Now;
                            await repository.Add(pt);

                            //insert xong rồi thì cập nhật PostCount cho tag đó
                            int TagCurrentPostCount = repository.CountPost(tagID);
                            t.PostCount = TagCurrentPostCount;
                            await repositoryTag.Update(t);
                        }
                    };
                }

                //2. xử lý xóa các tag đã hủy
                for (int i = 0; i < dataList.Count; i++)
                {
                    if(!(tagData.IndexOf(dataList[i].TagId.ToString()) >= 0))
                    {
                        dataList[i].Active = 0;
                        await repository.Update(dataList[i]);

                        // hủy rồi cũng sẽ cập nhật Post count
                        int tagID = dataList[i].TagId;
                        List<Tag> tempTagList = await repositoryTag.Detail(tagID); 
                        Tag t = tempTagList[0];
                        int TagCurrentPostCount = repository.CountPost(tagID);
                        t.PostCount = TagCurrentPostCount;
                        await repositoryTag.Update(t);

                    }
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message+"-"+e.InnerException);
            }
        }


        [HttpPost]
        [Route("api/Delete")]
        public async Task<IActionResult> Delete([FromBody]PostTag model)
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
        public async Task<IActionResult> DeletePermanently([FromBody]PostTag model)
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
    }
}
