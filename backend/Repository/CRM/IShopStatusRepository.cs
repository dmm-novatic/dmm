  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IShopStatusRepository
        {
            Task<List<ShopStatus>> List();

            Task<List<ShopStatus>> Search(string keyword);

            Task<List<ShopStatus>> ListPaging(int pageIndex, int pageSize);

            Task<List<ShopStatus>> Detail(int? postId);

            Task<ShopStatus> Add(ShopStatus ShopStatus);

            Task Update(ShopStatus ShopStatus);

            Task Delete(ShopStatus ShopStatus);

            Task<int> DeletePermanently(int? ShopStatusId);

            int CountShopStatus();
        }
    }
    