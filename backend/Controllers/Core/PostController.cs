
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using Novatic.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : BaseController
    {

        IPostRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        IPostCategoryRepository repositoryPostCategory;
        ILanguageConfigRepository repositoryLanguageConfig;

        public PostController(ICacheHelper cacheHelper, ISystemConfigRepository _repositorySystemConfig, IPostRepository _repository, IAccountRepository _repositoryAccount, IPostCategoryRepository _repositoryPostCategory, ILanguageConfigRepository _repositoryLanguageConfig) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositoryPostCategory = _repositoryPostCategory;
            repositoryLanguageConfig = _repositoryLanguageConfig;
        }


        [HttpGet]
        [Route("admin/List")]
        public async Task<IActionResult> AdminList()
        {
            //lấy session user info
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

            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
            try
            {
                //var dataList = await repository.ListPaging(1, 100);
                //var dataList = await repository.List();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.ListPost = dataList;
                //return View(dataList);
                return View();

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
        [Route("admin/ListEvent")]
        public async Task<IActionResult> AdminListEvent()
        {
            //lấy session user info
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

            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
            try
            {
                //var dataList = await repository.ListPaging(1, 100);
                //var dataList = await repository.List();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.ListPost = dataList;
                //return View(dataList);
                return View();

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
        [Route("admin/ListLibrary")]
        public async Task<IActionResult> AdminListLibrary()
        {
            //lấy session user info
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

            if (UserTypeID != 10001)
            {
                return Redirect("/403.html");
            }
            try
            {
                //var dataList = await repository.ListPaging(1, 100);
                //var dataList = await repository.List();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.ListPost = dataList;
                //return View(dataList);
                return View();

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
        [Route("admin/listPhuluc5")]
        public async Task<IActionResult> AdminListPhuluc5()
        {
            try
            {
                //var dataList = await repository.ListPaging(1, 100);
                //var dataList = await repository.List();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.ListPost = dataList;
                //return View(dataList);
                return View();

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
        [Route("admin/listLessonLearned")]
        public async Task<IActionResult> AdminListLessonLearned()
        {
            try
            {
                //var dataList = await repository.ListPaging(1, 100);
                //var dataList = await repository.List();

                //if (dataList == null || dataList.Count == 0)
                //{
                //    //return NotFound();
                //}


                //ViewBag.ListPost = dataList;
                //return View(dataList);
                return View();

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
        [Route("admin/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
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
                PostViewModel obj = new PostViewModel();
                if (id != 0)
                {
                    var dataList = await repository.Detail(id);

                    if (dataList == null || dataList.Count == 0)
                    {
                        return NotFound();
                    }
                    obj = dataList[0];
                }  
                else
                {
                    obj.CreatedTime = DateTime.Now;
                }



                //ViewBag.ListPost = dataList;
                return View(obj);

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
        [Route("admin/ListUnSetCategory")]
        public async Task<IActionResult> AdminListUnsetCategory()
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
                //var dataList = await repository.ListPaging(1, 1000);
                var dataList = await repository.ListByUnsetCate();

                if (dataList == null || dataList.Count == 0)
                {
                    //return NotFound();
                }


                ViewBag.ListPost = dataList;
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


        [HttpPost]
        [Route("api/LoadTable")]
        public async Task<IActionResult> LoadTable([FromBody]DTParameters dtParameters)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListInAdmin() : await repository.SearchInAdmin(searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // chỗ này là column filter !
            //filter column 0 - id
            string filter0Id = dtParameters.Columns[0].Search.Value;
            if (filter0Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter0Id.ToUpper()))
                    .ToList();
            }

            //filter column 1 - id
            string filter1Id = dtParameters.Columns[1].Search.Value;
            if (filter1Id.Length > 0 && dtParameters.Columns[1].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter1Id.ToUpper()))
                    .ToList();
            }

            //filter column 2 - postAccountName
            string filter2PostAccountName = dtParameters.Columns[2].Search.Value;
            if (filter2PostAccountName.Length > 0 && dtParameters.Columns[2].Data == "postAccountName")
            {
                result = result.Where(r => r.PostAccountName != null && r.PostAccountName.ToString().ToUpper().Contains(filter2PostAccountName.ToUpper()))
                    .ToList();
            }

            //filter column 3 - postCategoryName
            string filter3PostCategoryName = dtParameters.Columns[3].Search.Value;
            if (filter3PostCategoryName.Length > 0 && dtParameters.Columns[3].Data == "postCategoryName")
            {
                result = result.Where(r => r.PostCategoryName != null && r.PostCategoryName.ToString().ToUpper().Contains(filter3PostCategoryName.ToUpper()))
                    .ToList();
            }

            //filter column 4 - postLayoutName
            string filter4PostLayoutName = dtParameters.Columns[4].Search.Value;
            if (filter4PostLayoutName.Length > 0 && dtParameters.Columns[4].Data == "postLayoutName")
            {
                result = result.Where(r => r.PostLayoutName != null && r.PostLayoutName.ToUpper().Contains(filter4PostLayoutName.ToUpper()))
                    .ToList();
            }

            //filter column 5 - name
            string filter5Name = dtParameters.Columns[5].Search.Value;
            if (filter5Name.Length > 0 && dtParameters.Columns[5].Data == "name")
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(filter5Name.ToUpper()))
                    .ToList();
            }

            //filter column 6 - createdTime
            string filter6CreatedTime = dtParameters.Columns[6].Search.Value;
            if (filter6CreatedTime.Length > 0 && dtParameters.Columns[6].Data == "createdTime")
            {
                result = result.Where(r => r.CreatedTime != null && r.CreatedTime.ToString().ToUpper().Contains(filter6CreatedTime.ToUpper()))
                    .ToList();
            }

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountPost();

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
        }

        [HttpPost]
        [Route("api/LoadTablePhuluc5")]
        public async Task<IActionResult> LoadTablePhuluc5([FromBody] DTParameters dtParameters)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListPhuluc5InAdmin() : await repository.SearchInAdmin(searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // chỗ này là column filter !
            //filter column 0 - id
            string filter0Id = dtParameters.Columns[0].Search.Value;
            if (filter0Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter0Id.ToUpper()))
                    .ToList();
            }

            //filter column 1 - id
            string filter1Id = dtParameters.Columns[1].Search.Value;
            if (filter1Id.Length > 0 && dtParameters.Columns[1].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter1Id.ToUpper()))
                    .ToList();
            }

            //filter column 2 - postAccountName
            string filter2PostAccountName = dtParameters.Columns[2].Search.Value;
            if (filter2PostAccountName.Length > 0 && dtParameters.Columns[2].Data == "postAccountName")
            {
                result = result.Where(r => r.PostAccountName != null && r.PostAccountName.ToString().ToUpper().Contains(filter2PostAccountName.ToUpper()))
                    .ToList();
            }

            //filter column 3 - postCategoryName
            string filter3PostCategoryName = dtParameters.Columns[3].Search.Value;
            if (filter3PostCategoryName.Length > 0 && dtParameters.Columns[3].Data == "postCategoryName")
            {
                result = result.Where(r => r.PostCategoryName != null && r.PostCategoryName.ToString().ToUpper().Contains(filter3PostCategoryName.ToUpper()))
                    .ToList();
            }

            //filter column 4 - postLayoutName
            string filter4PostLayoutName = dtParameters.Columns[4].Search.Value;
            if (filter4PostLayoutName.Length > 0 && dtParameters.Columns[4].Data == "postLayoutName")
            {
                result = result.Where(r => r.PostLayoutName != null && r.PostLayoutName.ToUpper().Contains(filter4PostLayoutName.ToUpper()))
                    .ToList();
            }

            //filter column 5 - name
            string filter5Name = dtParameters.Columns[5].Search.Value;
            if (filter5Name.Length > 0 && dtParameters.Columns[5].Data == "name")
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(filter5Name.ToUpper()))
                    .ToList();
            }

            //filter column 6 - createdTime
            string filter6CreatedTime = dtParameters.Columns[6].Search.Value;
            if (filter6CreatedTime.Length > 0 && dtParameters.Columns[6].Data == "createdTime")
            {
                result = result.Where(r => r.CreatedTime != null && r.CreatedTime.ToString().ToUpper().Contains(filter6CreatedTime.ToUpper()))
                    .ToList();
            }

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountPost();

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
        }

        [HttpPost]
        [Route("api/LoadTableLessonLearned")]
        public async Task<IActionResult> LoadTableLessonLearned([FromBody] DTParameters dtParameters)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListLessonLearnedInAdmin() : await repository.SearchInAdmin(searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // chỗ này là column filter !
            //filter column 0 - id
            string filter0Id = dtParameters.Columns[0].Search.Value;
            if (filter0Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter0Id.ToUpper()))
                    .ToList();
            }

            //filter column 1 - id
            string filter1Id = dtParameters.Columns[1].Search.Value;
            if (filter1Id.Length > 0 && dtParameters.Columns[1].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter1Id.ToUpper()))
                    .ToList();
            }

            //filter column 2 - postAccountName
            string filter2PostAccountName = dtParameters.Columns[2].Search.Value;
            if (filter2PostAccountName.Length > 0 && dtParameters.Columns[2].Data == "postAccountName")
            {
                result = result.Where(r => r.PostAccountName != null && r.PostAccountName.ToString().ToUpper().Contains(filter2PostAccountName.ToUpper()))
                    .ToList();
            }

            //filter column 3 - postCategoryName
            string filter3PostCategoryName = dtParameters.Columns[3].Search.Value;
            if (filter3PostCategoryName.Length > 0 && dtParameters.Columns[3].Data == "postCategoryName")
            {
                result = result.Where(r => r.PostCategoryName != null && r.PostCategoryName.ToString().ToUpper().Contains(filter3PostCategoryName.ToUpper()))
                    .ToList();
            }

            //filter column 4 - postLayoutName
            string filter4PostLayoutName = dtParameters.Columns[4].Search.Value;
            if (filter4PostLayoutName.Length > 0 && dtParameters.Columns[4].Data == "postLayoutName")
            {
                result = result.Where(r => r.PostLayoutName != null && r.PostLayoutName.ToUpper().Contains(filter4PostLayoutName.ToUpper()))
                    .ToList();
            }

            //filter column 5 - name
            string filter5Name = dtParameters.Columns[5].Search.Value;
            if (filter5Name.Length > 0 && dtParameters.Columns[5].Data == "name")
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(filter5Name.ToUpper()))
                    .ToList();
            }

            //filter column 6 - createdTime
            string filter6CreatedTime = dtParameters.Columns[6].Search.Value;
            if (filter6CreatedTime.Length > 0 && dtParameters.Columns[6].Data == "createdTime")
            {
                result = result.Where(r => r.CreatedTime != null && r.CreatedTime.ToString().ToUpper().Contains(filter6CreatedTime.ToUpper()))
                    .ToList();
            }

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountPost();

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
        }


        [HttpPost]
        [Route("api/LoadTableAdvanceSearch")]
        public async Task<IActionResult> LoadTableAdvanceSearch([FromBody]DTParameters dtParameters)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListInAdvanceSearch() : await repository.SearchInAdvanceSearch(searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // chỗ này là column filter !
            //filter column 0 - id
            string filter0Id = dtParameters.Columns[0].Search.Value;
            if (filter0Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter0Id.ToUpper()))
                    .ToList();
            }

            //filter column 1 - id
            string filter1Id = dtParameters.Columns[1].Search.Value;
            if (filter1Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter1Id.ToUpper()))
                    .ToList();
            }

            //filter column 2 - postAccountName
            string filter2PostAccountName = dtParameters.Columns[2].Search.Value;
            if (filter2PostAccountName.Length > 0 && dtParameters.Columns[0].Data == "postAccountName")
            {
                result = result.Where(r => r.PostAccountName != null && r.PostAccountName.ToString().ToUpper().Contains(filter2PostAccountName.ToUpper()))
                    .ToList();
            }

            //filter column 3 - postCategoryName
            string filter3PostCategoryName = dtParameters.Columns[3].Search.Value;
            if (filter3PostCategoryName.Length > 0 && dtParameters.Columns[0].Data == "postCategoryName")
            {
                result = result.Where(r => r.PostCategoryName != null && r.PostCategoryName.ToString().ToUpper().Contains(filter3PostCategoryName.ToUpper()))
                    .ToList();
            }

            //filter column 4 - postLayoutName
            string filter4PostLayoutName = dtParameters.Columns[4].Search.Value;
            if (filter4PostLayoutName.Length > 0 && dtParameters.Columns[0].Data == "postLayoutName")
            {
                result = result.Where(r => r.PostLayoutName != null && r.PostLayoutName.ToUpper().Contains(filter4PostLayoutName.ToUpper()))
                    .ToList();
            }

            //filter column 5 - name
            string filter5Name = dtParameters.Columns[5].Search.Value;
            if (filter5Name.Length > 0 && dtParameters.Columns[0].Data == "name")
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(filter5Name.ToUpper()))
                    .ToList();
            }

            //filter column 6 - createdTime
            string filter6CreatedTime = dtParameters.Columns[6].Search.Value;
            if (filter6CreatedTime.Length > 0 && dtParameters.Columns[0].Data == "createdTime")
            {
                result = result.Where(r => r.CreatedTime != null && r.CreatedTime.ToString().ToUpper().Contains(filter6CreatedTime.ToUpper()))
                    .ToList();
            }

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountPost();

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
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
            //Đa ngôn ngữ
            #region
            string lang = await SetLanguage(); ViewBag.Lang = lang;
            #endregion
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.ListPaging(pageIndex, pageSize);

                if (dataList == null || dataList.Count == 0)
                {
                    return NotFound();
                }
                dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("api/ListPagingPost")]
        public async Task<IActionResult> ListPagingPost(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.ListPagingPost(pageIndex, pageSize);

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
        [Route("api/ListPagingPhuluc5")]
        public async Task<IActionResult> ListPagingPhuluc5(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.ListPagingPhuluc5(pageIndex, pageSize);

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
        [Route("api/ListPagingEventGoingOn/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> ListPagingEvent(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.ListEventsIsGoingOnPaging(pageIndex, pageSize);

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
        [Route("api/ListPagingLibrary/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> ListPagingLibrary(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                string lang = await SetLanguage();
                //Load danh mục con theo thư viện
                int parrentCategory = 10299;
                var objParrentCategory = await repositoryPostCategory.Detail(parrentCategory);
                objParrentCategory = NovaticUtil.ChangeCategoryLanguage(objParrentCategory, lang);
                var listChildLibrary = await repositoryPostCategory.ListbyParentId(parrentCategory);
                for (int i = 0; i < listChildLibrary.Count; i++)
                {
                    int countPostByPostCategoryId = repository.CountPost(listChildLibrary[i].Id);
                    listChildLibrary[i].PostCount = countPostByPostCategoryId;
                }
                listChildLibrary = NovaticUtil.ChangeCategoryLanguage(listChildLibrary, lang);
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
                        listLibrary.Add(item);
                    }
                }
                listLibrary = NovaticUtil.ChangePostLanguage(listLibrary, lang);
                #endregion
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                listLibrary = listLibrary.Skip(offSet).Take(pageSize).ToList();
                if (listLibrary == null || listLibrary.Count == 0)
                {
                    return NotFound();
                }

                var novaticResponse = NovaticResponse.SUCCESS(listLibrary.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/ListPagingEventEnded/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> ListPagingEventEnded (int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0) return BadRequest();
            try
            {
                var dataList = await repository.ListEventsEndedPaging(pageIndex, pageSize);

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
        [Route("api/ListPaging/category/{categorySlug}/{pageIndex}/{pageSize}/{currentIDBigest}")]
        public async Task<IActionResult> ListCategoryPaging(string categorySlug, int pageIndex, int pageSize, int currentIDBigest)
        {
            if (pageIndex < 0 || pageSize < 0 || categorySlug.Length == 0 || currentIDBigest < 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                List<PostCategory> pc = await repositoryPostCategory.Detail(categorySlug);
                int pcId = pc[0].Id;
                var dataList = await repository.ListCategoryPagingRecursive(pcId, pageIndex, pageSize, currentIDBigest);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        [Route("api/ListPaging/tag/{tagSlug}/{pageIndex}/{pageSize}/{currentIDBigest}")]
        public async Task<IActionResult> ListTagPaging(string tagSlug, int pageIndex, int pageSize, int currentIDBigest)
        {
            if (pageIndex < 0 || pageSize < 0 || tagSlug.Length == 0 || currentIDBigest < 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                var dataList = await repository.ListTagPaging(tagSlug, pageIndex, pageSize, currentIDBigest);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        [Route("api/ListPaging/author/{authorUsername}/{pageIndex}/{pageSize}/{currentIDBigest}")]
        public async Task<IActionResult> ListAuthorPaging(string authorUsername, int pageIndex, int pageSize, int currentIDBigest)
        {
            if (pageIndex < 0 || pageSize < 0 || authorUsername.Length == 0 || currentIDBigest < 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                var dataList = await repository.ListAuthorPaging(authorUsername, pageIndex, pageSize, currentIDBigest);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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


        //[HttpPost]
        //[Route("api/ListPaging/Search")]
        //public async Task<IActionResult> ListSearchPaging([FromBody]Post model)
        //{

        //    if (model.PostTypeId < 0 || model.PostAccountId < 0 || model.Description.Length == 0 || model.PostCategoryId < 0) return BadRequest();
        //    try
        //    {
        //        string lang = "vi";
        //        try
        //        {
        //            lang = HttpContext.Session.GetString("LanguageCode");
        //            if (lang == null)
        //            {
        //                lang = "vi";
        //            }
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        var dataList = await repository.ListSearchPaging(model.Description, model.PostTypeId, model.PostAccountId, model.PostCategoryId);
        //        if (lang == "en")
        //        {
        //            dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
        //        }
        //        if (dataList == null || dataList.Count == 0)
        //        {
        //            return NotFound();
        //        }

        //        var novaticResponse = NovaticResponse.SUCCESS(dataList.Cast<object>().ToList());
        //        return Ok(novaticResponse);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpGet]
        [Route("api/ListPaging/Search/{keyWord}/{pageIndex}/{pageSize}/{currentIDBigest}")]
        public async Task<IActionResult> ListSearchPaging(string keyWord, int pageIndex, int pageSize, int currentIDBigest)
        {
            //URL Decode for Vietnamese
            keyWord = HttpUtility.UrlDecode(keyWord);
            if (pageIndex < 0 || pageSize < 0 || keyWord.Length == 0 || currentIDBigest < 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                var dataList = await repository.ListSearchPaging(keyWord, pageIndex, pageSize, currentIDBigest);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        [Route("api/ListSearchPagingCreatedTime/Search/{pageIndex}/{pageSize}/{fromCreatedTime}/{toCreatedTime}")]
        public async Task<IActionResult> ListSearchPagingCreatedTime(int pageIndex, int pageSize, string fromCreatedTime, string toCreatedTime)
        {
            if (pageIndex < 0 || pageSize < 0 || fromCreatedTime.Length == 0 || toCreatedTime.Length == 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                //fromCreatedTime = fromCreatedTime + "T00:00:00";
                DateTime fromDate = Convert.ToDateTime(fromCreatedTime);
                //DateTime fromDate = DateTime.ParseExact(fromCreatedTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                //toCreatedTime = toCreatedTime + "T00:00:00";
                DateTime toDate = Convert.ToDateTime(toCreatedTime);
                //DateTime toDate = DateTime.ParseExact(toCreatedTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var dataList = await repository.ListSearchPagingCreatedTime(pageIndex, pageSize, fromDate, toDate);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        public async Task<IActionResult> Add([FromBody]Post model)
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
                if (model.CommentCount == null) model.CommentCount = 0;
                if (model.ViewCount == null) model.ViewCount = 0;
                if (model.LikeCount == null) model.LikeCount = 0;

                model.Url = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
                model.Url2 = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
                model.GuId = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();

                //2. add new object
                try
                {
                    var newObj = await repository.Add(model);
                    if (newObj.Id > 0)
                    {
                        //update url based on returned ID
                        newObj.Url = NovaticUtil.ConvertToURL(newObj.Id + "-" + newObj.Name);
                        newObj.Url2 = newObj.Url;
                        newObj.GuId = newObj.Url;
                        await repository.Update(newObj);

                        //return to front end
                        var novaticResponse = NovaticResponse.CREATED(newObj);
                        return Created("", novaticResponse);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("api/Update")]
        public async Task<IActionResult> Update([FromBody]Post model)
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
        public async Task<IActionResult> Delete([FromBody]Post model)
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
        public async Task<IActionResult> DeletePermanently([FromBody]Post model)
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
        [Route("api/ListPaging/Favorite/{UserID}/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> ListFavorite(int UserID, int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0 || UserID == 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                var dataList = await repository.ListFavouritePost(UserID, pageIndex, pageSize);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        [Route("api/ListPaging/Readed/{UserID}/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> ListReaded(int UserID, int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0 || UserID == 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                var dataList = await repository.ListReadedPost(UserID, pageIndex, pageSize);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        [Route("api/ListPaging/topic/{topicSlug}/{pageIndex}/{pageSize}/{currentIDBigest}")]
        public async Task<IActionResult> ListTopicPaging(string topicSlug, int pageIndex, int pageSize, int currentIDBigest)
        {
            if (pageIndex < 0 || pageSize < 0 || topicSlug.Length == 0 || currentIDBigest < 0) return BadRequest();
            try
            {
                string lang = "vi";
                try
                {
                    lang = HttpContext.Session.GetString("LanguageCode");
                    if (lang == null)
                    {
                        lang = "vi";
                    }
                }
                catch (Exception)
                {
                }
                var dataList = await repository.ListTopicPaging(topicSlug, pageIndex, pageSize, currentIDBigest);
                if (lang == "en")
                {
                    dataList = NovaticUtil.ChangePostLanguage(dataList, lang);
                }
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
        [Route("api/Count")]
        public int CountPost()
        {
            int result = repository.CountPost();
            return result;
        }

        [HttpGet]
        [Route("api/CountUnsetCategory")]
        public int CountPostUnsetCategory()
        {
            int result = repository.CountPostUnsetCategory();
            return result;
        }


        [HttpGet]
        [Route("api/GetFilteredItems")]
        public JsonResult GetFilteredItems()
        {
            List<PostViewModel> dataList = repository.List().Result;
            System.Threading.Thread.Sleep(2000);//Used to display loading message in demonstration, remove this line in production
            int draw = Convert.ToInt32(Request.Query["draw"]);

            // Data to be skipped , 
            // if 0 first "length" records will be fetched
            // if 1 second "length" of records will be fethced ...
            int start = Convert.ToInt32(Request.Query["start"]);

            // Records count to be fetched after skip
            int length = Convert.ToInt32(Request.Query["length"]);

            // Getting Sort Column Name
            int sortColumnIdx = Convert.ToInt32(Request.Query["order[0][column]"]);
            string sortColumnName = Request.Query["columns[" + sortColumnIdx + "][name]"];

            // Sort Column Direction  
            string sortColumnDirection = Request.Query["order[0][dir]"];

            // Search Value
            string searchValue = Request.Query["search[value]"].FirstOrDefault()?.Trim();

            // Total count matching search criteria 
            int recordsFilteredCount =
                    dataList
                    .Where(a => a.PostCategoryName.Contains(searchValue) || a.PostCategoryName2.Contains(searchValue) || a.Name.Contains(searchValue) || a.Name2.Contains(searchValue) || a.Text.Contains(searchValue) || a.Text2.Contains(searchValue))
                    .Count();

            // Total Records Count
            int recordsTotalCount = dataList.Count();

            // Filtered & Sorted & Paged data to be sent from server to view
            List<PostViewModel> filteredData = null;
            if (sortColumnDirection == "asc")
            {
                filteredData =
                    dataList
                    .Where(a => a.PostCategoryName.Contains(searchValue) || a.PostCategoryName2.Contains(searchValue) || a.Name.Contains(searchValue) || a.Name2.Contains(searchValue) || a.Text.Contains(searchValue) || a.Text2.Contains(searchValue))
                    .OrderBy(x => x.GetType().GetProperty(sortColumnName).GetValue(x))//Sort by sortColumn
                    .Skip(start)
                    .Take(length)
                    .ToList<PostViewModel>();
            }
            else
            {
                filteredData =
                   dataList
                   .Where(a => a.PostCategoryName.Contains(searchValue) || a.PostCategoryName2.Contains(searchValue) || a.Name.Contains(searchValue) || a.Name2.Contains(searchValue) || a.Text.Contains(searchValue) || a.Text2.Contains(searchValue))
                   .OrderByDescending(x => x.GetType().GetProperty(sortColumnName).GetValue(x))
                   .Skip(start)
                   .Take(length)
                   .ToList<PostViewModel>();
            }

            return Json(
                        new
                        {
                            data = filteredData,
                            draw = Request.Query["draw"],
                            recordsFiltered = recordsFilteredCount,
                            recordsTotal = recordsTotalCount
                        }
                    );
        }

        [HttpGet]
        [Route("api/AutoCreatePostInChartCategory")]
        public async Task<IActionResult> AutoCreatePostInChartCategory()
        {
            try
            {
                //đường dẫn ở máy mình
                //string directImages = "D:\\Project\\GappingWorld\\Source\\gappingworld\\GappingWorld\\wwwroot\\files\\frontend\\ChartImages";
                // đường dẫn ở sever
                string directImages = "C:\\Novatic\\Projects\\GW\\RunTime\\publish\\wwwroot\\files\\frontend\\ChartImages";

                string[] filesName = Directory.GetFiles(directImages, "*.*")
                                     .Select(Path.GetFileName)
                                     .ToArray();
                Post updatingObj2 = new Post
                {
                    //"id": $("#postId").val(),
                    PostTypeId = 10001,
                    PostAccountId = 10001,
                    //ID của danh mục "Biểu đồ", đang vội nếu không viết hàm trong Util thì không
                    //cần fix code ngu ngốc như thế này. dùng tạm
                    PostCategoryId = 10294,
                    PostLayoutId = 10002,
                    PostPublishStatusId = 1,
                    PostCommentStatusId = 1,
                    GuId = "",
                    Photo = "",
                    Video = "",
                    ViewCount = 0,
                    CommentCount = 0,
                    LikeCount = 0,
                    Active = 0,
                    Url = "",
                    Url2 = "",
                    Name = "",
                    Description = "",
                    Text = "",
                    Name2 = "",
                    Description2 = "",
                    Text2 = "",
                    PublishedTime = DateTime.Now,
                    CreatedTime = DateTime.Now,
                };
                List<Post> newData = new List<Post>();
                var objPostCategoryChart = await repositoryPostCategory.DetailBySlug("Bieu-Do");
                int postCategoryChart = objPostCategoryChart[0].Id;
                for (int i = 0; i < filesName.Length; i++)
                {
                    string postName = filesName[i].Substring(0, filesName[i].LastIndexOf("."));


                    Post updatingObj = new Post
                    {
                        //"id": $("#postId").val(),
                        PostTypeId = 10001,
                        PostAccountId = 10001,
                        //ID của danh mục "Biểu đồ", đang vội nếu không viết hàm trong Util thì không
                        //cần fix code ngu ngốc như thế này. dùng tạm
                        PostCategoryId = postCategoryChart,
                        //PostCategoryId = 10294,
                        //PostCategoryId = 10280,
                        PostLayoutId = 10002,
                        PostPublishStatusId = 0,
                        PostCommentStatusId = 1,
                        GuId = "",
                        Photo = "",
                        Video = "",
                        ViewCount = 0,
                        CommentCount = 0,
                        LikeCount = 0,
                        Active = 1,
                        Url = "",
                        Url2 = "",
                        Name = "",
                        Description = "",
                        Text = "",
                        Name2 = "",
                        Description2 = "",
                        Text2 = "",
                        PublishedTime = DateTime.Now,
                        CreatedTime = DateTime.Now,
                    };

                    
                    var objExist = await repository.CheckExistInChartCategory(postName, postCategoryChart);
                    if (objExist.Count > 0)
                    {
                        continue;
                    }

                    updatingObj.Name = postName;
                    updatingObj.Name2 = postName;
                    updatingObj.Photo = "files\\frontend\\ChartImages\\" + filesName[i];
                    updatingObj.GuId = filesName[i];
                    updatingObj.Url = filesName[i];

                    var newObj = await repository.Add(updatingObj);
                    if (newObj.Id > 0)
                    {
                        //update url based on returned ID
                        newObj.Url = NovaticUtil.ConvertToURL(newObj.Id + "-" + newObj.Name);
                        newObj.Url2 = newObj.Url;
                        newObj.GuId = newObj.Url;
                        await repository.Update(newObj);

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
                return Ok(novaticResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/AutoUpdatePostInChartCategory")]
        public async Task<IActionResult> AutoUpdatePostInChartCategory()
        {
            var arrListPost = await repository.ListPagingInAdmin(1, 1000);

            var objPostCategoryChart = await repositoryPostCategory.DetailBySlug("Bieu-Do");
            int postCategoryChart = objPostCategoryChart[0].Id;
            List<Post> newData = new List<Post>();

            for (int i = 0; i < arrListPost.Count; i++)
            {
                if (arrListPost[i].Active == 0 && arrListPost[i].PostPublishStatusId == 0 && arrListPost[i].PostCategoryId == postCategoryChart)
                {
                    arrListPost[i].Active = 1;
                    arrListPost[i].Photo = "\\" + arrListPost[i].Photo;

                    await repository.Update(arrListPost[i]);
                }
            }
            var novaticResponse = NovaticResponse.SUCCESS(newData.Cast<object>().ToList());
            return Ok(novaticResponse);
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


        [HttpPost]
        [Route("api/LoadTableEvents")]
        public async Task<IActionResult> LoadTableEvents([FromBody] DTParameters dtParameters)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListEventsInAdmin() : await repository.SearchInAdmin(searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // chỗ này là column filter !
            //filter column 0 - id
            string filter0Id = dtParameters.Columns[0].Search.Value;
            if (filter0Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter0Id.ToUpper()))
                    .ToList();
            }

            //filter column 1 - id
            string filter1Id = dtParameters.Columns[1].Search.Value;
            if (filter1Id.Length > 0 && dtParameters.Columns[1].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter1Id.ToUpper()))
                    .ToList();
            }

            //filter column 2 - postAccountName
            string filter2PostAccountName = dtParameters.Columns[2].Search.Value;
            if (filter2PostAccountName.Length > 0 && dtParameters.Columns[2].Data == "postAccountName")
            {
                result = result.Where(r => r.PostAccountName != null && r.PostAccountName.ToString().ToUpper().Contains(filter2PostAccountName.ToUpper()))
                    .ToList();
            }

            //filter column 3 - postCategoryName
            string filter3PostCategoryName = dtParameters.Columns[3].Search.Value;
            if (filter3PostCategoryName.Length > 0 && dtParameters.Columns[3].Data == "postCategoryName")
            {
                result = result.Where(r => r.PostCategoryName != null && r.PostCategoryName.ToString().ToUpper().Contains(filter3PostCategoryName.ToUpper()))
                    .ToList();
            }

            //filter column 4 - postLayoutName
            string filter4PostLayoutName = dtParameters.Columns[4].Search.Value;
            if (filter4PostLayoutName.Length > 0 && dtParameters.Columns[4].Data == "postLayoutName")
            {
                result = result.Where(r => r.PostLayoutName != null && r.PostLayoutName.ToUpper().Contains(filter4PostLayoutName.ToUpper()))
                    .ToList();
            }

            //filter column 5 - name
            string filter5Name = dtParameters.Columns[5].Search.Value;
            if (filter5Name.Length > 0 && dtParameters.Columns[5].Data == "name")
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(filter5Name.ToUpper()))
                    .ToList();
            }

            //filter column 6 - createdTime
            string filter6CreatedTime = dtParameters.Columns[6].Search.Value;
            if (filter6CreatedTime.Length > 0 && dtParameters.Columns[6].Data == "createdTime")
            {
                result = result.Where(r => r.CreatedTime != null && r.CreatedTime.ToString().ToUpper().Contains(filter6CreatedTime.ToUpper()))
                    .ToList();
            }

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountPost();

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
        }


        [HttpPost]
        [Route("api/LoadTableLibrary")]
        public async Task<IActionResult> LoadTableLibrary([FromBody] DTParameters dtParameters)
        {
            //3. API gọi dữ liệu quan trọng nhất, tất cả parameter được gói vào object dtParameters
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            // tạo list object trả về
            //var result = await repository.Search(searchBy);
            var result = (searchBy.Length == 0 ? await repository.ListLibraryInAdmin() : await repository.SearchInAdmin(searchBy));
            //var result = await repository.ListSearchPaging(searchBy, dtParameters.Start, dtParameters.Length, 99999); 

            // chỗ này là sắp xếp thứ tự
            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc).ToList();

            // chỗ này là column filter !
            //filter column 0 - id
            string filter0Id = dtParameters.Columns[0].Search.Value;
            if (filter0Id.Length > 0 && dtParameters.Columns[0].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter0Id.ToUpper()))
                    .ToList();
            }

            //filter column 1 - id
            string filter1Id = dtParameters.Columns[1].Search.Value;
            if (filter1Id.Length > 0 && dtParameters.Columns[1].Data == "id")
            {
                result = result.Where(r => r.Id != null && r.Id.ToString().ToUpper().Contains(filter1Id.ToUpper()))
                    .ToList();
            }

            //filter column 2 - postAccountName
            string filter2PostAccountName = dtParameters.Columns[2].Search.Value;
            if (filter2PostAccountName.Length > 0 && dtParameters.Columns[2].Data == "postAccountName")
            {
                result = result.Where(r => r.PostAccountName != null && r.PostAccountName.ToString().ToUpper().Contains(filter2PostAccountName.ToUpper()))
                    .ToList();
            }

            //filter column 3 - postCategoryName
            string filter3PostCategoryName = dtParameters.Columns[3].Search.Value;
            if (filter3PostCategoryName.Length > 0 && dtParameters.Columns[3].Data == "postCategoryName")
            {
                result = result.Where(r => r.PostCategoryName != null && r.PostCategoryName.ToString().ToUpper().Contains(filter3PostCategoryName.ToUpper()))
                    .ToList();
            }

            //filter column 4 - postLayoutName
            string filter4PostLayoutName = dtParameters.Columns[4].Search.Value;
            if (filter4PostLayoutName.Length > 0 && dtParameters.Columns[4].Data == "postLayoutName")
            {
                result = result.Where(r => r.PostLayoutName != null && r.PostLayoutName.ToUpper().Contains(filter4PostLayoutName.ToUpper()))
                    .ToList();
            }

            //filter column 5 - name
            string filter5Name = dtParameters.Columns[5].Search.Value;
            if (filter5Name.Length > 0 && dtParameters.Columns[5].Data == "name")
            {
                result = result.Where(r => r.Name != null && r.Name.ToUpper().Contains(filter5Name.ToUpper()))
                    .ToList();
            }

            //filter column 6 - createdTime
            string filter6CreatedTime = dtParameters.Columns[6].Search.Value;
            if (filter6CreatedTime.Length > 0 && dtParameters.Columns[6].Data == "createdTime")
            {
                result = result.Where(r => r.CreatedTime != null && r.CreatedTime.ToString().ToUpper().Contains(filter6CreatedTime.ToUpper()))
                    .ToList();
            }

            // bây h phân trang
            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = repository.CountPost();

            //trả về dữ liệu theo format JSON với Skip và Take để phân trang
            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
        }

    }
}
