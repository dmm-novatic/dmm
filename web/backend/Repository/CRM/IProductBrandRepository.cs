  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IProductBrandRepository
        {
            Task<List<ProductBrand>> List();

            Task<List<ProductBrand>> Search(string keyword);

            Task<List<ProductBrand>> ListPaging(int pageIndex, int pageSize);

            Task<List<ProductBrand>> Detail(int? postId);

            Task<ProductBrand> Add(ProductBrand ProductBrand);

            Task Update(ProductBrand ProductBrand);

            Task Delete(ProductBrand ProductBrand);

            Task<int> DeletePermanently(int? ProductBrandId);

            int CountProductBrand();
        }
    }
    