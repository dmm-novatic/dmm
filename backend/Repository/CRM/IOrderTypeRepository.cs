  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IOrderTypeRepository
        {
            Task<List<OrderType>> List();

            Task<List<OrderType>> Search(string keyword);

            Task<List<OrderType>> ListPaging(int pageIndex, int pageSize);

            Task<List<OrderType>> Detail(int? postId);

            Task<OrderType> Add(OrderType OrderType);

            Task Update(OrderType OrderType);

            Task Delete(OrderType OrderType);

            Task<int> DeletePermanently(int? OrderTypeId);

            int CountOrderType();
        }
    }
    