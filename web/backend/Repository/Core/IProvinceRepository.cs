  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IProvinceRepository
        {
            Task<List<Province>> List();

            Task<List<Province>> Search(string keyword);

            Task<List<Province>> ListPaging(int pageIndex, int pageSize);

            Task<List<Province>> Detail(int? postId);

            Task<Province> Add(Province Province);

            Task Update(Province Province);

            Task Delete(Province Province);

            Task<int> DeletePermanently(int? ProvinceId);
        }
    }
    