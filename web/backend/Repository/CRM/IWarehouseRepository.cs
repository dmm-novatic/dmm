
using Novatic.Models.CRM;
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> List();

        Task<List<Warehouse>> Search(string keyword);

        Task<List<Warehouse>> ListPaging(int pageIndex, int pageSize);

        Task<List<Warehouse>> Detail(int? postId);
        Task<List<Warehouse>> ListByShopId(int? shopId);

        Task<Warehouse> Add(Warehouse Warehouse);

        Task Update(Warehouse Warehouse);

        Task Delete(Warehouse Warehouse);

        Task<int> DeletePermanently(int? WarehouseId);

        int CountWarehouse();
    }
}
