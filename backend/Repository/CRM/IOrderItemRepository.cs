
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> List();

        Task<List<OrderItem>> Search(string keyword);

        Task<List<OrderItem>> ListPaging(int pageIndex, int pageSize);

        Task<List<OrderItem>> Detail(int? postId);

        Task<List<OrderItem>> ListByShopId(int? postId);

        Task<OrderItem> Add(OrderItem OrderItem);

        Task AddRange(List<OrderItem> OrderItem);

        Task Update(OrderItem OrderItem);

        Task Delete(OrderItem OrderItem);

        Task<int> DeletePermanently(int? OrderItemId);

        int CountOrderItem();

        Task<List<OrderItem>> ListByOrderId(int orderId);
    }
}
