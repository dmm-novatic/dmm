  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IMenuRepository
        {
            Task<List<Menu>> List();
            Task<List<Menu>> ListMenuHeader();
            Task<List<Menu>> ListMenuFooter();
            

        Task<List<Menu>> Search(string keyword);

            Task<List<Menu>> ListPaging(int pageIndex, int pageSize);

            Task<List<Menu>> Detail(int? postId);

            Task<Menu> Add(Menu Menu);

            Task Update(Menu Menu);

            Task Delete(Menu Menu);

            Task<int> DeletePermanently(int? MenuId);
        }
    }
    