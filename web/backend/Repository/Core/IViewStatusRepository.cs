  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IViewStatusRepository
        {
            Task<List<ViewStatus>> List();

            Task<List<ViewStatus>> Search(string keyword);

            Task<List<ViewStatus>> ListPaging(int pageIndex, int pageSize);

            Task<List<ViewStatus>> Detail(int? postId);

            Task<ViewStatus> Add(ViewStatus ViewStatus);

            Task Update(ViewStatus ViewStatus);

            Task Delete(ViewStatus ViewStatus);

            Task<int> DeletePermanently(int? ViewStatusId);
        }
    }
    