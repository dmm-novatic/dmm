  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IPromotionMetaRepository
        {
            Task<List<PromotionMeta>> List();

            Task<List<PromotionMeta>> Search(string keyword);

            Task<List<PromotionMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<PromotionMeta>> Detail(int? postId);

            Task<PromotionMeta> Add(PromotionMeta PromotionMeta);

            Task Update(PromotionMeta PromotionMeta);

            Task Delete(PromotionMeta PromotionMeta);

            Task<int> DeletePermanently(int? PromotionMetaId);

            int CountPromotionMeta();
        }
    }
    