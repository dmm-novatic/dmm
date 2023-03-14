
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> List();

        Task<List<ProductCategory>> Search(string keyword);
        Task<List<ProductCategory>> SearchById(string keyword);
        Task<List<ProductCategory>> ListPaging(int pageIndex, int pageSize);

        Task<List<ProductCategory>> Detail(int? postId);

        Task<ProductCategory> Add(ProductCategory ProductCategory);

        Task Update(ProductCategory ProductCategory);

        Task Delete(ProductCategory ProductCategory);

        Task<int> DeletePermanently(int? ProductCategoryId);

        int CountProductCategory();
    }
}
