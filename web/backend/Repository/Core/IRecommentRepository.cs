
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IRecommentRepository
    {
        Task<List<Recomment>> List();

        Task<List<Recomment>> Search(string keyword);

        Task<List<Recomment>> ListPaging(int pageIndex, int pageSize);

        Task<List<Recomment>> Detail(int? postId);

        Task<Recomment> Add(Recomment Recomment);

        Task Update(Recomment Recomment);

        Task Delete(Recomment Recomment);

        Task<int> DeletePermanently(int? RecommentId);

        int CountRecomment();
        Task<List<Recomment>> ListBySurveySectionId(int surveySectionId);
        }
}
