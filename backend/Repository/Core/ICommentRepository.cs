
using Novatic.Models;
using Novatic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface ICommentRepository
    {
        Task<List<CommentViewModel>> List();
        Task<List<CommentViewModel>> ListCommentAdmin();

        Task<List<CommentViewModel>> Search(string keyword);

        Task<List<CommentViewModel>> ListPaging(int pageIndex, int pageSize);
        Task<List<CommentViewModel>> ListPagingPost(int PostID, int pageIndex, int pageSize);
        Task<List<CommentViewModel>> ListPagingUser(int UserID, int pageIndex, int pageSize);

        Task<List<CommentViewModel>> Detail(int? postId);

        Task<Comment> Add(Comment Comment);

        Task Update(Comment Comment);

        Task Delete(Comment Comment);

        Task<int> DeletePermanently(int? CommentId);

        int CountCommentUnChecked();
    }
}
