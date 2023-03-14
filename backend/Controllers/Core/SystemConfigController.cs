
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2F.ViewModel;
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using Novatic.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SystemConfigController : BaseController
    {
        ISystemConfigRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        public SystemConfigController(ICacheHelper cacheHelper,
    ISystemConfigRepository _repositorySystemConfig, ISystemConfigRepository _repository, IAccountRepository _repositoryAccount) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
        }

        [HttpGet]
        [Route("admin/List")]
        public async Task<IActionResult> AdminList()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
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
        [Route("admin/downloadguidebook")]
        public async Task<IActionResult> AdminDownloadGuidebook()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
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
        [Route("admin/ConfigHomePageCategory")]
        public async Task<IActionResult> AdminConfigHomePageCategory()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
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
        [Route("admin/Slide")]
        public async Task<IActionResult> AdminSlide()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
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
        [Route("admin/ConfigLogo")]
        public async Task<IActionResult> ConfigLogo()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
            try
            {
                var dataList = await repository.ListLogo();

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
        [Route("admin/ConfigSocial")]
        public async Task<IActionResult> AdminConfigSocial()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
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
        [Route("admin/SystemPhoto")]
        public async Task<IActionResult> AdminSystemPhoto()
        {
            // lấy session user info
            int UserID = 0;
            int UserTypeID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;

                    UserTypeID = accountObj.AccountTypeID;
                }
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
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
        [Route("api/ListLogoAndBackgroundImage")]
        public async Task<IActionResult> ListLogoAndBackgroundImage()
        {
            try
            {
                var dataList = await repository.ListLogoAndBackgroundImage();

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
        [Route("api/ListSotay")]
        public async Task<IActionResult> ListSotay()
        {
            try
            {
                var dataList = await repository.ListSotay();

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
        [Route("api/List9Category")]
        public async Task<IActionResult> List9Category()
        {
            try
            {
                var dataList = await repository.List9Category();

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
        [Route("api/ListLogo")]
        public async Task<IActionResult> ListLogo()
        {
            try
            {
                var dataList = await repository.ListLogo();

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
        [Route("api/ListSocial")]
        public async Task<IActionResult> ListSocial()
        {
            try
            {
                var dataList = await repository.ListSocial();

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
        public async Task<IActionResult> Add([FromBody]SystemConfig model)
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
        [Route("api/AddSlide")]
        public async Task<IActionResult> AddSlide([FromBody] SystemConfig model)
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
                        if (newObj.Code.Contains("SLIDE_"))
                        {
                            newObj.Code = model.Code + "_" + newObj.Id;
                            await repository.Update(newObj);
                        }
                        var novaticResponse = NovaticResponse.CREATED(newObj);
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
        public async Task<IActionResult> Update([FromBody]SystemConfig model)
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
        public async Task<IActionResult> Delete([FromBody]SystemConfig model)
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
        public async Task<IActionResult> DeletePermanently([FromBody]SystemConfig model)
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
        [Route("api/ListSlide")]
        public async Task<IActionResult> ListSlide()
        {
            try
            {
                var dataList = await repository.ListSlide();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var dataViewModel = new List<SystemConfigViewModel>();
                foreach (var item in dataList)
                {
                    var objViewModel = new SystemConfigViewModel();
                    objViewModel.Id = item.Id;
                    objViewModel.Active = item.Active;
                    objViewModel.Name = item.Name;
                    objViewModel.Code = item.Code;
                    objViewModel.CreatedTime = item.CreatedTime;
                    objViewModel.Description = item.Description;
                    //Lọc chuỗi json
                    var JsonSlide = new List<SlideViewModdel>();
                    JsonSlide = JsonConvert.DeserializeObject<List<SlideViewModdel>>(item.Description);
                    objViewModel.Category = JsonSlide[0].Category;
                    objViewModel.Category2 = JsonSlide[0].Category2;

                    objViewModel.NameSlideTitle = JsonSlide[0].NameSlideTitle;
                    objViewModel.NameSlideTitle2 = JsonSlide[0].NameSlideTitle2;

                    objViewModel.NameSlideContent = JsonSlide[0].NameSlideContent;
                    objViewModel.NameSlideContent2 = JsonSlide[0].NameSlideContent2;

                    objViewModel.SlidePhoto = JsonSlide[0].SlidePhoto;
                    objViewModel.CoverPhoto = JsonSlide[0].CoverPhoto;
                    objViewModel.ListSlideButton = JsonSlide[0].ListSlideButton;
                    dataViewModel.Add(objViewModel);
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataViewModel.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/ListBanner")]
        public async Task<IActionResult> ListBanner(string Banner)
        {
            try
            {
                var dataList = await repository.ListSlide();

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }

                var dataViewModel = new List<SystemConfigViewModel>();
                foreach (var item in dataList)
                {
                    var objViewModel = new SystemConfigViewModel();
                    objViewModel.Id = item.Id;
                    objViewModel.Active = item.Active;
                    objViewModel.Name = item.Name;
                    objViewModel.Code = item.Code;
                    objViewModel.CreatedTime = item.CreatedTime;
                    objViewModel.Description = item.Description;
                    //Lọc chuỗi json
                    var JsonSlide = new List<SlideViewModdel>();
                    JsonSlide = JsonConvert.DeserializeObject<List<SlideViewModdel>>(item.Description);
                    objViewModel.Category = JsonSlide[0].Category;
                    objViewModel.Category2 = JsonSlide[0].Category2;

                    objViewModel.NameSlideTitle = JsonSlide[0].NameSlideTitle;
                    objViewModel.NameSlideTitle2 = JsonSlide[0].NameSlideTitle2;

                    objViewModel.NameSlideContent = JsonSlide[0].NameSlideContent;
                    objViewModel.NameSlideContent2 = JsonSlide[0].NameSlideContent2;

                    objViewModel.SlidePhoto = JsonSlide[0].SlidePhoto;
                    objViewModel.CoverPhoto = JsonSlide[0].CoverPhoto;
                    objViewModel.ListSlideButton = JsonSlide[0].ListSlideButton;
                    dataViewModel.Add(objViewModel);
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataViewModel.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
