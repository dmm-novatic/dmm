using A2F.Util.ADO.DAO;
using Novatic.Models;
using Novatic.ViewModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Util.ADO
{
    public class AutoCreatePostService
    {
        private static Post MapObject(SqlDataReader oReader)
        {
            Post post = new Post();
            post.Id = Convert.ToInt32(oReader["Id"]);
            post.Name = Convert.ToString(oReader["Name"]);
            post.Active = Convert.ToInt32(oReader["Active"]);
            post.GuId = Convert.ToString(oReader["GuId"]);
            post.PostTypeId = Convert.ToInt32(oReader["PostTypeId"]);
            post.PostAccountId = Convert.ToInt32(oReader["PostAccountId"]);
            post.PostCategoryId = Convert.ToInt32(oReader["PostCategoryId"]);
            post.PostLayoutId = Convert.ToInt32(oReader["PostLayoutId"]);
            post.PostPublishStatusId = Convert.ToInt32(oReader["PostPublishStatusId"]);
            post.PostCommentStatusId = Convert.ToInt32(oReader["PostCommentStatusId"]);
            post.Photo = Convert.ToString(oReader["Photo"]);
            post.ViewCount = Convert.ToInt32(oReader["ViewCount"]);
            post.CommentCount = Convert.ToInt32(oReader["CommentCount"]);
            post.LikeCount = Convert.ToInt32(oReader["LikeCount"]);
            post.Url = Convert.ToString(oReader["Url"]);
            post.Url2 = Convert.ToString(oReader["Url2"]);
            post.Name = Convert.ToString(oReader["Name"]);
            post.Name2 = Convert.ToString(oReader["Name2"]);
            post.Description = Convert.ToString(oReader["Description"]);
            post.Description2 = Convert.ToString(oReader["Description2"]);
            post.Text = Convert.ToString(oReader["Text"]);
            post.Text2 = Convert.ToString(oReader["Text2"]);
            post.CreatedTime = Convert.ToDateTime(oReader["CreatedTime"]);
            post.OpenTime = Convert.ToDateTime(oReader["OpenTime"]);
            post.ClosedTime = Convert.ToDateTime(oReader["ClosedTime"]);
            post.EventAddress = Convert.ToString(oReader["EventAddress"]);
            return post;
        }
        private static PostViewModel MapObjectViewModel(SqlDataReader oReader)
        {
            PostViewModel post = new PostViewModel();
            post.Id = Convert.ToInt32(oReader["Id"]);
            post.Name = Convert.ToString(oReader["Name"]);
            post.Active = Convert.ToInt32(oReader["Active"]);
            post.GuId = Convert.ToString(oReader["GuId"]);
            post.PostTypeId = Convert.ToInt32(oReader["PostTypeId"]);
            post.PostAccountId = Convert.ToInt32(oReader["PostAccountId"]);
            post.PostCategoryId = Convert.ToInt32(oReader["PostCategoryId"]);
            post.PostLayoutId = Convert.ToInt32(oReader["PostLayoutId"]);
            post.PostPublishStatusId = Convert.ToInt32(oReader["PostPublishStatusId"]);
            post.PostCommentStatusId = Convert.ToInt32(oReader["PostCommentStatusId"]);
            post.Photo = Convert.ToString(oReader["Photo"]);
            post.ViewCount = Convert.ToInt32(oReader["ViewCount"]);
            post.CommentCount = Convert.ToInt32(oReader["CommentCount"]);
            post.LikeCount = Convert.ToInt32(oReader["LikeCount"]);
            post.Url = Convert.ToString(oReader["Url"]);
            post.Url2 = Convert.ToString(oReader["Url2"]);
            post.Name = Convert.ToString(oReader["Name"]);
            post.Name2 = Convert.ToString(oReader["Name2"]);
            post.Description = Convert.ToString(oReader["Description"]);
            post.Description2 = Convert.ToString(oReader["Description2"]);
            post.Text = Convert.ToString(oReader["Text"]);
            post.Text2 = Convert.ToString(oReader["Text2"]);
            post.CreatedTime = Convert.ToDateTime(oReader["CreatedTime"]);
            post.OpenTime = Convert.ToDateTime(oReader["OpenTime"]);
            post.ClosedTime = Convert.ToDateTime(oReader["ClosedTime"]);
            post.EventAddress = Convert.ToString(oReader["EventAddress"]);
            return post;
        }
        private static List<Post> CreateObjects(SqlDataReader reader)
        {
            List<Post> posts = new List<Post>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Post post = new Post();
                    post = CreateObject(reader);
                    posts.Add(post);
                }
            }
            return posts;
        }
        private static Post CreateObject(SqlDataReader reader)
        {
            Post post = new Post();
            post = MapObject(reader);
            return post;
        }
        public static List<PostViewModel> CreatePost2(string query, PostViewModel objPost)
        {
            DbConnection Conn = new DbConnection();
            List<PostViewModel> listPost = new List<PostViewModel>();
            Conn.Open();
            SqlDataReader reader = null;
            reader = AutoCreatePostDAO.CreatePost2(Conn, query, objPost);
            if (reader.HasRows)
            {
                listPost = CreateObjectsViewModel(reader);
            }
            Conn.Close();
            return listPost;
        }
        private static List<PostViewModel> CreateObjectsViewModel(SqlDataReader reader)
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    PostViewModel post = new PostViewModel();
                    post = CreateObjectViewModel(reader);
                    posts.Add(post);
                }
            }
            return posts;
        }
        private static PostViewModel CreateObjectViewModel(SqlDataReader reader)
        {
            PostViewModel post = new PostViewModel();
            post = MapObjectViewModel(reader);
            return post;
        }
        public static List<PostViewModel> UpdatePost(string query, int Id, string slug, string slug2)
        {
            DbConnection Conn = new DbConnection();
            List<PostViewModel> listPost = new List<PostViewModel>();
            Conn.Open();
            SqlDataReader reader = null;
            var Url = "" + Id + "-" + slug + "";
            var Url2 = "" + Id + "-" + slug2 + "";
            reader = AutoCreatePostDAO.UpdatePost(Conn, query, Id, Url, Url2);
            Conn.Close();
            return listPost;
        }
        public static List<Post> Query(string query)
        {
            DbConnection Conn = new DbConnection();
            List<Post> listPost = new List<Post>();
            Conn.Open();
            SqlDataReader reader = null;
            reader = AutoCreatePostDAO.Query(Conn, query);
            if (reader.HasRows)
            {
                listPost = CreateObjects(reader);
            }
            Conn.Close();
            return listPost;
        }
    }
}
