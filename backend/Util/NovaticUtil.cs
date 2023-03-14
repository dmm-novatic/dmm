using A2F.ViewModel;
using Novatic.Models;
using Novatic.Repository;
using Novatic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Util
{
    public class NovaticUtil
    {
        public static string ConvertToURL(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                "d",
                "e","e","e","e","e","e","e","e","e","e","e",
                "i","i","i","i","i",
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                "u","u","u","u","u","u","u","u","u","u","u",
                "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            text = text.Replace(" ", "-");
            text = text.Replace("/", "-");
            text = text.Replace("%", "");
            return text;
        }

        public static List<PostViewModel> ChangePostLanguage(List<PostViewModel> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Text = arrlist[i].Text2;
                    arrlist[i].Description = arrlist[i].Description2;
                    arrlist[i].PostCategoryName = arrlist[i].PostCategoryName2;
                    arrlist[i].Url = arrlist[i].Url2;
                    arrlist[i].PostCategoryURL = ConvertToURL(arrlist[i].PostCategoryName2);
                }
            }
            return arrlist;
        }

        public static List<Survey> ChangeSurveyLanguage(List<Survey> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Description = arrlist[i].Description2;
                }
            }
            return arrlist;
        }
        public static List<SurveyAccount> ChangeSurveyAccountLanguage(List<SurveyAccount> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                }
            }
            return arrlist;
        }

        public static List<Answer> ChangeAnswerLanguage(List<Answer> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Description = arrlist[i].Description2;
                }
            }
            return arrlist;
        }

        public static List<SurveySection> ChangeSurveySectionLanguage(List<SurveySection> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Description = arrlist[i].Description2;
                }
            }
            return arrlist;
        }

        public static List<SurveySectionViewModel> ChangeSurveySectionViewModelLanguage(List<SurveySectionViewModel> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].NameQuestion = arrlist[i].Name2Question;                 
                    arrlist[i].Description = arrlist[i].Description2;
                }
            }
            return arrlist;
        }


        public static List<Menu> ChangeMenuLanguage(List<Menu> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Url = arrlist[i].Url2;
                }
            }
            return arrlist;
        }

        public static List<Tag> ChangeTagLanguage(List<Tag> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Slug = arrlist[i].Slug2;
                }
            }
            return arrlist;
        }

        public static List<PostCategory> ChangeCategoryLanguage(List<PostCategory> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Slug = arrlist[i].Slug2;
                }
            }
            return arrlist;
        }

        public static List<Topic> ChangeTopicLanguage(List<Topic> arrlist, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrlist.Count; i++)
                {
                    arrlist[i].Name = arrlist[i].Name2;
                    arrlist[i].Slug = arrlist[i].Slug2;
                    arrlist[i].Description = arrlist[i].Description2;
                    arrlist[i].Text = arrlist[i].Text2;
                }
            }
            return arrlist;
        }

        public static List<LanguageConfig> ChangeLanguageConfig(List<LanguageConfig> arrList, string langCode)
        {
            if (langCode == "en")
            {
                for (int i = 0; i < arrList.Count; i++)
                {
                    arrList[i].Name = arrList[i].Name2;
                }
            }
            return arrList;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetPostDefaultThumbnailPicture()
        {
            return "https://gappingworld.com/files/frontend/images/core/default.jpg";
        }

        public static string getAllChildrenCategoryID(int ID, List<PostCategory> ListCategory)
        {
            string result = ID + ",";

            for (int i = 0; i < ListCategory.Count; i++)
            {
                if (ListCategory[i].ParentID == ID)
                {
                    //recursive
                    result += getAllChildrenCategoryID(ListCategory[i].Id, ListCategory) + ",";
                }
            }

            return result;

        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
