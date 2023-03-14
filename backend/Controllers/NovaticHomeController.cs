using Novatic.Controllers;
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using A2F.Util;
using Novatic.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2F.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace A2FHome.Controllers
{

    [Route("")]
    [ApiController]
    public class A2FHomeController : BaseController
    {
        private IHostingEnvironment _env;
        private string _dir;
        IPostRepository repository;
        IMenuRepository repositoryMenu;
        IPostCategoryRepository repositoryPostCategory;
        ILanguageConfigRepository repositoryLanguageConfig;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        ITagRepository repositoryTag;
        ITopicRepository repositoryTopic;
        IFavouritePostRepository repositoryFavoritePost;
        ICommentRepository repositoryComment;
        IReadedPostRepository repositoryReadedPost;
        ISurveyRepository repositorySurvey;
        ISurveyAccountRepository repositorySurveyAccount;
        IQuestionRepository repositoryQuestion;
        ISurveySectionAccountRepository repositorySurveySectionAccount;
        IAnswerRepository repositoryAnswer;
        ISurveySectionRepository repositorySurveySection;
        IRecommentRepository repositoryRecomment;


        public A2FHomeController(
            ICacheHelper cacheHelper,
            IPostRepository _repository,
            IMenuRepository _repositoryMenu,
            IPostCategoryRepository _repositoryPostCategory,
            ILanguageConfigRepository _repositoryLanguageConfig,
            ISystemConfigRepository _repositorySystemConfig,
            IAccountRepository _repositoryAccount,
            IFavouritePostRepository _repositoryFavoritePost,
            ITagRepository _repositoryTag,
            ITopicRepository _repositoryTopic,
            ICommentRepository _repositoryComment,
            IReadedPostRepository _repositoryReadedPost,
            ISurveyRepository _repositorySurvey,
            ISurveySectionRepository _repositorySurveySection,
            IQuestionRepository _repositoryQuestion,
            IAnswerRepository _repositoryAnswer,
            ISurveyAccountRepository _repositorySurveyAccount,
            ISurveySectionAccountRepository _repositorySurveySectionAccount,
            IRecommentRepository _repositoryRecomment,
            IHostingEnvironment env
            ) : base(cacheHelper)
        {
            repository = _repository;
            repositoryMenu = _repositoryMenu;
            repositoryPostCategory = _repositoryPostCategory;
            repositoryLanguageConfig = _repositoryLanguageConfig;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositoryTag = _repositoryTag;
            repositoryTopic = _repositoryTopic;
            repositoryFavoritePost = _repositoryFavoritePost;
            repositoryComment = _repositoryComment;
            repositoryReadedPost = _repositoryReadedPost;
            repositorySurvey = _repositorySurvey;
            repositorySurveySection = _repositorySurveySection;
            repositoryQuestion = _repositoryQuestion;
            repositoryAnswer = _repositoryAnswer;
            repositorySurveyAccount = _repositorySurveyAccount;
            repositorySurveySectionAccount = _repositorySurveySectionAccount;
            repositoryRecomment = _repositoryRecomment;

            _env = env;
            _dir = _env.ContentRootPath + "\\wwwroot\\files\\upload\\common\\";
        }

        //Trang chủ
        [HttpGet]
        [Route("signin-facebook")]
        public async Task<IActionResult> Index()
        {
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);


            // load Ảnh động cho slider banner
            List<SystemConfig> SystemConfigList = await repositorySystemConfig.List();
            ViewBag.SystemConfigList = SystemConfigList;
            #endregion
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            var listAllEvent = await repository.ListAllEvent();
            if (listAllEvent != null && listAllEvent.Count > 0)
            {
                ViewBag.listAllEvent = listAllEvent;
            }
            List<PostViewModel> listPostEventAboutToStartSoon = new List<PostViewModel>();
            List<PostViewModel> listPostEventIsGoingOn = new List<PostViewModel>();
            List<PostViewModel> listPostEventEnded = new List<PostViewModel>();
            var SumEvent = listAllEvent.Count;
            ViewBag.SumEvent = SumEvent;
            for (int i = 0; i < listAllEvent.Count; i++)
            {
                if (DateTime.Now < listAllEvent[i].OpenTime)
                {
                    listPostEventAboutToStartSoon.Add(listAllEvent[i]);
                }
                else if (listAllEvent[i].OpenTime < DateTime.Now && DateTime.Now < listAllEvent[i].ClosedTime)
                {
                    listPostEventIsGoingOn.Add(listAllEvent[i]);
                }
                else if (DateTime.Now > listAllEvent[i].ClosedTime)
                {
                    listPostEventEnded.Add(listAllEvent[i]);
                }
            }
            ViewBag.listPostEventAboutToStartSoon = NovaticUtil.ChangePostLanguage(listPostEventAboutToStartSoon, lang);
            ViewBag.listPostEventIsGoingOn = NovaticUtil.ChangePostLanguage(listPostEventIsGoingOn, lang);
            ViewBag.listPostEventEnded = NovaticUtil.ChangePostLanguage(listPostEventEnded, lang);
            var ListAllNew = await repository.List();
            var list5HottestNew = new List<PostViewModel>();
            int stop = 0;
            for (int i = 0; i < ListAllNew.Count; i++)
            {
                if (stop <= 4)
                {
                    if (ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5 && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                        && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI
                        && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                        && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_VE_CHUNG_TOI && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN
                        && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO
                        && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_KHAO_SAT_DOANH_NGHIEP_GOOGLEFORM
                        )

                    {
                        list5HottestNew.Add(ListAllNew[i]);
                        stop++;
                    }
                }
                else if (stop > 4)
                {
                    break;
                }
            }


            if (list5HottestNew != null && list5HottestNew.Count > 0)
            {
                ViewBag.list5HottestNew = NovaticUtil.ChangePostLanguage(list5HottestNew, lang);
            }
            List<PostViewModel> listNewsOfficialFinancialPolicies = await repository.ListCategory(SystemConstant.POST_CATEGORYSLUG_CHINH_SACH_TAI_CHINH);
            if (listNewsOfficialFinancialPolicies != null && listNewsOfficialFinancialPolicies.Count > 0)
            {

                var list4NewsOfficialFinancialPolicies = listNewsOfficialFinancialPolicies.Take(5).ToList();
                ViewBag.list4NewsOfficialFinancialPolicies = NovaticUtil.ChangePostLanguage(list4NewsOfficialFinancialPolicies, lang);
            }

            List<PostViewModel> listNewsCorporateandFinancial = await repository.ListCategory(SystemConstant.POST_CATEGORYSLUG_DOANH_NGHIEP_TAI_CHINH);
            if (listNewsCorporateandFinancial != null && listNewsCorporateandFinancial.Count > 0)
            {
                var list4NewsCorporateandFinancial = listNewsCorporateandFinancial.Take(5).ToList();
                ViewBag.list4NewsCorporateandFinancial = NovaticUtil.ChangePostLanguage(list4NewsCorporateandFinancial, lang);
            }
            listAllEvent = await repository.ListAllEvent();
            if (listAllEvent != null && listAllEvent.Count > 0)
            {
                listAllEvent = listAllEvent.Take(3).ToList();
                ViewBag.listAllEvent = NovaticUtil.ChangePostLanguage(listAllEvent, lang);
            }
            int parrentCategory = 10299;
            var objParrentCategory = await repositoryPostCategory.Detail(parrentCategory);
            ViewBag.objParrentCategory = NovaticUtil.ChangeCategoryLanguage(objParrentCategory, lang);
            var listChildLibrary = await repositoryPostCategory.ListbyParentId(10299);
            //Load theo danh mục của thư viện
            #region
            var listLibrary = new List<PostViewModel>();
            //Kiểm tra nếu có danh mục con
            for (int i = 0; i < listChildLibrary.Count; i++)
            {
                var listLibraryChild = await repository.ListAllLibraryChild(listChildLibrary[i].Id);
                for (int j = 0; j < listLibraryChild.Count; j++)
                {
                    var item = new PostViewModel();
                    item = listLibraryChild[j];
                    if (listLibraryChild[j].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM)
                    {
                        listLibrary.Add(item);
                    }

                }
            }
            ViewBag.list5library = JsonConvert.SerializeObject(NovaticUtil.ChangePostLanguage(listLibrary.Take(5).ToList(), lang));
            ViewBag.listAllLibary = NovaticUtil.ChangePostLanguage(listLibrary.Take(6).ToList(), lang);
            #endregion

            //Load danh sách slide
            #region
            var ListSlide = await repositorySystemConfig.ListSlide();
            var dataSlideViewModel = new List<SystemConfigViewModel>();
            foreach (var item in ListSlide)
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
                objViewModel.NameSlideTitle = JsonSlide[0].NameSlideTitle;
                objViewModel.NameSlideContent = JsonSlide[0].NameSlideContent;
                if (lang == "en")
                {
                    objViewModel.Category = JsonSlide[0].Category2;
                    objViewModel.NameSlideTitle = JsonSlide[0].NameSlideTitle2;
                    objViewModel.NameSlideContent = JsonSlide[0].NameSlideContent2;
                }

                objViewModel.SlidePhoto = JsonSlide[0].SlidePhoto;
                objViewModel.CoverPhoto = JsonSlide[0].CoverPhoto;
                objViewModel.ListSlideButton = JsonSlide[0].ListSlideButton;
                for (int i = 0; i < JsonSlide[0].ListSlideButton.Count; i++)
                {
                    var itemButton = JsonSlide[0].ListSlideButton[i];
                    if (lang == "en")
                    {
                        itemButton.Name = itemButton.Name2;
                    }
                }
                dataSlideViewModel.Add(objViewModel);
            }
            ViewBag.DataSlideViewModel = dataSlideViewModel;
            #endregion
            return View();
        }

        //Trang chủ
        [HttpGet]
        [Route("NewPassword")]
        [Route("tao-mat-khau-moi")]
        public async Task<IActionResult> CreateNewPassWord()
        {
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage();
            ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion           
            return View();
        }

        [HttpGet]
        [Route("admin")]
        [Route("")]
        [Route("home")]
        public async Task<IActionResult> Admin()
        {
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;

                    if (accountObj.AccountTypeID == SystemConstant.ACCOUNT_TYPE_SYSTEM_ADMIN || accountObj.AccountTypeID == SystemConstant.ACCOUNT_TYPE_SHOP_MANAGER)
                    {
                        //Redirect(ViewBag.SystemConfigs["HOMEPAGE_URL"].Description +"Account/admin/list");
                        return Redirect("/account/admin/list");
                    }
                    else
                    {
                        //Redirect(ViewBag.SystemConfigs["403_URL"].Description);
                        return Redirect("/403.html");
                    }

                }
            }
            catch (Exception) { throw; }

            return Redirect("/sign-in");

        }

        [HttpGet]
        [Route("logout2")]
        public IActionResult Logout()
        {
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    HttpContext.Session.SetString("UserID", "");

                }

            }
            catch (Exception) { throw; }

            return Redirect("/");
        }

        //Trang đăng nhập
        [HttpGet]
        [Route("dang-nhap")]
        [Route("Sign-In")]
        public async Task<IActionResult> SignIn()
        {

            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }

            return View();
        }

        //Trang đăng ký
        [HttpGet]
        [Route("dang-ky")]
        [Route("Register")]
        public async Task<IActionResult> Register()
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang quên mật khẩu
        [HttpGet]
        [Route("quen-mat-khau")]
        [Route("Forgetpassword")]
        public async Task<IActionResult> ForgetPassword()
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang New Detail
        [HttpGet]
        [Route("chi-tiet-tin-tuc/{IdString}")]
        [Route("NewDetail/{IdString}")]
        public async Task<IActionResult> NewDetail(string IdString)
        {

            if (IdString == null)
            {
                return RedirectPermanent(ViewBag.SystemConfigs["400_URL"].Description);
            }
            try
            {
                // truyen url post :
                ViewBag.IdString = IdString;

                int UserID = 0;
                int UserTypeID = 0;
                ViewBag.UserTypeID = 0;
                ViewBag.UserID = 0;
                string lang = "vi";
                try
                {
                    //Đa ngôn ngữ
                    #region
                    lang = await SetLanguage();
                    ViewBag.Lang = lang;
                    #endregion

                }
                catch (Exception)
                {
                }
                ViewBag.LanguageCode = lang;

                int Id = Convert.ToInt32(new String(IdString.TakeWhile(Char.IsDigit).ToArray()));
                var dataList = await repository.Detail(Id);

                //Lấy CategorySlugUrl
                var categorySlugObj = await repositoryPostCategory.Detail(dataList[0].PostCategoryId);
                if (categorySlugObj != null && categorySlugObj.Count > 0)
                {
                    ViewBag.categorySlugObj = categorySlugObj;
                }

                dataList = NovaticUtil.ChangePostLanguage(dataList, lang);

                if (dataList == null || dataList.Count == 0)
                {
                    //return NotFound();
                    return RedirectPermanent(ViewBag.SystemConfigs["404_URL"].Description);
                }

                var obj = dataList[0];



                try
                {
                    // Update ViewCount
                    List<Post> ListPostViewCount = await repository.DetailPost(Id);
                    var objPost = ListPostViewCount[0];
                    objPost.ViewCount = obj.ViewCount + 1;
                    await repository.Update(objPost);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    ViewBag.IsLikePost = 0;
                    string UserIDSession = HttpContext.Session.GetString("UserID");
                    if (UserIDSession != null && UserIDSession != "")
                    {
                        UserID = Convert.ToInt32(UserIDSession);

                        List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                        AccountViewModel accountObj = AccountDataList[0];
                        ViewBag.UserID = accountObj.Id;
                        ViewBag.UserTypeID = accountObj.AccountTypeID;
                        ViewBag.Username = accountObj.Username;
                        ViewBag.UserFullname = accountObj.Name;
                        ViewBag.UserPhoto = accountObj.Photo;
                        ViewBag.Email = accountObj.Email;
                        UserTypeID = accountObj.AccountTypeID;

                        ViewBag.UserEmail = accountObj.Email;
                        ViewBag.UserCreatedTime = accountObj.CreatedTime;
                        ViewBag.CurrentUserId = accountObj.Id;
                        ViewBag.CurrentUsername = accountObj.Username;

                        //check user like post
                        List<FavouritePost> FavoritePostData = await repositoryFavoritePost.DetailFromUserIDAndPostID(UserID, Id);
                        if (FavoritePostData.Count == 1 && FavoritePostData[0].Active == 1)
                        {
                            ViewBag.IsLikePost = 1;
                        }

                        // check readedPost
                        List<ReadedPost> ReadedPostData = await repositoryReadedPost.DetailReadedPostByUserIDAndPostID(UserID, Id);
                        if (ReadedPostData.Count == 0)
                        {
                            ReadedPost newObj = new ReadedPost();
                            newObj.PostId = Id;
                            newObj.AccountId = UserID;
                            newObj.Active = 1;
                            newObj.Name = obj.Name;
                            newObj.Description = obj.Description;
                            newObj.CreatedTime = DateTime.Now;
                            await repositoryReadedPost.Add(newObj);
                        }

                    }
                    else
                    {
                        ViewBag.CurrentUserId = 10018;
                        ViewBag.CurrentUsername = "Annomymous";
                    }
                }
                catch (Exception) { throw; }


                //load sau khi đã update viewCount & readedPost
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);

                //you may also like data
                //temporary fix cứng data bằng hàm ListPaging
                List<PostViewModel> YouMayAlsoLikeList = await repository.ListSimilarPost(Id);
                List<PostViewModel> LatestList = await repository.ListPaging(1, 4);
                List<PostViewModel> PopularList = await repository.ListFeaturedPost(3, 1, 5);
                List<PostViewModel> SameCategoryList = await repository.ListPaging(2, 6);
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                List<LanguageConfig> LanguageConfigList = await repositoryLanguageConfig.List();
                List<SystemConfig> SystemConfigList = await repositorySystemConfig.List();
                List<Tag> TagList = await repositoryTag.ListByPostID(Id);
                List<Tag> TagListSlide = await repositoryTag.ListPagingTop(1, 18);
                List<CommentViewModel> ListCommentViewModel = await repositoryComment.ListPagingPost(Id, 1, 20);
                List<CommentViewModel> ListAllComment = await repositoryComment.ListPagingPost(Id, 1, 99999);
                List<PostViewModel> ListVideoSidebar = await repository.ListPostByTemplateID(10008, 1, 5);

                ViewBag.YouMayAlsoLikeList = NovaticUtil.ChangePostLanguage(YouMayAlsoLikeList, lang);
                ViewBag.LatestList = NovaticUtil.ChangePostLanguage(LatestList, lang);
                ViewBag.PopularList = NovaticUtil.ChangePostLanguage(PopularList, lang);
                ViewBag.SameCategoryList = NovaticUtil.ChangePostLanguage(SameCategoryList, lang);
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                ViewBag.LanguageConfigList = NovaticUtil.ChangeLanguageConfig(LanguageConfigList, lang);
                ViewBag.SystemConfigList = SystemConfigList;
                ViewBag.TagList = NovaticUtil.ChangeTagLanguage(TagList, lang);
                ViewBag.TagListSlide = NovaticUtil.ChangeTagLanguage(TagListSlide, lang);
                ViewBag.CurrentPostId = Id;

                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);

                //ViewBag.LanguageCode = lang;
                ViewBag.ListCommentViewModel = ListCommentViewModel;
                ViewBag.ListVideoSidebar = ListVideoSidebar;
                ViewBag.ListAllCommentCount = ListAllComment.Count;

                //List 4 bài viết có lượt xem nhiều nhất (Có ViewCount nhất trong 7 ngày gần đây)
                //Nam 02/12/2021
                var listHottestNews = await repository.ListHottestPost();
                if (listHottestNews != null && listHottestNews.Count > 0)
                {
                    var list4HottestNews = listHottestNews.Take(4).ToList();
                    ViewBag.list4HottestNews = list4HottestNews;
                }

                // List bình luận đã được duyệt ra chi tiết bài viết
                ViewBag.ListAllComment = ListAllComment;


                //if(UserTypeID == 0 && obj.PostPublishStatusId == 2)
                //{
                //    return Redirect("/403.html");
                //}

                return View(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //return BadRequest();
                return RedirectPermanent(ViewBag.SystemConfigs["400_URL"].Description);
            }
        }

        //Trang tin tức
        [HttpGet]
        [Route("tin-tuc")]
        [Route("News")]
        public async Task<IActionResult> News()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            // List 5 bài viết trên cùng
            List<PostViewModel> listPostNewestNews = new List<PostViewModel>();
            var listPost = await repository.List();
            if (listPost != null && listPost.Count > 0)
            {
                for (int i = 0; i < listPost.Count; i++)
                {
                    if (listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_VE_CHUNG_TOI
                        && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_SU_KIEN
                        && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5 && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                        && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI
                        && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                        && listPost[i].PostCategoryId != SystemConstant.POST_CATEGORY_KHAO_SAT_DOANH_NGHIEP_GOOGLEFORM
                        )
                    {
                        listPostNewestNews.Add(listPost[i]);
                    }
                }
            }
            var list5NewestNews = listPostNewestNews.Take(5).ToList();
            ViewBag.list5NewestNews = NovaticUtil.ChangePostLanguage(list5NewestNews, lang);

            //List Category
            List<PostCategory> listCategoryNews = new List<PostCategory>();
            var listCategory = await repositoryPostCategory.List();
            for (int i = 0; i < listCategory.Count; i++)
            {
                if (listCategory[i].Id != SystemConstant.POST_CATEGORY_PHU_LUC_5 && listCategory[i].Id != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                        && listCategory[i].Id != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && listCategory[i].Id != SystemConstant.POST_CATEGORY_UU_DAI
                        && listCategory[i].Id != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && listCategory[i].Id != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                        && listCategory[i].Id != SystemConstant.POST_CATEGORY_VE_CHUNG_TOI && listCategory[i].Id != SystemConstant.POST_CATEGORY_THU_VIEN
                        && listCategory[i].Id != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && listCategory[i].Id != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO
                        && listCategory[i].Id != SystemConstant.POST_CATEGORY_SU_KIEN && listCategory[i].Id != SystemConstant.POST_CATEGORY_KHAO_SAT_DOANH_NGHIEP_GOOGLEFORM)
                {
                    listCategoryNews.Add(listCategory[i]);
                }
            }
            ViewBag.listCategory = NovaticUtil.ChangeCategoryLanguage(listCategoryNews, lang);
            List<PostViewModel> listPostsByCategory = new List<PostViewModel>();
            for (int i = 0; i < listCategoryNews.Count; i++)
            {
                var dataAllPost = await repository.ListCategory(listCategoryNews[i].Slug);
                var datalist4 = dataAllPost.Take(4).ToList();
                for (int j = 0; j < datalist4.Count; j++)
                {
                    listPostsByCategory.Add(datalist4[j]);
                }
            }
            ViewBag.listPostsByCategory = NovaticUtil.ChangePostLanguage(listPostsByCategory, lang);

            //List 5 bài viết nổi bật nhất (Có ViewCount nhất trong 7 ngày gần đây)
            var listHottestNews = await repository.ListHottestPost();
            if (listHottestNews != null && listHottestNews.Count > 0)
            {
                var list5HottestNews = listHottestNews.Take(5).ToList();
                ViewBag.list5HottestNews = NovaticUtil.ChangePostLanguage(list5HottestNews, lang);
            }

            //List 4 bài viết tin tổng hợp
            var listGeneralNews = await repository.ListPaging(1, 4);
            if (listGeneralNews != null && listGeneralNews.Count > 0)
            {
                //if (listGeneralNews[i].PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5 && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                //       && listGeneralNews[i].PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI
                //       && listGeneralNews[i].PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                //       && listGeneralNews[i].PostCategoryId != SystemConstant.POST_CATEGORY_VE_CHUNG_TOI && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN
                //       && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && ListAllNew[i].PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO
                //       )
                ViewBag.listGeneralNews = NovaticUtil.ChangePostLanguage(listGeneralNews, lang);
            }
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang About Us
        [HttpGet]
        [Route("Ve-chung-toi")]
        [Route("AboutUs")]
        public async Task<IActionResult> AboutUs()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            var listPostAboutUs = await repository.ListCategory(SystemConstant.POST_CATEGORYSLUG_VE_CHUNG_TOI);
            if (listPostAboutUs != null && listPostAboutUs.Count > 0)
            {
                //Change content language
                listPostAboutUs = NovaticUtil.ChangePostLanguage(listPostAboutUs, lang);
                ViewBag.listPostAboutUs = listPostAboutUs;
            }
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
                int parrentCategory = 10299;
                var objParrentCategory = await repositoryPostCategory.Detail(parrentCategory);
                ViewBag.objParrentCategory = NovaticUtil.ChangeCategoryLanguage(objParrentCategory, lang);
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang Privacy
        [HttpGet]
        [Route("Chinh-sach-bao-mat")]
        [Route("Privacy")]
        public async Task<IActionResult> Privacy()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            // Kiểm tra đăng nhập           
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang Thông tin tài khoản
        [HttpGet]
        [Route("Thong-tin-tai-khoan")]
        [Route("Account-setting")]
        public async Task<IActionResult> AccountSetting()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }


            if (UserID == 0)
            {
                return RedirectPermanent(ViewBag.SystemConfigs["400_URL"].Description);
            }
            try
            {
                //Lấy thông tin EventRequest
                //var listPostEvent = await repository.ListAllEvent();
                //List<PostViewModel> listPostEventUserJoin = new List<PostViewModel>();
                //var listEventRequestByAccountId = await repositoryEventRequest.ListByAccountId(UserID);
                //if (listEventRequestByAccountId != null && listEventRequestByAccountId.Count > 0)
                //{
                //    for (int i = 0; i < listEventRequestByAccountId.Count; i++)
                //    {
                //        for (int j = 0; j < listPostEvent.Count; j++)
                //        {
                //            if (listEventRequestByAccountId[i].PostId == listPostEvent[j].Id)
                //            {
                //                listPostEventUserJoin.Add(listPostEvent[j]);
                //            }
                //        }
                //    }
                //}
                //ViewBag.listPostEventUserJoin = listPostEventUserJoin;


                var dataList = await repositoryAccount.Detail(UserID);
                if (dataList[0].Photo.Length == 0)
                {
                    dataList[0].Photo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSgiBXKS7_rYOPdUxh1W9sSbmg-0y5MeIxXQImvfmGmRvjz5q-&s";
                }
                var obj = dataList[0];
                return View(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        //Trang Liệt kê các khảo sát
        [HttpGet]
        [Route("Liet-ke-cac-khao-sat")]
        [Route("Survey-list")]
        public async Task<IActionResult> SurveyList()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion

            //List các loại khảo sát
            var listSurvey = await repositorySurvey.List();
            List<Survey> listAllSurvey = new List<Survey>();
            if (listSurvey != null && listSurvey.Count > 0)
            {
                for (int i = 0; i < listSurvey.Count; i++)
                {
                    if (listSurvey[i].SurveyTypeId != 1000003)
                    {
                        listAllSurvey.Add(listSurvey[i]);
                    }
                }
                ViewBag.listSurvey = NovaticUtil.ChangeSurveyLanguage(listAllSurvey, lang);
            }

            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang Liệt kê các kết quả khảo sát
        [HttpGet]
        [Route("Liet-ke-ket-qua-khao-sat/{surveyTypeId}")]
        [Route("Survey-result-list/{surveyTypeId}")]
        public async Task<IActionResult> SurveyResultList(int surveyTypeId)
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion

            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            ViewBag.surveyTypeId = surveyTypeId;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }

                var surveyAccountByUserID = await repositorySurveyAccount.DetailByAccountId(UserID, surveyTypeId);

                if (surveyAccountByUserID == null)
                {
                    //return NotFound();
                }
                ViewBag.surveyAccountByUserID = NovaticUtil.ChangeSurveyAccountLanguage(surveyAccountByUserID, lang);
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang Survey-detail
        [HttpGet]
        [Route("chi-tiet-khao-sat/{surveyId}")]
        [Route("Survey-detail/{surveyId}")]
        public async Task<IActionResult> SurveyDetail(int surveyId)
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            ViewBag.surveyId = surveyId;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            //Xử lý trang
            #region
            //1.Load chi tiết khảo sát
            ViewBag.SurveyId = surveyId;
            var surveyDetailObj = await repositorySurvey.Detail(surveyId);
            if (surveyDetailObj.Count > 0)
            {
                ViewBag.SurveyDetailObj = NovaticUtil.ChangeSurveyLanguage(surveyDetailObj, lang);
            }
            else
            {
                ViewBag.SurveyDetailObjName = "";
            }
            //2.Load survey section theo surveyId
            var listSurveySectionBySurveyId = await repositorySurveySection.ListBySurveyId(surveyId);
            //Danh mục con trong bài khảo sát
            ViewBag.listSurveySectionBySurveyId = NovaticUtil.ChangeSurveySectionLanguage(listSurveySectionBySurveyId, lang);
            if (listSurveySectionBySurveyId.Count > 0)
            {
                var DataListViewModel = new List<SurveySectionViewModel>();
                for (int i = 0; i < listSurveySectionBySurveyId.Count; i++)
                {
                    var itemSurveySection = listSurveySectionBySurveyId[i];
                    //2.1 load danh sách câu hỏi thông qua survey section Id giữa các bảng SurveySectionQuestion & Question
                    var listQuestionBySurveySectionId = await repositoryQuestion.ListQuestionViewModelBySurveySectionId(itemSurveySection.Id);
                    for (int j = 0; j < listQuestionBySurveySectionId.Count; j++)
                    {
                        DataListViewModel.Add(listQuestionBySurveySectionId[j]);
                    }
                }
                ViewBag.DataListViewModel = NovaticUtil.ChangeSurveySectionViewModelLanguage(DataListViewModel, lang);
                //2.2 Load danh sách câu trả lời theo questionId
                var listAnswer = new List<Answer>();
                for (int i = 0; i < DataListViewModel.Count; i++)
                {
                    var listAnwser = await repositoryAnswer.ListByQuestionId(DataListViewModel[i].IdQuestion);
                    for (int j = 0; j < listAnwser.Count; j++)
                    {
                        listAnswer.Add(listAnwser[j]);
                    }
                }
                ViewBag.listAnswer = NovaticUtil.ChangeAnswerLanguage(listAnswer, lang);
            }
            #endregion
            return View();
        }
        [HttpGet]
        [Route("ket-qua-khao-sat/{surveyAccountId}")]
        [Route("Survey-Result/{surveyAccountId}")]
        public async Task<IActionResult> SurveyResult(int surveyAccountId)
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            // Kiểm tra đăng nhập
            ViewBag.surveyAccountId = surveyAccountId;
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            string UserIDSession = HttpContext.Session.GetString("UserID");
            if (UserIDSession != null && UserIDSession != "")
            {
                try
                {
                    // lấy thông tin Account
                    UserID = Convert.ToInt32(UserIDSession);
                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                    ViewBag.Phone = accountObj.Phone;
                    ViewBag.Email = accountObj.Email;
                    ViewBag.CompanyNumber = accountObj.CompanyNumber;
                    ViewBag.CompanyName = accountObj.CompanyName;
                    //1. Lấy thông tin điểm SurveyAccount theo surveyAccountId
                    var surveyAccount = await repositorySurveyAccount.Detail(surveyAccountId);
                    if (surveyAccount != null && surveyAccount.Count > 0)
                    {
                        ViewBag.SurveyAccount = surveyAccount;
                        ViewBag.SurveyAccountFinalScore = Math.Round(surveyAccount[0].Score, 1);
                    }
                    else return BadRequest();


                    //Lấy thông tin loại bài đánh giá
                    var surveyObj = await repositorySurvey.Detail(surveyAccount[0].SurveyId);
                    ViewBag.SurveyObj = surveyObj;



                    var surveyAccountDescription = await repositoryLanguageConfig.Detail(Convert.ToInt32(surveyAccount[0].Description));
                    ViewBag.SurveyAccountDescription = surveyAccountDescription;

                    var surveyAccountText = await repositoryLanguageConfig.Detail(Convert.ToInt32(surveyAccount[0].Text));
                    ViewBag.surveyAccountText = surveyAccountText;

                    if (Convert.ToInt32(UserIDSession) != surveyAccount[0].AccountId)
                    {
                        return BadRequest();
                    }

                    //2.Lấy điểm của từng chương theo % để render vào chart trong bảng SurveySectionAccount
                    var surveySectionAccount = await repositorySurveySectionAccount.ListBySurveyAccountId(surveyAccount[0].Id);
                    if (surveySectionAccount != null && surveySectionAccount.Count > 0)
                    {
                        //2.2 Lấy điểm % theo từng chương
                        for (int i = 0; i < surveySectionAccount.Count; i++)
                        {
                            var item = surveySectionAccount[i];
                            //2.2.1 Lấy chi tiết surveySection theo surveySectionId
                            var objSurveySection = await repositorySurveySection.Detail(Convert.ToInt32(item.Description));
                            if (objSurveySection.Count > 0)
                            {
                                item.Name = objSurveySection[0].Name;
                            }
                            if (surveyAccount[0].SurveyId == SystemConstant.SURVEYID_DANH_GIA_TIEP_CAN)
                            {
                                float maxScoreof1Quesiton = 3;
                                float b = 100;
                                var listQuestionOfSection = await repositoryQuestion.ListQuestionViewModelBySurveySectionId(objSurveySection[0].Id);
                                var maxScore = (listQuestionOfSection.Count * maxScoreof1Quesiton / b * objSurveySection[0].ProportionScore);
                                item.Score = Math.Round((item.Score / maxScore * 100), 0);
                            }
                            else if (surveyAccount[0].SurveyId == SystemConstant.SURVEYID_TAI_CAU_TRUC)
                            {
                                double maxScoreOfSection = 0;
                                var listQuestionOfSection = await repositoryQuestion.ListQuestionViewModelBySurveySectionId(objSurveySection[0].Id);
                                for (int j = 0; j < listQuestionOfSection.Count; j++)
                                {
                                    float maxScoreof1Quesiton = 1;
                                    var item2 = listQuestionOfSection[j];
                                    maxScoreOfSection = maxScoreOfSection + (maxScoreof1Quesiton * item2.ScoreQuestion);
                                }
                                float b = 100;
                                maxScoreOfSection = maxScoreOfSection / b * objSurveySection[0].ProportionScore;


                                item.Score = Math.Round((item.Score / maxScoreOfSection * 100), 0);
                            }
                        }

                        ViewBag.SurveySectionAccountParse = JsonConvert.SerializeObject(surveySectionAccount);
                        ViewBag.SurveySectionAccount = surveySectionAccount;

                    }
                    else return BadRequest();
                    // 3. Lấy điểm chuẩn từng chương để ren vào table
                    var surveySectionAccountNotByPercent = await repositorySurveySectionAccount.ListViewModelBySurveyAccountId(surveyAccount[0].Id);
                    for (int i = 0; i < surveySectionAccountNotByPercent.Count; i++)
                    {
                        var item = surveySectionAccountNotByPercent[i];
                        item.Score = Math.Round(item.Score, 2);
                        //2.2.1 Lấy chi tiết surveySection theo surveySectionId
                        var objSurveySection = await repositorySurveySection.Detail(Convert.ToInt32(item.Description));
                        if (objSurveySection.Count > 0)
                        {
                            item.Name = objSurveySection[0].Name;
                            var recommentList = await repositoryRecomment.ListBySurveySectionId(objSurveySection[0].Id);
                            if (recommentList.Count > 0)
                            {
                                for (int j = 0; j < recommentList.Count; j++)
                                {
                                    var itemRecomment = recommentList[j];
                                    if (itemRecomment.MinScore <= Math.Round(item.Score, 2) && item.Score <= itemRecomment.MaxScore)
                                    {
                                        item.ListRecomment = itemRecomment.Name;
                                    }
                                }
                            }
                        }
                    }
                    ViewBag.SurveySectionAccountNotByPercent = surveySectionAccountNotByPercent;
                }
                catch (Exception e) { throw; }
                return View();
            }
            else return BadRequest();


        }


        //Trang Event
        [HttpGet]
        [Route("Su-kien")]
        [Route("Event")]
        public async Task<IActionResult> Event()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion

            var HaveListEventAboutToStartSoon = 0;
            var listAllEvent = await repository.ListAllEvent();
            if (listAllEvent != null && listAllEvent.Count > 0)
            {
                ViewBag.listAllEvent = NovaticUtil.ChangePostLanguage(listAllEvent, lang);
            }
            List<PostViewModel> listPostEventAboutToStartSoon = new List<PostViewModel>();
            if (listAllEvent != null && listAllEvent.Count > 0)
            {
                for (int i = 0; i < listAllEvent.Count; i++)
                {
                    if (DateTime.Now < listAllEvent[i].OpenTime)
                    {
                        listPostEventAboutToStartSoon.Add(listAllEvent[i]);
                    }
                }
                if (listPostEventAboutToStartSoon.Count > 0)
                {
                    HaveListEventAboutToStartSoon = 1;
                }
                ViewBag.listPostEventAboutToStartSoon = listPostEventAboutToStartSoon;
                ViewBag.listPostEventAboutToStartSoonJson = JsonConvert.SerializeObject(listPostEventAboutToStartSoon);
            }
            ViewBag.HaveListEventAboutToStartSoon = HaveListEventAboutToStartSoon;

            var HaveListEventsIsGoingOn = 0;
            var ListEventsIsGoingOn = await repository.ListEventsIsGoingOnPaging(1, 4);
            if (ListEventsIsGoingOn != null && ListEventsIsGoingOn.Count > 0)
            {
                HaveListEventsIsGoingOn = 1;
                ViewBag.ListEventsIsGoingOn = NovaticUtil.ChangePostLanguage(ListEventsIsGoingOn, lang);
            }
            ViewBag.HaveListEventsIsGoingOn = HaveListEventsIsGoingOn;

            var HavelistEventsEnded = 0;
            var listEventsEnded = await repository.ListEventsEndedPaging(1, 4);
            if (listEventsEnded != null && listEventsEnded.Count > 0)
            {
                HavelistEventsEnded = 1;
                ViewBag.listEventsEnded = NovaticUtil.ChangePostLanguage(listEventsEnded, lang);
            }
            ViewBag.HavelistEventsEnded = HavelistEventsEnded;


            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang FAQ
        [HttpGet]
        [Route("FAQ")]
        public async Task<IActionResult> FAQ()
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang danh gia tai chinh
        [HttpGet]
        [Route("danh-gia-tai-chinh")]
        public async Task<IActionResult> FinancialAssessment()
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

 
        //Trang search result
        [HttpGet]
        [Route("ket-qua-tim-kiem/{keyword}")]
        [Route("SearchResult/{keyword}")]
        public async Task<IActionResult> SearchResult(string keyword)
        {
            if (keyword.Equals("") || keyword.Length == 0 || keyword.Equals(null))
            {
                return RedirectPermanent(ViewBag.SystemConfigs["400_URL"].Description);
            }
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            ViewBag.Keyword = keyword;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
                List<PostViewModel> ListSearchPost = await repository.ListSearchPaging(keyword, 1, 4, 99999);
                List<PostViewModel> getNumberOfSearch = await repository.Search(keyword);
                ListSearchPost = NovaticUtil.ChangePostLanguage(ListSearchPost, lang);
                ViewBag.ListSearchPost = ListSearchPost;
                ViewBag.NumberSearch = getNumberOfSearch.Count;
            }
            catch (Exception) { throw; }
            return View();
        }


        //Trang Library
        [HttpGet]
        [Route("thu-vien")]
        [Route("Library")]
        public async Task<IActionResult> Library(string orderby)
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
                //Load danh mục con theo thư viện
                int parrentCategory = 10299;
                var objParrentCategory = await repositoryPostCategory.Detail(parrentCategory);
                ViewBag.objParrentCategory = NovaticUtil.ChangeCategoryLanguage(objParrentCategory, lang);
                var listChildLibrary = await repositoryPostCategory.ListbyParentId(parrentCategory);
                for (int i = 0; i < listChildLibrary.Count; i++)
                {
                    int countPostByPostCategoryId = repository.CountPost(listChildLibrary[i].Id);
                    listChildLibrary[i].PostCount = countPostByPostCategoryId;
                }
                ViewBag.ListChildLibrary = NovaticUtil.ChangeCategoryLanguage(listChildLibrary, lang);

                //Load theo danh mục của thư viện
                #region
                var listLibrary = new List<PostViewModel>();
                var carousel_image = new List<string>();
                carousel_image.Add("images/hero_3.jpg");
                carousel_image.Add("images/hero_2.jpg");
                carousel_image.Add("images/hero_1.jpg");
                var carousel_name = new List<string>();
                carousel_name.Add("Khóa học đào tạo tài chính kinh tế cơ bản cho doanh nghiệp");
                carousel_name.Add("Khóa học đào tạo tài chính kinh tế nâng cao cho doanh nghiệp");
                carousel_name.Add("Đào tạo ứng phó tại chỗ cho doanh nghiệp SME");
                ViewBag.carousel_image = carousel_image;
                ViewBag.carousel_name = carousel_name;
                //Kiểm tra nếu có danh mục con
                for (int i = 0; i < listChildLibrary.Count; i++)
                {
                    var listLibraryChild = await repository.ListAllLibraryChild(listChildLibrary[i].Id);
                    for (int j = 0; j < listLibraryChild.Count; j++)
                    {
                        var item = new PostViewModel();
                        item = listLibraryChild[j];
                        listLibrary.Add(item);
                    }
                }
                if (orderby != null)
                {
                    if (orderby == "sortbydatedesc")
                    {
                        listLibrary = listLibrary.OrderByDescending(x => x.ViewCount).ToList();
                    }
                    else if (orderby == "sortbydateesc")
                    {
                        listLibrary = listLibrary.OrderBy(x => x.ViewCount).ToList();
                    }
                }
                ViewBag.ListLibrary = NovaticUtil.ChangePostLanguage(listLibrary, lang);
                #endregion
            }
            catch (Exception) { throw; }
            return View();
        }


        //Trang Contact
        [HttpGet]
        [Route("lien-he")]
        [Route("Contact")]
        public async Task<IActionResult> Contact()
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            { //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang Category 
        [HttpGet]
        [Route("danh-muc/{categorySlug}")]
        [Route("Category/{categorySlug}")]
        public async Task<IActionResult> Category(string categorySlug)
        {
            if (categorySlug == null)
            {
                //return BadRequest();
                return RedirectPermanent(ViewBag.SystemConfigs["400_URL"].Description);

            }

            try
            {
                //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion


                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                //you may also like data
                //get categoryID
                List<PostCategory> tempListPC = await repositoryPostCategory.Detail(categorySlug);
                PostCategory objPC = tempListPC[0];


                //get list recursive
                List<PostViewModel> SameCategoryList = await repository.ListCategoryPagingRecursive(objPC.Id, 1, 8, 99999);

                List<PostViewModel> LatestList = await repository.ListPaging(1, 4);
                List<PostViewModel> PopularList = await repository.ListPaging(3, 5);
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);

                List<LanguageConfig> LanguageConfigList = await repositoryLanguageConfig.List();
                List<SystemConfig> SystemConfigList = await repositorySystemConfig.List();

                List<Tag> TagListSlide = await repositoryTag.ListPagingTop(1, 18);
                ViewBag.TagListSlide = NovaticUtil.ChangeTagLanguage(TagListSlide, lang);


                int Id = SameCategoryList[0].PostCategoryId;

                var dataList = await repositoryPostCategory.Detail(Id);
                if (dataList == null || dataList.Count == 0)
                {
                    //return NotFound();
                    return RedirectPermanent(ViewBag.SystemConfigs["404_URL"].Description);
                }

                dataList = NovaticUtil.ChangeCategoryLanguage(dataList, lang);
                var obj = dataList[0];
                ViewBag.Photo = obj.Photo;
                if (obj.ParentID > 0)
                {
                    var objPostCategory = await repositoryPostCategory.Detail(obj.ParentID);
                    ViewBag.Photo = objPostCategory[0].Photo;
                }
                ViewBag.Title = (lang.ToLower() == "vi" ? objPC.Name : objPC.Name2);

                ViewBag.CurrentIDBigest = 99999;
                ViewBag.currentCategorySlug = categorySlug;
                ViewBag.HiddenNextView = 0;
                if (SameCategoryList.Count < 13)
                {
                    ViewBag.HiddenNextView = 1;
                }
                else
                {
                    ViewBag.CurrentIDBigest = SameCategoryList[SameCategoryList.Count - 1].Id;
                }

                //List<PostViewModel> SameAllCategoryList = await repository.ListCategoryPaging((categorySlug, 1, 99999, 99999);
                //ViewBag.SameCategoryListCount = SameAllCategoryList.Count;

                ViewBag.LatestList = NovaticUtil.ChangePostLanguage(LatestList, lang);
                ViewBag.PopularList = NovaticUtil.ChangePostLanguage(PopularList, lang);
                ViewBag.SameCategoryList = NovaticUtil.ChangePostLanguage(SameCategoryList, lang);
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);

                ViewBag.LanguageConfigList = NovaticUtil.ChangeLanguageConfig(LanguageConfigList, lang);
                ViewBag.SystemConfigList = SystemConfigList;

                int UserID = 0;
                ViewBag.UserTypeID = 0;
                ViewBag.UserID = 0;
                try
                {
                    string UserIDSession = HttpContext.Session.GetString("UserID");
                    if (UserIDSession != null && UserIDSession != "")
                    {
                        UserID = Convert.ToInt32(UserIDSession);

                        List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                        AccountViewModel accountObj = AccountDataList[0];
                        ViewBag.UserID = accountObj.Id;
                        ViewBag.UserTypeID = accountObj.AccountTypeID;
                        ViewBag.Username = accountObj.Username;
                        ViewBag.UserFullname = accountObj.Name;
                        ViewBag.UserPhoto = accountObj.Photo;
                    }
                }
                catch (Exception) { throw; }

                return View(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //return BadRequest();
                //return NotFound();
                return RedirectPermanent(ViewBag.SystemConfigs["404_URL"].Description);
            }
        }



        public async Task<string> SetLanguage()
        {
            string lang = HttpContext.Session.GetString("LanguageCode");
            if (lang == null)
            {
                lang = "vi";
            }
            ViewBag.LanguageCode = lang;
            List<LanguageConfig> LanguageConfigList = await repositoryLanguageConfig.List();
            ViewBag.LanguageConfigList = NovaticUtil.ChangeLanguageConfig(LanguageConfigList, lang);
            return lang;
        }

        [HttpGet]
        [Route("tag/{tagSlug}")]
        public async Task<IActionResult> Tag(string tagSlug)
        {
            if (tagSlug == null)
            {
                //return BadRequest();
                return RedirectPermanent(ViewBag.SystemConfigs["400_URL"].Description);

            }
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion

            //you may also like data
            //temporary fix cứng data bằng hàm ListPaging
            List<PostViewModel> ListPostTag = await repository.ListTag(tagSlug);
            List<PostViewModel> SameTagList = await repository.ListTagPaging(tagSlug, 1, 4, 99999);

            if (SameTagList == null || SameTagList.Count == 0)
            {
                //return NotFound();
                return RedirectPermanent(ViewBag.SystemConfigs["404_URL"].Description);
            }

            List<PostViewModel> LatestList = await repository.ListPaging(1, 4);
            List<PostViewModel> PopularList = await repository.ListPaging(3, 5);
            List<LanguageConfig> LanguageConfigList = await repositoryLanguageConfig.List();
            List<SystemConfig> SystemConfigList = await repositorySystemConfig.List();
            List<Tag> TagList = await repositoryTag.DetailBySlug(tagSlug);
            List<Tag> TagListSlide = await repositoryTag.ListPagingTop(1, 18);
            ViewBag.TagListSlide = NovaticUtil.ChangeTagLanguage(TagListSlide, lang);


            List<PostViewModel> SameAllTagList = await repository.ListTagPaging(tagSlug, 1, 999999, 99999);
            ViewBag.SameTagListCount = SameAllTagList.Count;

            ViewBag.CurrentIDBigest = 99999;
            ViewBag.currentTagSlug = tagSlug;
            ViewBag.HiddenNextView = 0;
            if (SameTagList.Count < 10)
            {
                ViewBag.HiddenNextView = 1;
            }
            else
            {
                ViewBag.CurrentIDBigest = SameTagList[SameTagList.Count - 1].Id;
            }
            TagList = NovaticUtil.ChangeTagLanguage(TagList, lang);
            ViewBag.TagName = TagList[0].Name;
            ViewBag.ListSize = ListPostTag.Count;
            ViewBag.LatestList = NovaticUtil.ChangePostLanguage(LatestList, lang);
            ViewBag.PopularList = NovaticUtil.ChangePostLanguage(PopularList, lang);
            ViewBag.ListPostTag = NovaticUtil.ChangePostLanguage(SameTagList, lang);
            ViewBag.LanguageConfigList = NovaticUtil.ChangeLanguageConfig(LanguageConfigList, lang);
            ViewBag.SystemConfigList = SystemConfigList;

            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
            }
            catch (Exception) { throw; }

            return View();

        }
        //Trang chu so tay huong dan
        [HttpGet]
        [Route("so-tay-tai-chinh")]
        [Route("GuideNotebook")]
        public async Task<IActionResult> GuideNotebook()
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            { //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
                var ListLearnedLession = await repository.ListLearnedLesson();
                ViewBag.ListLearnedLession = ListLearnedLession;
                var ListLegalrecords = await repository.ListLegalrecords();
                ViewBag.ListLegalrecords = ListLegalrecords;
                var ListOperationalandfinancialrecords = await repository.ListOperationalandfinancialrecords();
                ViewBag.ListOperationalandfinancialrecords = ListOperationalandfinancialrecords;
                var ListIncentivesformsandpurposesforcapitalfinancing = await repository.ListIncentivesformsandpurposesforcapitalfinancing();
                ViewBag.ListIncentivesformsandpurposesforcapitalfinancing = ListIncentivesformsandpurposesforcapitalfinancing;
                var listSotay = await repositorySystemConfig.ListSotay();
                var link = listSotay[0].Description;
                ViewBag.Sotay = link;
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang About Us
        [HttpGet]
        [Route("Phu-luc-5")]

        public async Task<IActionResult> Phuluc5()
        {
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            //Load Menu
            #region
            List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
            ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
            List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
            ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
            #endregion
            var listPostPhuLuc5 = await repository.ListCategory(SystemConstant.POST_CATEGORYSLUG_PHU_LUC_5);
            if (listPostPhuLuc5 != null && listPostPhuLuc5.Count > 0)
            {
                //Change content language
                listPostPhuLuc5 = NovaticUtil.ChangePostLanguage(listPostPhuLuc5, lang);
                ViewBag.listPostPhuLuc5 = listPostPhuLuc5;
            }
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            {
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
                int parrentCategory = 10299;
                var objParrentCategory = await repositoryPostCategory.Detail(parrentCategory);
                ViewBag.objParrentCategory = NovaticUtil.ChangeCategoryLanguage(objParrentCategory, lang);
            }
            catch (Exception) { throw; }
            return View();
        }

        [HttpPost]
        [Route("api/SingleFileDemo/{type}")]
        public void SingleFileDemo(IFormFile file, string type, string parameter, string source)
        {
            string[] arrExtension = { ".jpg", ".jpeg", ".bmp", ".gif", ".png",
                ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".pps", ".ppt", ".pptx" };
            if (type == "AccountPhoto")
            {
                _dir = _env.ContentRootPath + "\\wwwroot\\files\\upload\\accountPhoto\\";
            }
            else if (type == "PostImage")
            {
                _dir = _env.ContentRootPath + "\\wwwroot\\files\\upload\\postImage\\";
            }
            else if (type == "PostDocument")
            {
                _dir = _env.ContentRootPath + "\\wwwroot\\files\\upload\\postDocument\\";
            }
            else
            {
                _dir = _env.ContentRootPath + "\\wwwroot\\files\\upload\\common\\";
            }
            string fileName = file.FileName;
            if (parameter != null)
            {
                string name = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
                string extension = file.FileName.Substring(file.FileName.LastIndexOf(".")).ToLower();
                fileName = name + "-" + parameter + extension;
                if (Array.IndexOf(arrExtension, extension) > -1)
                {
                    using (var fileStream = new FileStream(Path.Combine(_dir, fileName), FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }
        }

        //Trang chu so tay huong dan
        [HttpGet]
        [Route("chi-tiet-bai-hoc-kinh-nghiem/{IdString}")]
        [Route("LearnedLessionDetail/{IdString}")]
        public async Task<IActionResult> LearnedLessionDetail(string IdString)
        {
            // Kiểm tra đăng nhập
            int UserID = 0;
            ViewBag.UserTypeID = 0;
            ViewBag.UserID = 0;
            try
            { //Đa ngôn ngữ
                #region
                string lang = await SetLanguage(); ViewBag.Lang = lang;
                #endregion
                //Load Menu
                #region
                List<Menu> MenuList = await repositoryMenu.ListMenuHeader();
                ViewBag.MenuList = NovaticUtil.ChangeMenuLanguage(MenuList, lang);
                List<Menu> MenuListFooter = await repositoryMenu.ListMenuFooter();
                ViewBag.MenuListFooter = NovaticUtil.ChangeMenuLanguage(MenuListFooter, lang);
                #endregion
                string UserIDSession = HttpContext.Session.GetString("UserID");
                if (UserIDSession != null && UserIDSession != "")
                {
                    UserID = Convert.ToInt32(UserIDSession);

                    List<AccountViewModel> AccountDataList = await repositoryAccount.Detail(UserID);
                    AccountViewModel accountObj = AccountDataList[0];
                    ViewBag.UserID = accountObj.Id;
                    ViewBag.UserTypeID = accountObj.AccountTypeID;
                    ViewBag.Username = accountObj.Username;
                    ViewBag.UserFullname = accountObj.Name;
                    ViewBag.UserPhoto = accountObj.Photo;
                }
                int id = Convert.ToInt32(new String(IdString.TakeWhile(Char.IsDigit).ToArray()));
                var LessionLearned = await repository.Detail(id);
                List<PostViewModel> YouMayAlsoLikeList = await repository.GetSimilarPost(id);
                ViewBag.ListSimilarPost = YouMayAlsoLikeList;
                ViewBag.LessionLearned = LessionLearned;
            }
            catch (Exception) { throw; }
            return View();
        }

        //Trang 40
        [HttpGet]
        [Route("403.html")]
        public async Task<IActionResult> ForbiddenPage()
        {
            return View();
        }

    }

}
