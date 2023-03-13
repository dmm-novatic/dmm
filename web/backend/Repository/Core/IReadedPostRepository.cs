  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IReadedPostRepository
        {
            Task<List<ReadedPost>> List();

            Task<List<ReadedPost>> Search(string keyword);

            Task<List<ReadedPost>> ListPaging(int pageIndex, int pageSize);

            Task<List<ReadedPost>> Detail(int? postId);

            Task<ReadedPost> Add(ReadedPost ReadedPost);

            Task Update(ReadedPost ReadedPost);

            Task Delete(ReadedPost ReadedPost);

            Task<int> DeletePermanently(int? ReadedPostId);
            Task<List<ReadedPost>> DetailReadedPostByUserIDAndPostID(int? userID, int? postID);
        }
    }
    