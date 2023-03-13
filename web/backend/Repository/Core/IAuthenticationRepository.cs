  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IAuthenticationRepository
        {
            Task<List<Authentication>> List();

            Task<List<Authentication>> Search(string keyword);

            Task<List<Authentication>> ListPaging(int pageIndex, int pageSize);

            Task<List<Authentication>> Detail(int? postId);

            Task<Authentication> Add(Authentication Authentication);

            Task Update(Authentication Authentication);

            Task Delete(Authentication Authentication);

            Task<int> DeletePermanently(int? AuthenticationId);
        }
    }
    