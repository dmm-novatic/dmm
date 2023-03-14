  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IProductDiscountTypeRepository
        {
            Task<List<ProductDiscountType>> List();

            Task<List<ProductDiscountType>> Search(string keyword);

            Task<List<ProductDiscountType>> ListPaging(int pageIndex, int pageSize);

            Task<List<ProductDiscountType>> Detail(int? postId);

            Task<ProductDiscountType> Add(ProductDiscountType ProductDiscountType);

            Task Update(ProductDiscountType ProductDiscountType);

            Task Delete(ProductDiscountType ProductDiscountType);

            Task<int> DeletePermanently(int? ProductDiscountTypeId);

            int CountProductDiscountType();
        }
    }
    