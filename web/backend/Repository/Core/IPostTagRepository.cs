  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IPostTagRepository
        {
            Task<List<PostTag>> List();

            Task<List<PostTag>> Search(string keyword);

            Task<List<PostTag>> ListPaging(int pageIndex, int pageSize);

            Task<List<PostTag>> Detail(int? postId);

            Task<List<PostTag>> DetailPost(int? postId);

            Task<PostTag> Add(PostTag PostTag);

            Task Update(PostTag PostTag);

            Task Delete(PostTag PostTag);

            Task<int> DeletePermanently(int? PostTagId);
            Task<List<PostTag>> DetailByTagID(int TagID);
            Task<List<PostTag>> DetailByPostIDAndTagID(int PostID, int TagID);
            int CountPost(int? TagID);

    }
}
    