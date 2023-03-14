  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ISubscribeRepository
        {
            Task<List<Subscribe>> List();

            Task<List<Subscribe>> Search(string keyword);

            Task<List<Subscribe>> ListPaging(int pageIndex, int pageSize);

            Task<List<Subscribe>> Detail(int? postId);

            Task<Subscribe> Add(Subscribe Subscribe);

            Task Update(Subscribe Subscribe);

            Task Delete(Subscribe Subscribe);

            Task<int> DeletePermanently(int? SubscribeId);
            Task<List<Subscribe>> DetailByEmail(string email);
    }
    }
    