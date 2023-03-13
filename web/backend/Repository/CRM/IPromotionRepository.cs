
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> List();

        Task<List<Promotion>> Search(string keyword);

        Task<List<Promotion>> ListPaging(int pageIndex, int pageSize);

        Task<List<Promotion>> Detail(int? postId);
        Task<List<Promotion>> ListByShopId(int id);

        Task<Promotion> Add(Promotion Promotion);

        Task Update(Promotion Promotion);

        Task Delete(Promotion Promotion);

        Task<int> DeletePermanently(int? PromotionId);

        int CountPromotion();

        Promotion getByPromationID(int PromotionID);

    }
}
