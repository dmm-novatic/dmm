
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IShopRepository
    {
        Task<List<Shop>> List();

        Task<List<Shop>> ListTop5();

        Task<List<Shop>> Search(string keyword);

        Task<List<Shop>> ListPaging(int pageIndex, int pageSize);

        Task<List<Shop>> Detail(int? postId);
        Task<List<Shop>> ListByAccountId(int id);
        Task<List<Shop>> DetailByAccountId(int? accountId);

        Task<Shop> Add(Shop Shop);

        Task Update(Shop Shop);

        Task Delete(Shop Shop);

        Task<int> DeletePermanently(int? ShopId);

        int CountShop();

        Shop GetShopbyID(int ID);


    }
}
