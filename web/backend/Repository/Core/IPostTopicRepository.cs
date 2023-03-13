
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.ViewModel;

namespace Novatic.Repository
{
    public interface IPostTopicRepository
    {
        Task<List<PostTopic>> List();

        Task<List<PostTopic>> ListByTopicId(int TopicId);
        Task<List<PostTopicViewModel>> ListViewModelByTopicId(int topicId);
        Task<List<PostTopicViewModel>> SearchViewModelByTopicId(int topicId, string keyword);
        int CountByTopicId(int topicId);

        Task<List<PostTopic>> Search(string keyword);

        Task<List<PostTopic>> ListPaging(int pageIndex, int pageSize);

        Task<List<PostTopic>> Detail(int? postId);

        Task<PostTopic> Add(PostTopic PostTopic);

        Task Update(PostTopic PostTopic);

        Task Delete(PostTopic PostTopic);

        Task<int> DeletePermanently(int? PostTopicId);
        Task<int> CheckExistForAutoCreate(int postId, int topicId);
    }
}
