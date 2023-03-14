  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ITransactionMetaRepository
        {
            Task<List<TransactionMeta>> List();

            Task<List<TransactionMeta>> Search(string keyword);

            Task<List<TransactionMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<TransactionMeta>> Detail(int? postId);

            Task<TransactionMeta> Add(TransactionMeta TransactionMeta);

            Task Update(TransactionMeta TransactionMeta);

            Task Delete(TransactionMeta TransactionMeta);

            Task<int> DeletePermanently(int? TransactionMetaId);

            int CountTransactionMeta();
        }
    }
    