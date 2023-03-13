
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IOrderStatusRepository
    {
        Task<List<OrderStatus>> List();

        Task<List<OrderStatus>> Search(string keyword);

        Task<List<OrderStatus>> ListPaging(int pageIndex, int pageSize);

        Task<List<OrderStatus>> Detail(int? postId);

        Task<OrderStatus> Add(OrderStatus OrderStatus);

        Task Update(OrderStatus OrderStatus);

        Task Delete(OrderStatus OrderStatus);

        Task<int> DeletePermanently(int? OrderStatusId);

        int CountOrderStatus();

        OrderStatus GetById(int id);
    }
}
