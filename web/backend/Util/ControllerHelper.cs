using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

namespace Novatic.Util
{

    public static class ControllerHelper
    {
        /// <summary>
        /// Return logged in user info
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetLoggedInUserInfo(this ControllerBase controller, string key)
        {
            try
            {
                if (controller.HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    return identity.FindFirst(key)?.Value;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int GetLoggedInUserId(this ControllerBase controller)
        {
            return Convert.ToInt32(GetLoggedInUserInfo(controller, "Id"));
        }


        public static int GetLoggedInAccountTypeId(this ControllerBase controller)
        {
            return Convert.ToInt32(GetLoggedInUserInfo(controller, "AccountTypeId"));
        }
    }
}
