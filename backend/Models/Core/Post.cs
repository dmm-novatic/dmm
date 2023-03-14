using A2F.Util.ADO;
using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            FavouritePost = new HashSet<FavouritePost>();
            ReadedPost = new HashSet<ReadedPost>();
            PostMeta = new HashSet<PostMeta>();
            PostTag = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public int PostAccountId { get; set; }
        public int PostCategoryId { get; set; }
        public int PostLayoutId { get; set; }
        public int PostPublishStatusId { get; set; }
        public int PostCommentStatusId { get; set; }
        public string GuId { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public int? ViewCount { get; set; }
        public int? CommentCount { get; set; }
        public int? LikeCount { get; set; }
        public int Active { get; set; }
        public string Url { get; set; }
        public string Url2 { get; set; }
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

        public virtual Account PostAccount { get; set; }
        public virtual PostCategory PostCategory { get; set; }
        public virtual PostLayout PostLayout { get; set; }
        public virtual PostType PostType { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<FavouritePost> FavouritePost { get; set; }
        public virtual ICollection<ReadedPost> ReadedPost { get; set; }
        public virtual ICollection<PostMeta> PostMeta { get; set; }
        public virtual ICollection<PostTag> PostTag { get; set; }
        public virtual ICollection<PostTopic> PostTopic { get; set; }
        public static List<Post> GetPost()
        {
            string query = @"select * from Post where Active = 1";
            return AutoCreatePostService.Query(query);
        }
    }
}
