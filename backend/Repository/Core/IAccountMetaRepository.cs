  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IAccountMetaRepository
        {
            Task<List<AccountMeta>> List();

            Task<List<AccountMeta>> Search(string keyword);

            Task<List<AccountMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<AccountMeta>> Detail(int? postId);

            Task<AccountMeta> Add(AccountMeta AccountMeta);

            Task Update(AccountMeta AccountMeta);

            Task Delete(AccountMeta AccountMeta);

            Task<int> DeletePermanently(int? AccountMetaId);
        }
    }
    