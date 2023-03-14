  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IOrderMetaRepository
        {
            Task<List<OrderMeta>> List();

            Task<List<OrderMeta>> Search(string keyword);

            Task<List<OrderMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<OrderMeta>> Detail(int? postId);

            Task<OrderMeta> Add(OrderMeta OrderMeta);

            Task Update(OrderMeta OrderMeta);

            Task Delete(OrderMeta OrderMeta);

            Task<int> DeletePermanently(int? OrderMetaId);

            int CountOrderMeta();
        }
    }
    