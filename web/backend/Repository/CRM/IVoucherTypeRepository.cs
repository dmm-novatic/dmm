  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IVoucherTypeRepository
        {
            Task<List<VoucherType>> List();

            Task<List<VoucherType>> Search(string keyword);

            Task<List<VoucherType>> ListPaging(int pageIndex, int pageSize);

            Task<List<VoucherType>> Detail(int? postId);

            Task<VoucherType> Add(VoucherType VoucherType);

            Task Update(VoucherType VoucherType);

            Task Delete(VoucherType VoucherType);

            Task<int> DeletePermanently(int? VoucherTypeId);

            int CountVoucherType();
        }
    }
    