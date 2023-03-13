  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ITransactionStatusRepository
        {
            Task<List<TransactionStatus>> List();

            Task<List<TransactionStatus>> Search(string keyword);

            Task<List<TransactionStatus>> ListPaging(int pageIndex, int pageSize);

            Task<List<TransactionStatus>> Detail(int? postId);

            Task<TransactionStatus> Add(TransactionStatus TransactionStatus);

            Task Update(TransactionStatus TransactionStatus);

            Task Delete(TransactionStatus TransactionStatus);

            Task<int> DeletePermanently(int? TransactionStatusId);

            int CountTransactionStatus();
        }
    }
    