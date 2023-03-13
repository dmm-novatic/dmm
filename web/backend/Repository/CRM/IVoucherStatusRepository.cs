  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IVoucherStatusRepository
        {
            Task<List<VoucherStatus>> List();

            Task<List<VoucherStatus>> Search(string keyword);

            Task<List<VoucherStatus>> ListPaging(int pageIndex, int pageSize);

            Task<List<VoucherStatus>> Detail(int? postId);

            Task<VoucherStatus> Add(VoucherStatus VoucherStatus);

            Task Update(VoucherStatus VoucherStatus);

            Task Delete(VoucherStatus VoucherStatus);

            Task<int> DeletePermanently(int? VoucherStatusId);

            int CountVoucherStatus();
        }
    }
    