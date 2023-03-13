  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IFeaturedPostRepository
        {
            Task<List<FeaturedPost>> List();

            Task<List<FeaturedPost>> Search(string keyword);

            Task<List<FeaturedPost>> ListPaging(int pageIndex, int pageSize);

            Task<List<FeaturedPost>> Detail(int? postId);

            Task<FeaturedPost> Add(FeaturedPost FeaturedPost);

            Task Update(FeaturedPost FeaturedPost);

            Task Delete(FeaturedPost FeaturedPost);

            Task<int> DeletePermanently(int? FeaturedPostId);
        }
    }
    