  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IProductMetaRepository
        {
            Task<List<ProductMeta>> List();

            Task<List<ProductMeta>> Search(string keyword);

            Task<List<ProductMeta>> ListByProductMeta(int productID);

            Task<List<ProductMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<ProductMeta>> Detail(int? postId);

            Task<ProductMeta> Add(ProductMeta ProductMeta);

            Task Update(ProductMeta ProductMeta);

            Task Delete(ProductMeta ProductMeta);

            Task<int> DeletePermanently(int? ProductMetaId);

            int CountProductMeta();
        }
    }
    