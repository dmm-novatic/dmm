  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IWarehouseMetaRepository
        {
            Task<List<WarehouseMeta>> List();

            Task<List<WarehouseMeta>> Search(string keyword);

            Task<List<WarehouseMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<WarehouseMeta>> Detail(int? postId);

            Task<WarehouseMeta> Add(WarehouseMeta WarehouseMeta);

            Task Update(WarehouseMeta WarehouseMeta);

            Task Delete(WarehouseMeta WarehouseMeta);

            Task<int> DeletePermanently(int? WarehouseMetaId);

            int CountWarehouseMeta();
        }
    }
    