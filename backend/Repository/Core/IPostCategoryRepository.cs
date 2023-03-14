  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IPostCategoryRepository
        {
            Task<List<PostCategory>> List();

            Task<List<PostCategory>> Search(string keyword);
            Task<List<PostCategory>> DetailBySlug(string slug);

            Task<List<PostCategory>> ListPaging(int pageIndex, int pageSize);

            Task<List<PostCategory>> Detail(int? postId);

            Task<List<PostCategory>> ListbyParentId(int? parentId);

            Task<List<PostCategory>> Detail(string slug);

            Task<PostCategory> Add(PostCategory PostCategory);

            Task Update(PostCategory PostCategory);

            Task Delete(PostCategory PostCategory);

            Task<int> DeletePermanently(int? PostCategoryId);
        Task<List<PostCategory>> ListByNews();
        Task<List<PostCategory>> ListByPhuluc5();
        Task<List<PostCategory>> ListByLessonLearned();

        Task<List<PostCategory>> ListByEvents();
        Task<List<PostCategory>> ListByLibrary();
        }
    }
    