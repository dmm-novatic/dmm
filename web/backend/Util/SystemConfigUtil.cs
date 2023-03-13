using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Util
{
    public class SystemConfigUtil
    {
        public static List<SystemConfig> arrayList = new List<SystemConfig>()
        {
            new SystemConfig(10001,1,"Logo Header","LOGO_HEADER","/files/frontend/images/core/LOGO-gw.png"),
            new SystemConfig(10002,1,"Logo Mobile","LOGO_MOBILE","/files/frontend/images/core/LOGO-gw.png"),
            new SystemConfig(10003,1,"Logo Canvas","LOGO_CANVAS","/files/frontend/images/core/LOGO-gw.png"),
            new SystemConfig(10004,1,"Logo Sticky","LOGO_STICKY","/files/frontend/images/core/LOGO-gw.png"),
            new SystemConfig(10005,1,"Logo Footer","LOGO_FOOTER","/files/frontend/images/core/LOGO-gw.png"),
            new SystemConfig(10006,1,"Link Facebook","LINK_FACEBOOK","https://www.facebook.com/novaticvn"),
            new SystemConfig(10007,1,"Link Twitter","LINK_TWITTER","https://www.facebook.com/novaticvn"),
            new SystemConfig(10008,1,"Link Google","LINK_GOOGLE","https://www.facebook.com/novaticvn"),
            new SystemConfig(10009,1,"Link Author Facebook","LINK_AUTHOR_FACEBOOK","https://www.facebook.com/novaticvn"),
            new SystemConfig(10010,1,"Link Author Twitter","LINK_AUTHOR_TWITTER","https://www.facebook.com/novaticvn"),
            new SystemConfig(10011,1,"Link Author Instagram","LINK_AUTHOR_INSTAGRAM","https://www.facebook.com/novaticvn"),
            new SystemConfig(10012,1,"Topic background photo","TOPIC_BACKGROUND_PHOTO","https://c.pxhere.com/images/a4/a4/d2d1da7ba0e89df2d5dd262afcb6-1593619.jpg!d"),
            new SystemConfig(10013,1,"Video background photo","VIDEO_BACKGROUND_PHOTO","https://c.pxhere.com/images/a4/a4/d2d1da7ba0e89df2d5dd262afcb6-1593619.jpg!d"),
            new SystemConfig(10014,1,"Link Instagram","LINK_INSTAGRAM","https://www.facebook.com/novaticvn"),
            new SystemConfig(10015,1,"Link Author Google","LINK_AUTHOR_GOOGLE","https://www.facebook.com/novaticvn"),
            new SystemConfig(10016,1,"Link Author Youtube","LINK_AUTHOR_YOUTUBE","https://www.facebook.com/novaticvn"),



        };

        public static SystemConfig getSystemConfigbyCode(string code)
        {
            SystemConfig result = new SystemConfig();
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i].Code == code)
                {
                    result = arrayList[i];
                    break;
                }
            }
            return result;
        }

    }
}
