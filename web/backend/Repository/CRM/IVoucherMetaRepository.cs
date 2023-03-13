  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IVoucherMetaRepository
        {
            Task<List<VoucherMeta>> List();

            Task<List<VoucherMeta>> Search(string keyword);

            Task<List<VoucherMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<VoucherMeta>> Detail(int? postId);

            Task<VoucherMeta> Add(VoucherMeta VoucherMeta);

            Task Update(VoucherMeta VoucherMeta);

            Task Delete(VoucherMeta VoucherMeta);

            Task<int> DeletePermanently(int? VoucherMetaId);

            int CountVoucherMeta();
        }
    }
    