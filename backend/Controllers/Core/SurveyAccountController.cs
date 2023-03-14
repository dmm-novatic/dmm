
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novatic.Util;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Novatic.ViewModel;

namespace Novatic.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SurveyAccountController : BaseController
    {
        ISurveyAccountRepository repository;
        ISystemConfigRepository repositorySystemConfig;
        IAccountRepository repositoryAccount;
        ISurveySectionAccountRepository repositotySurveySectionAccount;
        ISurveySectionRepository repositorySurveySection;
        ISurveyRepository repositorySurvey;

        ISurveySectionAccountDetailRepository repositorySurveySectionAccountDetail;
        public SurveyAccountController(ISurveyAccountRepository _repository, ISystemConfigRepository _repositorySystemConfig, IAccountRepository _repositoryAccount, ISurveySectionAccountRepository _repositotySurveySectionAccount, ISurveySectionRepository _repositorySurveySection, ISurveySectionAccountDetailRepository _repositorySurveySectionAccountDetail, ISurveyRepository _repositorySurvey, ICacheHelper cacheHelper) : base(cacheHelper)
        {
            repository = _repository;
            repositorySystemConfig = _repositorySystemConfig;
            repositoryAccount = _repositoryAccount;
            repositotySurveySectionAccount = _repositotySurveySectionAccount;
            repositorySurveySection = _repositorySurveySection;
            repositorySurveySectionAccountDetail = _repositorySurveySectionAccountDetail;
            repositorySurvey = _repositorySurvey;
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
        [Route("admin/Report")]
        public async Task<IActionResult> Report()
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
        [Route("admin/ListReport")]
        public async Task<IActionResult> ListReport()
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
        [Route("api/ListBySurveyId1/{surveyId}")]
        public async Task<IActionResult> ListBySurveyId1(int surveyId)
        {
            try
            {
                var dataList = await repository.ListBySurveyId(surveyId);

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
        [Route("api/ListBySurveyId/{surveyId}")]
        public async Task<IActionResult> ListBySurveyId(int surveyId)
        {
            try
            {
                var dataList = await repository.ListSurveyAccountBySurveyId(surveyId);

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
        public async Task<IActionResult> Add([FromBody] SurveyAccount model)
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
        public async Task<IActionResult> Update([FromBody] SurveyAccount model)
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
        public async Task<IActionResult> Delete([FromBody] SurveyAccount model)
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
        public async Task<IActionResult> DeletePermanently([FromBody] SurveyAccount model)
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
        public int CountSurveyAccount()
        {
            int result = repository.CountSurveyAccount();
            return result;
        }


        [HttpPost]
        [Route("api/AddMultiple")]
        public async Task<IActionResult> AddMultiple([FromBody] JObject model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //0. Lấy thông tin đăng nhập
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
                    //0.1 Validate nếu không đăng nhập thì không pass
                    if(UserID == 0)
                    {
                        return BadRequest();
                    }
                    //1 Lấy data để insert vào bảng SurveyAccount
                    var dataSurveyAccount = JsonConvert.DeserializeObject<SurveyAccount>(model["JsonSurveyAccount"].ToString());
                    SurveyAccount surveyAccount = dataSurveyAccount;
                    //1.1 Lấy detail của bảng survey
                    var surveyDetail = await repositorySurvey.Detail(dataSurveyAccount.SurveyId);
                    //1.2 Insert vào SurveyAccount
                    surveyAccount.AccountId = UserID;
                    surveyAccount.CreatedTime = DateTime.Now;
                    surveyAccount.Active = 1;
                    surveyAccount.Name = surveyDetail[0].Name;
                    surveyAccount.Name2 = surveyDetail[0].Name2;
                    //Nếu type của survey là 01 thì đánh giá là nhận định
                    if (surveyDetail[0].SurveyTypeId == 1000001)
                    {
                        if (0 <= surveyAccount.Score && surveyAccount.Score <= 7.4)
                        {
                            surveyAccount.Description = "10160";
                            surveyAccount.Text = "10155";
                        }
                        else if (7.5 <= surveyAccount.Score && surveyAccount.Score <= 10.6)
                        {
                            surveyAccount.Description = "10161";
                            surveyAccount.Text = "10156";
                        }
                        else if (10.7 <= surveyAccount.Score && surveyAccount.Score <= 12.5)
                        {
                            surveyAccount.Description = "10162";
                            surveyAccount.Text = "10157";
                        }
                        else if (12.6 <= surveyAccount.Score && surveyAccount.Score <= 15.1)
                        {
                            surveyAccount.Description = "10163";
                            surveyAccount.Text = "10158";
                        }
                        else if (15.2 <= surveyAccount.Score && surveyAccount.Score <= 17.5)
                        {
                            surveyAccount.Description = "10164";
                            surveyAccount.Text = "10159";
                        }
                    }
                    else
                    {
                        if ( surveyAccount.Score < 13)
                        {
                            surveyAccount.Description = "10150";
                            surveyAccount.Text = "10145";
                        }
                        else if (13 <= surveyAccount.Score && surveyAccount.Score < 17)
                        {
                            surveyAccount.Description = "10151";
                            surveyAccount.Text = "10146";
                        }
                        else if (17 <= surveyAccount.Score && surveyAccount.Score < 20)
                        {
                            surveyAccount.Description = "10152";
                            surveyAccount.Text = "10147";
                        }
                        else if (20 <= surveyAccount.Score && surveyAccount.Score < 22)
                        {
                            surveyAccount.Description = "10153";
                            surveyAccount.Text = "10148";
                        }
                        else if (22 <= surveyAccount.Score)
                        {
                            surveyAccount.Description = "10154";
                            surveyAccount.Text = "10149";
                        }
                    }
                    await repository.Add(surveyAccount);
                    var surveyAccountId = surveyAccount.Id;
                    //2. Lấy data để insert vào bảng SurveySectionAccount
                    var dataJsonOfSurveySectionAccount = JsonConvert.DeserializeObject<List<SurveySectionAccount>>(model["JsonOfSurveySectionAccount"].ToString());
                    List<SurveySectionAccount> surveySectionAccount = dataJsonOfSurveySectionAccount;
                    for (int i = 0; i < surveySectionAccount.Count; i++)
                    {
                        surveySectionAccount[i].SurveyAccountId = surveyAccountId;
                        surveySectionAccount[i].Active = 1;
                        surveySectionAccount[i].CreatedTime = DateTime.Now;
                        surveySectionAccount[i].SurveyAccount = null;
                        var objSurveySectionAccountDetail = new SurveySectionAccount();
                        objSurveySectionAccountDetail = surveySectionAccount[i];
                        await repositotySurveySectionAccount.Add(objSurveySectionAccountDetail);
                        //2.1 Sau khi insert xong cập nhật lại tổng điểm theo công thức
                        var detailSurveySectionAccount = await repositotySurveySectionAccount.Detail(objSurveySectionAccountDetail.Id);
                        if(detailSurveySectionAccount.Count > 0)
                        {
                            //Lấy ra % điểm của chương
                            var detailSurveySection = await repositorySurveySection.Detail(Convert.ToInt32(detailSurveySectionAccount[0].Description));
                            var newObjSurveySectionAccountDetail = new SurveySectionAccount();
                            newObjSurveySectionAccountDetail = detailSurveySectionAccount[0];
                            newObjSurveySectionAccountDetail.Score = (detailSurveySectionAccount[0].Score / 100) * (detailSurveySection[0].ProportionScore / 100) * 100;
                            await repositotySurveySectionAccount.Update(newObjSurveySectionAccountDetail);
                        }
                    }
                    //3. Lấy data để insert vào bảng SurveySectionAccountDetail
                    var dataJsonOfQuestion = JsonConvert.DeserializeObject<List<SurveySectionAccountDetail>>(model["JsonOfQuestion"].ToString());
                    List<SurveySectionAccountDetail> surveySectionAccountDetail = dataJsonOfQuestion;
                    for (int j = 0; j < surveySectionAccountDetail.Count; j++)
                    {
                        var obj = await repositorySurveySection.DetailByQuestion(surveySectionAccountDetail[j].QuestionId);
                        if (obj.Count > 0)
                        {
                            var DataSurveySectionAccount = await repositotySurveySectionAccount.DetailBySurveyAccountIdAndSurveySection(surveyAccountId, obj[0].Id);
                            if (Convert.ToInt32(DataSurveySectionAccount[0].Description) == obj[0].Id)
                            {
                                surveySectionAccountDetail[j].Name = obj[0].Name;
                                surveySectionAccountDetail[j].Active = 1;
                                surveySectionAccountDetail[j].SurveySectionAccount = DataSurveySectionAccount[0].Id;
                                surveySectionAccountDetail[j].CreatedTime = DateTime.Now;
                                var dataSurveySectionAccountDetail = new SurveySectionAccountDetail();
                                dataSurveySectionAccountDetail = surveySectionAccountDetail[j];
                                await repositorySurveySectionAccountDetail.Add(dataSurveySectionAccountDetail);
                            }
                        }
                    }
                    var novaticResponse = NovaticResponse.CREATED(surveyAccount);
                    return Created("", novaticResponse);
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return BadRequest();
        }
    }
}
