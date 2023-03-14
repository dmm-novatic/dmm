using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Util
{
    public class SystemConstant
    {
        //accountTypeId
        public static int ACCOUNT_TYPE_SYSTEM_ADMIN = 10001;
        public static int ACCOUNT_TYPE_SHOP_MANAGER = 20001;
        public static int ACCOUNT_TYPE_END_USER = 30001;

        public static string POST_CATEGORYSLUG_CHINH_SACH_TAI_CHINH = "Chinh-sach-tai-chinh";
        public static string POST_CATEGORYSLUG_DOANH_NGHIEP_TAI_CHINH = "Doanh-nghiep-tai-chinh";
        public static string POST_CATEGORYSLUG_VE_CHUNG_TOI = "ve-chung-toi";
        public static string POST_CATEGORYSLUG_PHU_LUC_5 = "phu-luc-5";

        public static int POST_CATEGORY_VE_CHUNG_TOI = 10298;
        public static int POST_CATEGORY_DAO_TAO_NANG_CAO = 10301;
        public static int POST_CATEGORY_DAO_TAO_CO_BAN = 10300;
        public static int POST_CATEGORY_THU_VIEN = 10299;

        public static int POST_CATEGORY_KHAO_SAT_DOANH_NGHIEP_GOOGLEFORM = 10311;
        
        // phụ lục sổ tay
        public static int POST_CATEGORY_BAI_HOC_KINH_NGHIEM = 10305;
        public static int POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 = 10307;
        public static int POST_CATEGORY_HO_SO_PHAP_LY = 10308;
        public static int POST_CATEGORY_HO_SO_HOAT_DONG = 10309;
        public static int POST_CATEGORY_UU_DAI = 10310; 
        public static int POST_CATEGORY_PHU_LUC_5 = 10306;
        // sự kiện xử lí tag
        public static int POST_CATEGORY_SU_KIEN= 10297; 


        public static int QUESTION_TYPE_3_ANSWERS = 1000001;
        public static int QUESTION_TYPE_4_ANSWERS = 1000002;


        public static int SURVEYID_DANH_GIA_TIEP_CAN = 1000001;
        public static int SURVEYID_TAI_CAU_TRUC = 1000002;

        //Dung lượng ảnh lớn nhất tải lên
        public static int MAXIMUM_UPLOAD_IMAGE = 10485760;

        //ENTERPRISEID
        public static int ENTERPRISEID_0 = 1000001;
        public static int ENTERPRISEID_1 = 1000002;
        public static int ENTERPRISEID_2 = 1000003;
        public static int ENTERPRISEID_3 = 1000004;

        //MOMOPAYMENT
        public static string PARTNER_CODE = "MOMOLQRL20220916";
        public static string ACCESS_KEY = "5tGZk3YW2aX0nKHe";
        public static string SECRET_KEY = "Z4mhVbHnEUCQeMNbJldID1adayhtCRYv";
        public static string API_ENDPOINT = "https://test-payment.momo.vn/v2/gateway/api/create";
        public static string RETURN_URL = "http://dmm.novatic.vn/payment";
        public static string NOTIFI_URL = "https://api.dmm.novatic.vn/MomoPayment/api/NotifiURL";


        public static string IMAGE_DEFAULT = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSgiBXKS7_rYOPdUxh1W9sSbmg-0y5MeIxXQImvfmGmRvjz5q-&s";


        public static string SECURITY_KEY_NAME = "novaticSecurityToken";
    }
}
