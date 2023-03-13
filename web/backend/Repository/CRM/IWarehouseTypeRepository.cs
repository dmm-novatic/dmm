  
    using Novatic.Models.CRM; using Novatic.Models; 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IWarehouseTypeRepository
        {
            Task<List<WarehouseType>> List();

            Task<List<WarehouseType>> Search(string keyword);

            Task<List<WarehouseType>> ListPaging(int pageIndex, int pageSize);

            Task<List<WarehouseType>> Detail(int? postId);

            Task<WarehouseType> Add(WarehouseType WarehouseType);

            Task Update(WarehouseType WarehouseType);

            Task Delete(WarehouseType WarehouseType);

            Task<int> DeletePermanently(int? WarehouseTypeId);

            int CountWarehouseType();
        }
    }
    