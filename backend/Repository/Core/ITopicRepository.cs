  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ITopicRepository
        {
            Task<List<Topic>> List();

            Task<List<Topic>> Search(string keyword);

            Task<List<Topic>> ListPaging(int pageIndex, int pageSize);

            Task<List<Topic>> Detail(int? postId);

            Task<Topic> Add(Topic Topic);

            Task Update(Topic Topic);

            Task Delete(Topic Topic);

            Task<int> DeletePermanently(int? TopicId);
            Task<List<Topic>> DetailBySlug(string slug);
            int CountTopic();
        }
    }
    