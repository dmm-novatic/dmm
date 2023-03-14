
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IOrderPaymentStatusRepository
    {
        Task<List<OrderPaymentStatus>> List();

        Task<List<OrderPaymentStatus>> Search(string keyword);

        Task<List<OrderPaymentStatus>> ListPaging(int pageIndex, int pageSize);

        Task<List<OrderPaymentStatus>> Detail(int? postId);

        Task<OrderPaymentStatus> Add(OrderPaymentStatus OrderPaymentStatus);

        Task Update(OrderPaymentStatus OrderPaymentStatus);

        Task Delete(OrderPaymentStatus OrderPaymentStatus);

        Task<int> DeletePermanently(int? OrderPaymentStatusId);

        int CountOrderPaymentStatus();
        OrderPaymentStatus GetById(int id);
    }
}
