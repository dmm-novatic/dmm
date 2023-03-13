  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ITagRepository
        {
            Task<List<Tag>> List();

            Task<List<Tag>> ListByPostID(int postID);

            Task<List<Tag>> Search(string keyword);

            Task<List<Tag>> ListPaging(int pageIndex, int pageSize);

            Task<List<Tag>> ListPagingTop(int pageIndex, int pageSize);

            Task<List<Tag>> Detail(int? postId);

            Task<List<Tag>> DetailBySlug(string slug);

            Task<Tag> Add(Tag Tag);

            Task Update(Tag Tag);

            Task Delete(Tag Tag);

            Task<int> DeletePermanently(int? TagId);

            int CountTag();
        }
    }
    