  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IWarehouseStatusRepository
        {
            Task<List<WarehouseStatus>> List();

            Task<List<WarehouseStatus>> Search(string keyword);

            Task<List<WarehouseStatus>> ListPaging(int pageIndex, int pageSize);

            Task<List<WarehouseStatus>> Detail(int? postId);

            Task<WarehouseStatus> Add(WarehouseStatus WarehouseStatus);

            Task Update(WarehouseStatus WarehouseStatus);

            Task Delete(WarehouseStatus WarehouseStatus);

            Task<int> DeletePermanently(int? WarehouseStatusId);

            int CountWarehouseStatus();
        }
    }
    