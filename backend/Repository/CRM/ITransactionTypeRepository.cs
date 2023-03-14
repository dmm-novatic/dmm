  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ITransactionTypeRepository
        {
            Task<List<TransactionType>> List();

            Task<List<TransactionType>> Search(string keyword);

            Task<List<TransactionType>> ListPaging(int pageIndex, int pageSize);

            Task<List<TransactionType>> Detail(int? postId);

            Task<TransactionType> Add(TransactionType TransactionType);

            Task Update(TransactionType TransactionType);

            Task Delete(TransactionType TransactionType);

            Task<int> DeletePermanently(int? TransactionTypeId);

            int CountTransactionType();
        }
    }
    