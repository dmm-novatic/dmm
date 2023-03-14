
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IOrderTransactionRepository
    {
        Task<List<OrderTransaction>> List();

        Task<List<OrderTransaction>> Search(string keyword);

        Task<List<OrderTransaction>> ListPaging(int pageIndex, int pageSize);

        Task<List<OrderTransaction>> Detail(int? postId);
        Task<List<OrderTransaction>> ListByShopId(int shopId);

        Task<OrderTransaction> Add(OrderTransaction OrderTransaction);

        Task Update(OrderTransaction OrderTransaction);

        Task Delete(OrderTransaction OrderTransaction);

        Task<int> DeletePermanently(int? OrderTransactionId);

        int CountOrderTransaction();
        OrderTransaction GetByOrderId(int OrdersId);
    }
}
