 
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using Novatic.Models;
        using Novatic.Repository;
        using Microsoft.AspNetCore.Http;
        using Microsoft.AspNetCore.Mvc;
        using Novatic.Util;
        using A2F.Util;

        namespace Novatic.Controllers
        {
            [Route("[controller]")]
            [ApiController]
            public class QuestionController : BaseController
            {
                IQuestionRepository repository;
                ISystemConfigRepository repositorySystemConfig;
        IAnswerRepository repositoryAnswer;
                public QuestionController(IQuestionRepository _repository, ISystemConfigRepository _repositorySystemConfig, ICacheHelper cacheHelper, IAnswerRepository _repositoryAnswer )  : base(cacheHelper)
                {
                repository = _repository;
                repositorySystemConfig = _repositorySystemConfig;
                repositoryAnswer = _repositoryAnswer;
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
        public async Task<IActionResult> Add([FromBody] Question model)
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
                        if (newObj.QuestionTypeId == SystemConstant.QUESTION_TYPE_3_ANSWERS)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var a = new Answer();
                                if (i == 0)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = 1;
                                    a.Name = "Không";
                                    a.Name2 = "No";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }

                                else if (i == 1)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = 2;
                                    a.Name = "Một phần";
                                    a.Name2 = "Parially Yes";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }
                                else if (i == 2)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = 3;
                                    a.Name = "Có";
                                    a.Name2 = "Yes";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }
                            }
                        }
                        else if (newObj.QuestionTypeId == SystemConstant.QUESTION_TYPE_4_ANSWERS)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                var a = new Answer();
                                if (i == 0)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = 0;
                                    a.Name = "Rất không đồng ý";
                                    a.Name2 = "Strongly disagree";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }
                                else if (i == 1)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = Convert.ToSingle(0.25);
                                    a.Name = "Không đồng ý";
                                    a.Name2 = "Disagree";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }
                                else if (i == 2)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = Convert.ToSingle(0.5);
                                    a.Name = "Đồng ý";
                                    a.Name2 = "Agree";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }
                                else if (i == 3)
                                {
                                    a.QuestionId = newObj.Id;
                                    a.Active = 1;
                                    a.Score = 1;
                                    a.Name = "Rất đồng ý";
                                    a.Name2 = "Strongly agree";
                                    a.CreatedTime = DateTime.Now;
                                    await repositoryAnswer.Add(a);
                                }
                            }
                        }
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
                public async Task<IActionResult> Update([FromBody]Question model)
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
                public async Task<IActionResult> Delete([FromBody]Question model)
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
                public async Task<IActionResult> DeletePermanently([FromBody]Question model)
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
                public int CountQuestion()
                {
                    int result = repository.CountQuestion();
                    return result;
                }
            }
        }
    