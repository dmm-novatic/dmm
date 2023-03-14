using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.ViewModel;

namespace Novatic.Repository
{
    public interface IPostMetaRepository
    {
        Task<List<PostMetaViewModel>> List();

        Task<List<PostMetaViewModel>> Search(string keyword);

        Task<List<PostMeta>> ListByCategoryID(int postCategoryID, int pageIndex, int pageSize);

        Task<List<PostMetaViewModel>> ListPaging(int pageIndex, int pageSize);

        Task<List<PostMetaViewModel>> Detail(int? postId);

        Task<PostMeta> Add(PostMeta PostMeta);

        Task Update(PostMeta PostMeta);

        Task Delete(PostMeta PostMeta);

        Task<int> DeletePermanently(int? PostMetaId);
    }
}
