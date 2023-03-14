using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Novatic.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICacheHelper _cacheHelper;

        public BaseController(ICacheHelper cacheHelper)
        {
            _cacheHelper = cacheHelper;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string ServerURL = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/";

            //VALIDATE REQUEST
            string RequestedURL = filterContext.HttpContext.Request.Path.ToString().ToLower();
            int AccountId = 0;
            int RoleId = 0;
            string UserIDSession = HttpContext.Session.GetString("UserID");
            string RoleIDSession = HttpContext.Session.GetString("RoleID");
            Int32.TryParse(UserIDSession, out AccountId);
            Int32.TryParse(RoleIDSession, out RoleId);
            bool IsValidRequest = SecurityUtil.AuthorizeRequestSimple(RequestedURL, AccountId, RoleId);

            //Điều hướng sang 401 nếu không valid
            if (IsValidRequest == false)
            {
                if (ServerURL.Contains("localhost"))
                {
                    //DEV Mode
                    //filterContext.Result = Unauthorized();
                    IsValidRequest = true;
                    return;
                }
                else
                {
                    filterContext.Result = Unauthorized();
                    return;
                }
            }
            //VALIDATE REQUEST ENDS



            var systemConfigs = _cacheHelper.GetSystemConfig();
            ViewBag.SystemConfigs = systemConfigs;

            //Lấy server URL động
            ViewBag.SystemConfigs["HOMEPAGE_URL"].Description = ServerURL;
        }
    }
}