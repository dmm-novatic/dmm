
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> List();
        Task<List<Product>> ListByShopId(int shopId);

        Task<List<Product>> Search(string keyword);
        Task<List<Product>> getListProductByCate(int cateId, int pageIndex, int pageSize);

        Task<List<Product>> getListProductByCateAndName(int cateId, int pageIndex, int pageSize, string textSearch,int shopId);

        Task<List<Product>> getListProductByBrand(int branhId,int pageIndex,int pageSize);

        Task<List<Product>> getListProductByShopID(int ShopID, int pageIndex, int pageSize);

        Task<List<Product>> ListPaging(int pageIndex, int pageSize);

        Task<List<Product>> Detail(int? postId);

        Task<Product> Add(Product Product);

        Task Update(Product Product);

        Task Delete(Product Product);

        Task<int> DeletePermanently(int? ProductId);

        int CountProduct();
        int CountProductByCategory(int cateId);

        int CountProductByBrand(int brandId);
        int CountProductbyCate(int cateID);
        int CountProductByShopID(int ShopID);
        Product getListId(int productID);
    }
}
