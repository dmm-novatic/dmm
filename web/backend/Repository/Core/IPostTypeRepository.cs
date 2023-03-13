  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IPostTypeRepository
        {
            Task<List<PostType>> List();

            Task<List<PostType>> Search(string keyword);

            Task<List<PostType>> ListPaging(int pageIndex, int pageSize);

            Task<List<PostType>> Detail(int? postId);

            Task<PostType> Add(PostType PostType);

            Task Update(PostType PostType);

            Task Delete(PostType PostType);

            Task<int> DeletePermanently(int? PostTypeId);
        }
    }
    