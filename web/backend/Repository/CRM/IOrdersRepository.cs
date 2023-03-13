
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IOrdersRepository
    {
        Task<List<Orders>> List();
        Task<List<Orders>> ListByShopId(int shopId);

        Task<List<Orders>> Search(string keyword);

        Task<List<Orders>> ListPaging(int pageIndex, int pageSize);

        Task<List<Orders>> Detail(int? postId);

        Task<Orders> Add(Orders Orders);

        Task Update(Orders Orders);

        Task Delete(Orders Orders);

        Task<int> DeletePermanently(int? OrdersId);

        int CountOrders();

        Task<List<Orders>> GetOrderByAcount(int AccountID , int orderStatusId);
        Orders GetORdersByOrderId(int OrderId);
        Task<List<Orders>> ListByShopId(int shopId, int orderStatusId);
    }
}
