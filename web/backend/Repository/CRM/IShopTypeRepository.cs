  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IShopTypeRepository
        {
            Task<List<ShopType>> List();

            Task<List<ShopType>> Search(string keyword);

            Task<List<ShopType>> ListPaging(int pageIndex, int pageSize);

            Task<List<ShopType>> Detail(int? postId);

            Task<ShopType> Add(ShopType ShopType);

            Task Update(ShopType ShopType);

            Task Delete(ShopType ShopType);

            Task<int> DeletePermanently(int? ShopTypeId);

            int CountShopType();
        }
    }
    