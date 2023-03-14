  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IProductTypeRepository
        {
            Task<List<ProductType>> List();

            Task<List<ProductType>> Search(string keyword);

            Task<List<ProductType>> ListPaging(int pageIndex, int pageSize);

            Task<List<ProductType>> Detail(int? postId);

            Task<ProductType> Add(ProductType ProductType);

            Task Update(ProductType ProductType);

            Task Delete(ProductType ProductType);

            Task<int> DeletePermanently(int? ProductTypeId);

            int CountProductType();
        }
    }
    