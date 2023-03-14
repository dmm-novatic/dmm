  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IShopMetaRepository
        {
            Task<List<ShopMeta>> List();

            Task<List<ShopMeta>> Search(string keyword);

            Task<List<ShopMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<ShopMeta>> Detail(int? postId);

            Task<ShopMeta> Add(ShopMeta ShopMeta);

            Task Update(ShopMeta ShopMeta);

            Task Delete(ShopMeta ShopMeta);

            Task<int> DeletePermanently(int? ShopMetaId);

            int CountShopMeta();
        }
    }
    