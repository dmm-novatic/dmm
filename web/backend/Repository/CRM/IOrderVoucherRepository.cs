  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IOrderVoucherRepository
        {
            Task<List<OrderVoucher>> List();

            Task<List<OrderVoucher>> Search(string keyword);

            Task<List<OrderVoucher>> ListPaging(int pageIndex, int pageSize);

            Task<List<OrderVoucher>> Detail(int? postId);

            Task<OrderVoucher> Add(OrderVoucher OrderVoucher);

            Task Update(OrderVoucher OrderVoucher);

            Task Delete(OrderVoucher OrderVoucher);

            Task<int> DeletePermanently(int? OrderVoucherId);

            int CountOrderVoucher();
        }
    }
    