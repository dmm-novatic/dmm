
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novatic.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        INotificationRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        public NotificationController(INotificationRepository _repository, ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper) : base(cacheHelper)
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
        public async Task<IActionResult> Add([FromBody] Notification model)
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
        public async Task<IActionResult> Update([FromBody] Notification model)
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
        public async Task<IActionResult> Delete([FromBody] Notification model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] Notification model)
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
        public int CountNotification()
        {
            int result = repository.CountNotification();
            return result;
        }

        [HttpGet]
        [Route("api/CountByAccountID")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int CountNotificationbyAcount()
        {
            string UserIDSession = this.GetLoggedInUserId().ToString();
 
            int AccountID = Convert.ToInt32(UserIDSession);
            int result = repository.CountNotificationByAcountID(AccountID);
            return result;
        }

        [HttpGet]
        [Route("api/list/ShowNotificationPaging")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> ShowNotificationPaging( int pageIndex, int pageSize)
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
            int totalPage;
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.GetNotificationsByAcountID(AccountID, pageIndex, pageSize);
                int total = repository.CountNotificationByAcountID(AccountID);
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Không có dữ liệu");
                    return Ok(novaticResponse1);
                }
                totalPage = total / pageSize;
                if (totalPage % pageSize != 0)
                {
                    totalPage = totalPage + 1;
                }

                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList(), totalPage);
                return Ok(novaticResponse);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " - " + e.InnerException);
            }
        }
        [HttpGet]
        [Route("api/list/account")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ShowNotificationByAccountId()
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
                var dataList = await repository.GetNotificationByAccountId(AccountID);
                int total = repository.CountNotificationByAcountID(AccountID);
                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Không có dữ liệu");
                    return Ok(novaticResponse1);
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
        [Route("api/checkingReaded")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> checkingReaded([FromBody] Notification model)
        {

            if (ModelState.IsValid)
            {

                string UserIDSession = this.GetLoggedInUserId().ToString();
                if (UserIDSession == null)
                {
                    var novaticResponse1 = NovaticResponse.BadRequestMessage("đăng nhập để thực hiện chức năng này");
                    return Ok(novaticResponse1);

                }
                int AccountID = Convert.ToInt32(UserIDSession);
                try
                {
                    //1. business logic
                    //set Status to 1000001
                    model.NotificationStatusId = 1000001;

                    //2. logically update object
                    await repository.UpdateStatus(model);

                    var novaticResponse = NovaticResponse.SUCCESS(model);
                    return Ok(novaticResponse);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        var novaticResponse1 = NovaticResponse.NotFoundMesage("Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException");
                        return Ok(novaticResponse1);
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("api/ListNotificationNonReaded")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListNotificationNonReaded()
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

                var dataList = await repository.ListNotification(AccountID);

                if (dataList == null || dataList.Count == 0)
                {
                    var novaticResponse1 = NovaticResponse.NotFoundMesage("Not Found List Notification Non Readed");
                    return Ok(novaticResponse1);
                }


                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
                return Ok(novaticResponse);

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
        [Route("api/CountByNonReaded")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int CountByNonReaded()
        {
            string UserIDSession = this.GetLoggedInUserId().ToString();
            int AccountID = Convert.ToInt32(UserIDSession);
            int result = repository.CountNotificationByNonReaded(AccountID);
            return result;
        }
    }
}
