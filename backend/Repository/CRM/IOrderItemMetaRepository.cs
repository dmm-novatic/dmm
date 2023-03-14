  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IOrderItemMetaRepository
        {
            Task<List<OrderItemMeta>> List();

            Task<List<OrderItemMeta>> Search(string keyword);

            Task<List<OrderItemMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<OrderItemMeta>> Detail(int? postId);

            Task<OrderItemMeta> Add(OrderItemMeta OrderItemMeta);

            Task Update(OrderItemMeta OrderItemMeta);

            Task Delete(OrderItemMeta OrderItemMeta);

            Task<int> DeletePermanently(int? OrderItemMetaId);

            int CountOrderItemMeta();
        }
    }
    