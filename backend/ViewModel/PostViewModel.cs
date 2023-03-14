using A2F.Util.ADO;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public int PostAccountId { get; set; }
        public string PostAccountName { get; set; }
        public string PostAccountPhoto { get; set; }
        public string PostAccountURL { get; set; }
        public string PostAccountInfo { get; set; }
        public int PostCategoryId { get; set; }
        public string PostCategoryName { get; set; }
        public string PostCategoryColor { get; set; }
        public string PostCategoryName2 { get; set; }
        public string PostCategoryURL { get; set; }
        public int PostLayoutId { get; set; }
        public string PostLayoutName { get; set; }
        public int PostPublishStatusId { get; set; }
        public int PostCommentStatusId { get; set; }
        public int Active { get; set; }
        public string Url { get; set; }
        public string Url2 { get; set; }
        public string GuId { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public int? ViewCount { get; set; }
        public int? CommentCount { get; set; }
        public int? LikeCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public string Text2 { get; set; }
        public DateTime? PublishedTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public DateTime OpenTime { get; set; }

        public DateTime ClosedTime { get; set; }
        public string EventAddress { get; set; }
        public string FileUrl { get; set; }
        public int? CountPost { get; set; }
       
        public static List<PostViewModel> CreatePost(PostViewModel objPost)
        {
            string query = @"insert into Post(PostTypeID, PostAccountID, PostCategoryID, PostLayoutID, PostPublishStatusID, PostCommentStatusID, Active,Url,Url2,GuId,Photo,Video, ViewCount, CommentCount, LikeCount,  Name, Name2, Description,Description2, Text,Text2,PublishedTime,CreatedTime,OpenTime,ClosedTime,EventAddress)
              values(@PostTypeID, @PostAccountID, @PostCategoryID, @PostLayoutID, @PostPublishStatusID, @PostCommentStatusID, @Active,@Url,@Url2,@GuId,@Photo,@Video, @ViewCount, @CommentCount, @LikeCount,  @Name, @Name2, @Description,@Description2, @Text,@Text2,@PublishedTime,@CreatedTime,@OpenTime,@ClosedTime,@EventAddress);
            SELECT * FROM Post WHERE Id = SCOPE_IDENTITY();";

            return AutoCreatePostService.CreatePost2(query, objPost);
        }

        public static List<PostViewModel> UpdatePost(int id, string slug, string slug2)
        {
            string query = @"Update Post set Url = @Url, Url2 = @Url2 where Id = @Id";

            return AutoCreatePostService.UpdatePost(query, id, slug, slug2);
        }
    }
}
