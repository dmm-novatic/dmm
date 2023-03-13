
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IVoucherRepository
    {
        Task<List<Voucher>> List();

        Task<List<Voucher>> Search(string keyword);

        Task<List<Voucher>> ListPaging(int pageIndex, int pageSize);

        Task<List<Voucher>> Detail(int? postId);

        Task<Voucher> Add(Voucher Voucher);

        Task Update(Voucher Voucher);

        Task Delete(Voucher Voucher);

        Task<int> DeletePermanently(int? VoucherId);

        int CountVoucher();

        Voucher GetVoucher(string Code);
    }
}
