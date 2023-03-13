
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using A2F.Util;
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using Novatic.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novatic.Services;
using System.Configuration;
using System.Security.Principal;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Novatic.Models.CRM;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        IAccountRepository repository;
        IShopRepository shopRepository;
        IOrdersRepository orderRepository;
        INotificationRepository notificationRepository;
        ISystemConfigRepository repositorySystemConfig;
        IConfiguration configuration;
        ITokenService tokenService;

        public AccountController(
            ICacheHelper cacheHelper,
            ISystemConfigRepository _repositorySystemConfig,
            IAccountRepository _repository,
            IOrdersRepository _orderRepository,
            IShopRepository _shopRepository,
            INotificationRepository _notificationRepository,
            ITokenService _tokenService,
            IConfiguration _configuration) : base(cacheHelper)
        {
            repository = _repository;
            configuration = _configuration;
            shopRepository = _shopRepository;
            orderRepository = _orderRepository;
            notificationRepository = _notificationRepository;
            tokenService = _tokenService;
            repositorySystemConfig = _repositorySystemConfig;
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

                    List<AccountViewModel> AccountDataList = await repository.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    UserTypeID = accountObj.AccountTypeID;
                }            
            }
            catch (Exception) { throw; }

            // kiểm tra nếu không phải admin thì điều hướng 403
            if (UserTypeID != SystemConstant.ACCOUNT_TYPE_SYSTEM_ADMIN  && UserTypeID != SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER)
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
        [Route("admin/detail")]
        public async Task<IActionResult> DetailAccount()
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

                    List<AccountViewModel> AccountDataList = await repository.Detail(UserID);
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

                var dataList = new List<AccountViewModel>();
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
                    var dataOrder = await orderRepository.ListByShopId(shopId);

                    for (int i = 0; i < dataListTotal.Count; i++)
                    {
                        //only count End user
                        if(dataListTotal[i].AccountTypeID != SystemConstant.ACCOUNT_TYPE_END_USER)
                        {
                            continue;
                        }

                        for (int j = 0; j < dataOrder.Count; j++)
                        {
                            if (dataListTotal[i].Id == dataOrder[j].AccountId)
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
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("api/Detail")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Detail()
        {

            string UserIdSessionString = this.GetLoggedInUserId().ToString();
            int? AccountId = Convert.ToInt32(UserIdSessionString);
            try
            {
                var dataList = await repository.Detail(AccountId);

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
        public async Task<IActionResult> Add([FromBody] Account model)
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
                model.CreatedTime = DateTime.Now;

                //2. add new object
                try
                {
                    var checkEmailObj = await repository.CheckEmailExist(model);
                    var checkUsernameObj = await repository.CheckUsernameExist(model);
                    if (checkEmailObj != null && checkEmailObj.Count != 0)
                    {
                        var ExistEmailObj = NovaticResponse.EmailExist(checkEmailObj);
                        return Ok(ExistEmailObj);
                    }
                    if (checkUsernameObj != null && checkUsernameObj.Count != 0)
                    {
                        var ExistUsernameObj = NovaticResponse.UsernameExist(checkUsernameObj);
                        return Ok(ExistUsernameObj);
                    }
                    //model.Photo = "https://adbin.in/wp-content/uploads/2017/03/user.png";

                    // Mã hóa mật khẩu bằng SHA256
                    string Password = SecurityUtil.ComputeSha256Hash(model.Password);
                    model.Password = Password;
                    var newObj = await repository.Add(model);


                    if (newObj.Id > 0)
                    {
                        try
                        {

                            string emailAndUsername = newObj.Email + "&&&" + newObj.Username;
                            emailAndUsername = NovaticUtil.Base64Encode(emailAndUsername);
                            emailAndUsername = "https://a2f.business.gov.vn/account/api/confirmEmail/" + emailAndUsername;

                            string body = EmailUtil.RegisterSendEmail(newObj.Username, emailAndUsername);
                            EmailUtil.SendEmail(newObj.Email, "Chào mừng bạn đến với Website A2F", body);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    else
                    {
                        return NotFound();
                    }
                    var novaticResponse = NovaticResponse.CREATED(model);
                    return Created("", novaticResponse);

                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/Update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Update([FromBody] Account model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 


                    //2. update object
                    await repository.Update(model);
                    // logic add notification
                    Notification notification = new Notification();
                    notification.Active = 1;
                    notification.Description = "update information successfull";
                    notification.CreatedTime = DateTime.Now;
                    notification.AccountId = model.Id;
                    notification.SenderId = 0 ;
                    notification.Name = model.Name;
                    notification.NotificationStatusId = 1000002;
                    await notificationRepository.Add(notification);

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
        [Route("api/UpdateAccountVip")]
        public async Task<IActionResult> UpdateAccountVip([FromBody] Account model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //1. business logic 

                    //2. update object
                    await repository.UpdateAccountVip(model);

                    var dataList = await repository.Detail(model.Id);

                    if (dataList == null || dataList.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        try
                        {
                            //Send email
                            var client = new SmtpClient("smtp.gmail.com", 587)
                            {
                                Credentials = new NetworkCredential(EmailUtil.EMAIL_CREDENTIAL_NAME, EmailUtil.EMAIL_CREDENTIAL_PASSWORD),
                                EnableSsl = true
                            };

                            string body = EmailUtil.UpdateAccountVipSendEmail(dataList[0].Username, dataList[0].Name);

                            MailMessage msg = new MailMessage(EmailUtil.EMAIL_CREDENTIAL_NAME, dataList[0].Email, "Chào mừng bạn đến với website Gapping World", body);
                            msg.IsBodyHtml = true;

                            client.Send(msg);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }

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
        public async Task<IActionResult> Delete([FromBody] Account model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] Account model)
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

        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] Account model)
        {
            if (model.Username.Length == 0 || model.Password.Length == 0)
            {
                return BadRequest();
            }

            try
            {
                var dataList = await repository.Login(model);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    string pass = SecurityUtil.ComputeSha256Hash(model.Password);
                    if (dataList[0].Password == pass)
                    {
                        if (dataList[0].Active == 1 && dataList[0].IsActivated == 1)
                        {


                            //190822 Harry add token logic
                            // account is valid, generate token
                            var key = configuration.GetValue<string>("Jwt:Key");
                            var issuer = configuration.GetValue<string>("Jwt:Issuer");
                            // remove password 

                            var account = new Account();
                            account.Id = dataList[0].Id;
                            account.Name = dataList[0].Name;
                            account.AccountTypeId = dataList[0].AccountTypeID;

                            //account.Password = string.Empty;
                            var token = tokenService.BuildToken(key, issuer, account);
                            //return NovaticResponse.SUCCESS(new LoginViewModel()
                            //{
                            //    Id = account.Id,
                            //    Name = account.Name,
                            //    Token = token,
                            //    Phone = account.Phone,
                            //    Photo = string.IsNullOrEmpty(account.Photo) ? SystemConstant.IMAGE_DEFAULT : account.Photo,
                            //    Email = account.Email
                            //});
                            dataList[0].Photo = string.IsNullOrEmpty(account.Photo) ? SystemConstant.IMAGE_DEFAULT : account.Photo;
                            dataList[0].Password = token;
                            //190822 Harry add token logic ends



                            var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                            HttpContext.Session.SetString("UserID", dataList[0].Id.ToString());
                            HttpContext.Session.SetString("AccountTypeID", dataList[0].AccountTypeID.ToString());
                            Notification notification = new Notification();
                            notification.Active = 1;
                            notification.Description = "login successfull";  
                            notification.CreatedTime = DateTime.Now;
                            notification.AccountId = model.Id;
                            notification.SenderId = 0;
                            notification.Name = model.Name;
                            notification.NotificationStatusId = 1000002;
                            await notificationRepository.Add(notification);
                            return Ok(novaticResponse);
                        }
                        else if (dataList[0].IsActivated == 0)
                        {
                            var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                            return Ok(novaticResponse);
                        }
                        else
                        {
                            return BadRequest();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return NotFound();
        }


        [HttpPost]
        [HttpGet]
        [Route("api/CheckExist")]
        public async Task<IActionResult> CheckExist([FromBody] Account model)
        {
            if (model.Username.Length < 6 || model.Email.Length < 6 || model.Phone.Length < 10)
            {
                return BadRequest();
            }
            try
            {
                int temp = 0;
                var dataList = await repository.List();
                var dataListExist = await repository.Login(model);
                if (dataListExist.Count == 0)
                {
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        if (model.Username == dataList[i].Username)
                        {
                            temp = 1;
                            break;
                        }
                        else if (model.Phone == dataList[i].Phone)
                        {
                            temp = 1;
                            break;
                        }
                        else if (model.Email == dataList[i].Email)
                        {
                            temp = 1;
                            break;
                        }
                    }
                    if (temp == 1)
                    {
                        var novaticResponse = NovaticResponse.SUCCESS(model);
                        return Ok(novaticResponse);
                    }
                    else
                    {
                        var novaticResponse2 = NovaticResponse.Faild();
                        return Ok(novaticResponse2);
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("api/ChangePassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword([FromBody] Account model)
        {
            if (ModelState.IsValid)
            {
                int UserID = 0;
                try
                {
                    //1. business logic 
                    //string UserIDSession = HttpContext.Session.GetString("UserID");
                    string UserIDSession = this.GetLoggedInUserId().ToString();
                    if (UserIDSession != null && UserIDSession != "")
                    {
                        UserID = Convert.ToInt32(UserIDSession);

                        List<Account> dataList = await repository.DetailAccount(UserID);
                        var obj = dataList[0];

                        //lưu tạm password cũ vào description
                        if (SecurityUtil.ComputeSha256Hash(model.Description) == obj.Password)
                        {
                            obj.Password = SecurityUtil.ComputeSha256Hash(model.Password);

                            await repository.Update(obj);

                            var novaticResponse = NovaticResponse.SUCCESS(model);
                            return Ok(novaticResponse);
                        }

                        if (model.Description != obj.Password)
                        {
                            var novaticResponse = NovaticResponse.SUCCESS(model);
                            novaticResponse.message = "INCORRECT";
                            return Created("", novaticResponse);
                        }
                    }


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
        [Route("api/ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] Account model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == null)
                {
                    return BadRequest();
                }
                try
                {
                    //1. business logic 
                    List<Account> AccountDataList = await repository.DetailByEmail(model.Email);
                    if (AccountDataList.Count > 0 && model.Email == AccountDataList[0].Email)
                    {
                        try
                        {
                            var client = new SmtpClient("smtp.gmail.com")
                            {
                                Credentials = new NetworkCredential(EmailUtil.EMAIL_CREDENTIAL_NAME, EmailUtil.EMAIL_CREDENTIAL_PASSWORD),
                                EnableSsl = true
                            };

                            string body = EmailUtil.ForgotPassword(AccountDataList[0].Username, AccountDataList[0].Password, AccountDataList[0].Name);

                            MailMessage msg = new MailMessage(EmailUtil.EMAIL_CREDENTIAL_NAME, AccountDataList[0].Email, "Thông tin đăng nhập website A2F", body);
                            msg.IsBodyHtml = true;

                            client.Send(msg);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        var novaticResponse = NovaticResponse.SUCCESS(model);
                        return Ok(novaticResponse);

                    }
                    else
                    {
                        var novaticResponse = NovaticResponse.SUCCESS(model);
                        novaticResponse.message = "EMAIL_INCORRECT";
                        return Created("", novaticResponse);
                    }

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
        [Route("api/LoginSocialNetWork")]
        public async Task<IActionResult> LoginSocialNetWork([FromBody] Account model)
        {
            var dataList = await repository.List();
            int temp = 0;
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i].Email == model.Email && dataList[i].Active == 1)
                {
                    temp = 1;
                    var novaticResponse = NovaticResponse.SUCCESS(dataList[i]);
                    HttpContext.Session.SetString("UserID", dataList[i].Id.ToString());
                    return Ok(novaticResponse);
                }
                else
                {
                    temp = 0;
                }
            }
            if (temp == 0)
            {
                int tempName = 10;
                for (int i = 0; i < dataList.Count; i++)
                {
                    if (dataList[i].Username == model.Username)
                    {
                        model.Username = model.Username + tempName;
                        tempName += 1;
                        i = 0;
                    }
                }
                model.Password = NovaticUtil.RandomString(8);
                model.IsActivated = 1;
                var newObj = await repository.Add(model);
                if (newObj.Id > 0)
                {
                    var novaticReponse = NovaticResponse.SUCCESS(newObj);
                    HttpContext.Session.SetString("UserID", newObj.Id.ToString());
                    return Ok(novaticReponse);
                }
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("api/Count")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public int CountAccount()
        {
            int result = repository.CountAccount();
            return result;
        }

        [HttpGet]
        [Route("api/ConfirmEmail/{emailAndUsername}")]
        public async Task<IActionResult> ConfirmEmail(string emailAndUsername)
        {
            if (emailAndUsername.Length == 0) return BadRequest();
            try
            {
                //xử lý chuỗi nhập vào
                string temp = NovaticUtil.Base64Decode(emailAndUsername);
                string email = temp.Substring(0, temp.IndexOf("&"));
                string username = temp.Substring(temp.LastIndexOf("&") + 1, temp.Length - 3 - email.Length);

                var dataList = await repository.DetailByEmail(email);
                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }
                if (dataList[0].IsActivated == 0)
                {
                    dataList[0].IsActivated = 1;
                    await repository.Update(dataList[0]);
                }
                return Redirect("https://a2f.business.gov.vn/");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //[HttpGet]
        //[Route("api/AutoDowngradeAccount")]
        //public async Task<IActionResult> AutoDowngradeAccount()
        //{
        //    try
        //    {
        //        var listAccount = await repository.ListAccount();
        //        DateTime currentDateTime = DateTime.Now;
        //        for (int i = 0; i < listAccount.Count; i++)
        //        {
        //            if (listAccount[i].Description.Length != 0)
        //            {
        //                DateTime endMembership = Convert.ToDateTime(listAccount[i].Description);
        //                int res = DateTime.Compare(endMembership, currentDateTime);
        //                if (res < 0)
        //                {
        //                    var account = await repository.DetailAccount(listAccount[i].Id);
        //                    var objUpdating = account[0];
        //                    objUpdating.Description = "";
        //                    objUpdating.AccountTypeId = 10002;
        //                    await repository.Update(objUpdating);
        //                }
        //            }
        //        }

        //        List<Account> dataList = new List<Account>();
        //        var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
        //        return Ok(novaticResponse);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet]
        //[Route("api/RegisterWithGoogle")]
        //public IActionResult RegisterWithGoogle(string returnUrl, int accountTypeId)
        //{
        //    return new ChallengeResult(
        //        GoogleDefaults.AuthenticationScheme,
        //        new AuthenticationProperties
        //        {
        //            RedirectUri = Url.Action(nameof(LoginCallback), new { returnUrl, accountTypeId })
        //        });
        //}

        //public async Task<IActionResult> LoginCallback(string returnUrl, int accountTypeId)
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync("External");

        //    if (!authenticateResult.Succeeded)
        //        return BadRequest(); // TODO: Handle this better.

        //    var claimsIdentity = new ClaimsIdentity("Application");

        //    claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier));
        //    claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Email));
        //    claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Name));
        //    await HttpContext.SignInAsync(
        //        "Application",
        //        new ClaimsPrincipal(claimsIdentity));
        //    //Sau khi google trả response lập tức insert vào db
        //    string Password = "Abc123456";
        //    var obj = new Account();
        //    if (accountTypeId == 0)
        //    {
        //        accountTypeId = 10002;
        //    }
        //    obj.AccountTypeId = accountTypeId;
        //    obj.Active = 1;
        //    obj.Name = claimsIdentity.Claims.ToList()[2].Value;
        //    obj.Email = claimsIdentity.Claims.ToList()[1].Value;
        //    obj.Username = claimsIdentity.Claims.ToList()[1].Value;
        //    obj.Password = SecurityUtil.ComputeSha256Hash(Password);
        //    obj.Phone = "";
        //    obj.Address = "";
        //    obj.Photo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSgiBXKS7_rYOPdUxh1W9sSbmg-0y5MeIxXQImvfmGmRvjz5q-&s";
        //    obj.Description = "";
        //    obj.Info = "";
        //    obj.IsActivated = 1;
        //    obj.IdCardNumber = "";
        //    obj.CompanyNumber = "";
        //    obj.CompanyName = "";
        //    obj.CompanyInfo = "";
        //    obj.GoogleId = claimsIdentity.Claims.ToList()[0].Value;
        //    obj.FacebookId = "";
        //    obj.CreatedTime = DateTime.Now;
        //    //Trước khi add kiểm tra xem đã tồn tại email trong hệ thống hay chưa
        //    var listAccount = await repository.List();
        //    var findObj = listAccount.FindAll(x => x.Email == obj.Email);
        //    //Nếu đã tồn tại thì đăng nhập
        //    if (findObj.Count > 0)
        //    {
        //        //Chỗ này fake số điện thoại
        //        obj.Phone = "1111111111";
        //        var dataList = await repository.Login(obj);
        //        if (dataList == null || dataList.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            if (dataList[0].GoogleId == obj.GoogleId || dataList[0].Email == obj.Email)
        //            {
        //                if (dataList[0].Active == 1 && dataList[0].IsActivated == 1)
        //                {
        //                    var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());

        //                    HttpContext.Session.SetString("UserID", dataList[0].Id.ToString());
        //                    return Redirect(returnUrl);

        //                }
        //                else if (dataList[0].IsActivated == 0)
        //                {
        //                    var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
        //                    return Redirect(returnUrl);
        //                }
        //                else
        //                {
        //                    return BadRequest();
        //                }

        //            }
        //        }
        //    }
        //    else
        //    {
        //        var result = await repository.Add(obj);
        //        result.Phone = "1111111111";
        //        var dataList = await repository.Login(result);
        //        if (dataList == null || dataList.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            if (dataList[0].GoogleId == result.GoogleId || dataList[0].Email == result.Email)
        //            {
        //                if (dataList[0].Active == 1 && dataList[0].IsActivated == 1)
        //                {
        //                    var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());

        //                    HttpContext.Session.SetString("UserID", dataList[0].Id.ToString());
        //                    return Redirect(returnUrl);

        //                }
        //                else if (dataList[0].IsActivated == 0)
        //                {
        //                    var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
        //                    return Redirect(returnUrl);
        //                }
        //                else
        //                {
        //                    return BadRequest();
        //                }

        //            }
        //        }
        //    }
        //    return Redirect(returnUrl);
        //}

        //[HttpGet]
        //[Route("api/LoginWithFaceBook")]
        //public async Task<IActionResult> LoginWithFaceBook(string userID, string name, string photo,string height, string width ,string ext, string hash, string email, int accountTypeId,string returnUrl)
        //{
        //    string Password = "Abc123456";
        //    var obj = new Account();
        //    if (email == null)
        //    {
        //        obj.Email = "";
        //    }
        //    else
        //    {
        //        obj.Email = email;
        //    }
        //    if(accountTypeId == 0)
        //    {
        //        accountTypeId = 10002;
        //    }
        //    obj.AccountTypeId = accountTypeId;
        //    obj.Active = 1;
        //    obj.Name = name;
        //    obj.Username = userID;
        //    obj.Password = SecurityUtil.ComputeSha256Hash(Password);
        //    obj.Phone = "";
        //    obj.Address = "";
        //    obj.Photo = photo + "&height=" + height + "&width=" + width + "&ext=" + ext + "&hash=" + hash;
        //    obj.Description = "";
        //    obj.Info = "";
        //    obj.IsActivated = 1;
        //    obj.IdCardNumber = "";
        //    obj.CompanyNumber = "";
        //    obj.CompanyName = "";
        //    obj.CompanyInfo = "";
        //    obj.GoogleId = "";
        //    obj.FacebookId = userID;
        //    obj.CreatedTime = DateTime.Now;

        //    //Trước khi add kiểm tra xem đã tồn tại email trong hệ thống hay chưa
        //    var listAccount = await repository.List();
        //    var findObj = listAccount.FindAll(x => x.FacebookId == userID);
        //    //Nếu đã tồn tại thì đăng nhập
        //    if (findObj.Count > 0)
        //    {
        //        //Chỗ này fake số điện thoại
        //        obj.Phone = "1111111111";
        //        var dataList = await repository.Login(obj);
        //        if (dataList[0].FacebookId == obj.FacebookId)
        //        {
        //            if (dataList[0].Active == 1 && dataList[0].IsActivated == 1)
        //            {
        //                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());

        //                HttpContext.Session.SetString("UserID", dataList[0].Id.ToString());
        //                return Redirect(returnUrl);

        //            }
        //            else if (dataList[0].IsActivated == 0)
        //            {
        //                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
        //                return Redirect(returnUrl);
        //            }
        //            else
        //            {
        //                return BadRequest();
        //            }

        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var result = await repository.Add(obj);
        //            result.Phone = "1111111111";
        //            var dataList = await repository.Login(result);
        //            if (dataList == null || dataList.Count == 0)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                if (dataList[0].FacebookId == result.FacebookId)
        //                {
        //                    if (dataList[0].Active == 1 && dataList[0].IsActivated == 1)
        //                    {
        //                        var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());

        //                        HttpContext.Session.SetString("UserID", dataList[0].Id.ToString());
        //                        return Redirect(returnUrl);

        //                    }
        //                    else if (dataList[0].IsActivated == 0)
        //                    {
        //                        var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
        //                        return Redirect(returnUrl);
        //                    }
        //                    else
        //                    {
        //                        return BadRequest();
        //                    }

        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            throw;
        //        }
               
        //    }
        //    return Redirect(returnUrl);
        //}



        //[HttpGet]
        //[Route("api/SendEmailRegisterAED")]
        //public async Task<IActionResult> SendEmailRegisterAED()
        //{
        //    try
        //    {
        //        var dataList = await repository.List();

        //        if (dataList == null || dataList.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        for (int i = 0; i < dataList.Count; i++)
        //        {
        //            var item = dataList[i];
        //            if(item.AccountTypeID == 10002 || item.AccountTypeID == 10003)
        //            {
        //                string body = EmailUtil.SendEmailRegisterAED(item.Username);
        //                EmailUtil.SendEmail(item.Email, "Thông báo điều chỉnh tài khoản A2F", body);
        //            }
        //        }
        //        var novaticResponse = NovaticResponse.SUCCESS();
        //        //var response = Newtonsoft.Json.JsonConvert.SerializeObject(novaticResponse);
        //        return Ok(novaticResponse);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}



    }
}

