
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IProductItemRepository
    {
        Task<List<ProductItem>> List();

        Task<List<ProductItem>> Search(string keyword);

        Task<List<ProductItem>> ListPaging(int pageIndex, int pageSize);

        Task<List<ProductItem>> Detail(int? postId);

        Task<ProductItem> Add(ProductItem ProductItem);

        Task Update(ProductItem ProductItem);

        Task Delete(ProductItem ProductItem);

        Task<int> DeletePermanently(int? ProductItemId);

        int CountProductItem();
        ProductItem GetByProductID(int productId);
        ProductItem GetById(int Id);

        Task<List<ProductItem>> getListProductItemByShopID(int shopId);
    }
}
