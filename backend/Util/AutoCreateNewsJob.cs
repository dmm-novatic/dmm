using A2F.Models;
using Novatic.Models;
using Novatic.ViewModel;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace A2F.Util
{
    public class AutoCreateNewsJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //1.Từ Api của cục lấy ID của bài viết
            #region
            using (WebClient clientWeb = new WebClient())
            {
                HttpClient clientUrl = new HttpClient();
                clientUrl.BaseAddress = new Uri("https://api.business.gov.vn/");
                clientUrl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var dateTimeNow = DateTime.Now;
                var apiUrl = @"api/services/app/CmsPostTranslation/GetAll?Statuses=1&Statuses=3&PostType=0&ExcludePostIds=738&ExcludePostIds=733&ExcludePostIds=730&ExcludePostIds=703&ExcludePostIds=702&Language=vi&PublicDateTimeTo=" + dateTimeNow + "&MaxResultCount=10000&Sorting=core.publishedTime%20desc&SkipCount=0";
                HttpResponseMessage responseUrl = clientUrl.GetAsync(apiUrl).Result;
                if (responseUrl.IsSuccessStatusCode)
                {
                    var ObjResponseUrl = responseUrl.Content.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<ResponeDataViewModel>(ObjResponseUrl);
                    for (int i = 0; i < obj.result.items.Count; i++)
                    {
                        var item = obj.result.items[i];
                        //2.Chọc vào api lấy thông tin bài viết
                        #region
                        var apiUrlDetailPost = "api/services/app/CmsPost/Get?Id=" + item.core.id + "";
                        HttpResponseMessage responseUrlDetail = clientUrl.GetAsync(apiUrlDetailPost).Result;
                        if (responseUrlDetail.IsSuccessStatusCode)
                        {
                            var ObjResponseUrlDetailPost = responseUrlDetail.Content.ReadAsStringAsync().Result;
                            var objDetailPost = JsonConvert.DeserializeObject<ResponseDataDetailPostViewModel>(ObjResponseUrlDetailPost);
                            //3. Validate xem đã tồn tại bài viết chưa
                            var ListPost = Post.GetPost();
                            var FindPostObj = ListPost.FindAll(x => x.GuId == item.core.id.ToString());
                            if (FindPostObj.Count == 0)
                            {
                                var categoryId = 0;
                                //3.1 Kiểm tra xem và phân loại categoryId
                                //3.1.1 Quỹ đầu tư
                                if (item.core.cmsPostCategories[0].categoryId == 60)
                                {
                                    categoryId = 10302;
                                }
                                else if (item.core.cmsPostCategories[0].categoryId == 50 || item.core.cmsPostCategories[0].categoryId == 53 || item.core.cmsPostCategories[0].categoryId == 54)
                                {
                                    categoryId = 10295;
                                }
                                else if (item.core.cmsPostCategories[0].categoryId == 49 || item.core.cmsPostCategories[0].categoryId == 48 || item.core.cmsPostCategories[0].categoryId == 47)
                                {
                                    categoryId = 10296;
                                }
                                else if (item.core.cmsPostCategories[0].categoryId == 46)
                                {
                                    categoryId = 10303;
                                }
                                else if (item.core.cmsPostCategories[0].categoryId == 45)
                                {
                                    categoryId = 10304;
                                }
                                var urlPage = "<p><strong>Nguồn: <a href='https://business.gov.vn/cms/tin-tuc-su-kien/chi-tiet/" + item.core.id + "/" + item.slug + "'>https://business.gov.vn/cms/tin-tuc-su-kien/chi-tiet/" + item.core.id + "/" + item.slug + "</a></strong></p>";
                                var slide = "";
                                var objCheckImage = item.core.fileVaults.FindAll(x => x.filePath.Contains("jpg") || x.filePath.Contains("png") || x.filePath.Contains("jpeg") || x.filePath.Contains("JPG") || x.filePath.Contains("PNG") || x.filePath.Contains("JPEG"));
                                if (objCheckImage.Count > 1)
                                {
                                    var liInSlide = "";
                                    var imageInSlide = "";
                                    for (int j = 0; j < objCheckImage.Count; j++)
                                    {
                                        if (j == 0)
                                        {
                                            liInSlide += "<li data-target='#myCarousel' data-slide-to='"+j+"' class='active'></li>";
                                            imageInSlide += @"<div class='item active'>
                                                                <img src='https://api.business.gov.vn/medias/" + objCheckImage[j].filePath + @"' alt='" + objCheckImage[j].fileName + @"'>
                                                              </div>";
                                        }
                                        else
                                        {
                                            liInSlide += "<li data-target='#myCarousel' data-slide-to='" + j + "'></li>";
                                            imageInSlide += @"<div class='item'>
                                                                <img src='https://api.business.gov.vn/medias/" + objCheckImage[j].filePath + @"' alt='" + objCheckImage[j].fileName + @"'>
                                                              </div>";
                                        }
                                    }
                                    slide = @" <div id='myCarousel' class='carousel slide' data-ride='carousel'>
                                              <!-- Indicators -->
                                              <ol class='carousel-indicators'>
                                                " + liInSlide + @"
                                              </ol>

                                              <!-- Wrapper for slides -->
                                              <div class='carousel-inner'>
                                                 " + imageInSlide + @"
                                              </div>

                                              <!-- Left and right controls -->
                                              <a class='left carousel-control' href='#myCarousel' data-slide='prev'>
                                                <span class='glyphicon glyphicon-chevron-left'></span>
                                                <span class='sr-only'>Previous</span>
                                              </a>
                                              <a class='right carousel-control' href='#myCarousel' data-slide='next'>
                                                <span class='glyphicon glyphicon-chevron-right'></span>
                                                <span class='sr-only'>Next</span>
                                              </a>
                                            </div>";
                                }

                                //4. Lưu vào bảng
                                #region
                                var newPost = new PostViewModel();
                                newPost.PostTypeId = 10006;
                                newPost.PostAccountId = 10001;
                                newPost.PostCategoryId = categoryId;
                                newPost.PostLayoutId = 10008;
                                newPost.PostPublishStatusId = 1;
                                newPost.PostCommentStatusId = 1;
                                newPost.Active = 1;
                                newPost.Url = item.slug;
                                newPost.GuId = item.core.id.ToString();
                                newPost.Photo = "https://api.business.gov.vn/medias/" + objCheckImage[0].filePath;
                                newPost.Video = "";
                                newPost.ViewCount = 0;
                                newPost.CommentCount = 0;
                                newPost.LikeCount = 0;
                                newPost.Name = objDetailPost.result.translations[0].title;
                                newPost.Name2 = objDetailPost.result.translations[1].title;
                                newPost.Description = objDetailPost.result.translations[0].summary;
                                newPost.Description2 = objDetailPost.result.translations[1].summary;
                                newPost.Text = objDetailPost.result.translations[0].content + slide + urlPage;
                                newPost.Text2 = objDetailPost.result.translations[1].content + slide + urlPage ;
                                newPost.PublishedTime = item.core.publishedTime;
                                newPost.CreatedTime = DateTime.Now;
                                newPost.OpenTime = new DateTime(2019, 01, 01);
                                newPost.ClosedTime = new DateTime(2019, 01, 01);
                                newPost.EventAddress = "";
                                try
                                {
                                    var newData = PostViewModel.CreatePost(newPost);
                                    PostViewModel.UpdatePost(newData[0].Id, newData[0].Url, newData[0].Url2);
                                }
                                catch (Exception e)
                                {

                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }
    }
}
