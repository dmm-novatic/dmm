
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface ITransactionsRepository
    {
        Task<List<Transactions>> List();

        Task<List<Transactions>> Search(string keyword);

        Task<List<Transactions>> ListPaging(int pageIndex, int pageSize);

        Task<List<Transactions>> Detail(int? postId);

        Task<List<Transactions>> ListByShopId(int shopId);

        Task<Transactions> Add(Transactions Transactions);

        Task Update(Transactions Transactions);

        Task Delete(Transactions Transactions);

        Task<int> DeletePermanently(int? TransactionsId);

        int CountTransactions();

        Transactions GetById(int Id);
    }
}
