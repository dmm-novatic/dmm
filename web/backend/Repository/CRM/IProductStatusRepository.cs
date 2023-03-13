  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IProductStatusRepository
        {
            Task<List<ProductStatus>> List();

            Task<List<ProductStatus>> Search(string keyword);

            Task<List<ProductStatus>> ListPaging(int pageIndex, int pageSize);

            Task<List<ProductStatus>> Detail(int? postId);

            Task<ProductStatus> Add(ProductStatus ProductStatus);

            Task Update(ProductStatus ProductStatus);

            Task Delete(ProductStatus ProductStatus);

            Task<int> DeletePermanently(int? ProductStatusId);

            int CountProductStatus();
        }
    }
    