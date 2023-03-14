using Novatic.ViewModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.Util.ADO.DAO
{
    public class AutoCreatePostDAO
    {
        public static SqlDataReader CreatePost2(DbConnection conn, String query, PostViewModel objPost)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@PostTypeID", objPost.PostTypeId);
            sqlCommand.Parameters.AddWithValue("@PostAccountID", objPost.PostAccountId);
            sqlCommand.Parameters.AddWithValue("@PostCategoryID", objPost.PostCategoryId);
            sqlCommand.Parameters.AddWithValue("@PostLayoutID", objPost.PostLayoutId);
            sqlCommand.Parameters.AddWithValue("@PostPublishStatusID", objPost.PostPublishStatusId);
            sqlCommand.Parameters.AddWithValue("@PostCommentStatusID", objPost.PostCommentStatusId);
            sqlCommand.Parameters.AddWithValue("@Active", objPost.Active);
            sqlCommand.Parameters.AddWithValue("@Url", objPost.Url ?? "");
            sqlCommand.Parameters.AddWithValue("@Url2", objPost.Url2 ?? "");
            sqlCommand.Parameters.AddWithValue("@GuId", objPost.GuId ?? "");
            sqlCommand.Parameters.AddWithValue("@Photo", objPost.Photo ?? "");
            sqlCommand.Parameters.AddWithValue("@Video", objPost.Video ?? "");
            sqlCommand.Parameters.AddWithValue("@ViewCount", objPost.ViewCount);
            sqlCommand.Parameters.AddWithValue("@CommentCount", objPost.CommentCount);
            sqlCommand.Parameters.AddWithValue("@LikeCount", objPost.LikeCount);
            sqlCommand.Parameters.AddWithValue("@Name", objPost.Name ?? "");
            sqlCommand.Parameters.AddWithValue("@Name2", objPost.Name2 ?? "");
            sqlCommand.Parameters.AddWithValue("@Description", objPost.Description ?? "");
            sqlCommand.Parameters.AddWithValue("@Description2", objPost.Description2 ?? "");
            sqlCommand.Parameters.AddWithValue("@Text", objPost.Text ?? "");
            sqlCommand.Parameters.AddWithValue("@Text2", objPost.Text2 ?? "");
            sqlCommand.Parameters.AddWithValue("@PublishedTime", objPost.PublishedTime);
            sqlCommand.Parameters.AddWithValue("@CreatedTime", objPost.CreatedTime);
            sqlCommand.Parameters.AddWithValue("@OpenTime", objPost.OpenTime);
            sqlCommand.Parameters.AddWithValue("@ClosedTime", objPost.ClosedTime);
            sqlCommand.Parameters.AddWithValue("@EventAddress", objPost.EventAddress);
            // giá trị mặc định
            sqlCommand.CommandText = @"insert into Post(Active,PostTypeId,PostAccountId,PostCategoryId,PostLayoutId,PostPublishStatusId,PostCommentStatusId,AuthorId,Photo,ViewCount,CommentCount,LikeCount,Url,Url2,Name,Name2,Description,Text) values (1,10001,1000001,1000003,10008,1000002,1000001,1000006,N'https://vietpat.vn/wp-content/uploads/2016/05/nghi-dinh2.jpg',2,0,0,'1000056-mac-dinh','1000056-mac-dinh','Test','Test','Test','Test')";
            if (query.Length > 1)
            {
                sqlCommand.CommandText = query;
            }
            sqlCommand.Connection = conn.oConn;//connection Establish
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand.ExecuteReader();
        }
        public static SqlDataReader UpdatePost(DbConnection conn, String query, Int32 Id, String Url, String Url2)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@Url", Url);
            sqlCommand.Parameters.AddWithValue("@Url2", Url2);
            sqlCommand.CommandText = @"insert into Post(Active,PostTypeId,PostAccountId,PostCategoryId,PostLayoutId,PostPublishStatusId,PostCommentStatusId,AuthorId,Photo,ViewCount,CommentCount,LikeCount,Url,Url2,Name,Name2,Description,Text) values (1,10001,1000001,1000003,10008,1000002,1000001,1000006,N'https://vietpat.vn/wp-content/uploads/2016/05/nghi-dinh2.jpg',2,0,0,'1000056-mac-dinh','1000056-mac-dinh','Test','Test','Test','Test')";
            if (query.Length > 1)
            {
                sqlCommand.CommandText = query;
            }
            sqlCommand.Connection = conn.oConn;//connection Establish
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand.ExecuteReader();
        }
        public static SqlDataReader Query(DbConnection Conn, String query)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = @"Select * from Post where Active = 1";

            if (query.Length > 1)
            {
                sqlCommand.CommandText = query;
            }

            sqlCommand.Connection = Conn.oConn;//connection Establish
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand.ExecuteReader();
        }
    }
}
