
using Novatic.Models;
using Novatic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IPostRepository
    {
        Task<List<PostViewModel>> List();
        Task<List<PostViewModel>> ListHottestPost();

        Task<List<PostViewModel>> ListInAdmin();
        Task<List<PostViewModel>> ListPhuluc5InAdmin();
        Task<List<PostViewModel>> ListLessonLearnedInAdmin();

        Task<List<PostViewModel>> ListInAdvanceSearch();
        Task<List<PostViewModel>> ListByUnsetCate();

        Task<List<PostViewModel>> ListCategory(string categorySlug);

        Task<List<PostViewModel>> ListCategoryPaging(int categoryID, int pageIndex, int pageSize, int currentIDBigest);
        Task<List<PostViewModel>> ListCategoryPagingRecursiveInPost(int listAllID, int pageIndex, int pageSize, int currentIDBigest);
        Task<List<PostViewModel>> ListCategoryPagingRecursiveInPostMeta(int listAllID, int pageIndex, int pageSize, int currentIDBigest);
        Task<List<PostViewModel>> ListCategoryPagingRecursive(int listAllID, int pageIndex, int pageSize, int currentIDBigest);
        Task<List<PostViewModel>> ListCategoryPaging(string categorySlug, int pageIndex, int pageSize, int currentIDBigest);

        Task<List<PostViewModel>> ListTag(string tagSlug);
        Task<List<Post>> CheckExistInChartCategory(string postName, int postCategoryID);
        Task<List<PostViewModel>> ListSimilarPost(int postId);

        Task<List<PostViewModel>> ListTagPaging(string tagSlug, int pageIndex, int pageSize,int currentIDBigest);
        
        Task<List<PostViewModel>> ListAuthorPaging(string authorUsername, int pageIndex, int pageSize,int currentIDBigest);
        Task<List<PostViewModel>> ListSearchPaging(string keyWord, int pageIndex, int pageSize,int currentIDBigest);

        Task<List<PostViewModel>> ListSearchPagingCreatedTime(int pageIndex, int pageSize, DateTime fromCreatedTime, DateTime toCreatedTime);


        Task<List<PostViewModel>> ListLatest();

        Task<List<PostViewModel>> ListLatestPopular();

        Task<List<PostViewModel>> Search(string keyword);
        Task<List<PostViewModel>> SearchInAdmin(string keyword);
        Task<List<PostViewModel>> SearchInAdvanceSearch(string keyword);

        Task<List<PostViewModel>> ListPaging(int pageIndex, int pageSize);
        Task<List<Post>> ListPagingInAdmin(int pageIndex, int pageSize);

        Task<List<Post>> ListPagingPost(int pageIndex, int pageSize);
        Task<List<Post>> ListPagingPhuluc5(int pageIndex, int pageSize);

        Task<List<PostViewModel>> Detail(int? postId);

        Task<Post> Add(Post Post);

        Task Update(Post Post);

        Task Delete(Post Post);

        Task<int> DeletePermanently(int? PostId);
        Task<List<PostViewModel>> ListFavouritePost(int UserID, int pageIndex, int pageSize);
        Task<List<PostViewModel>> ListPostByTemplateID(int layoutID, int pageIndex, int pageSize);
        Task<List<PostViewModel>> ListReadedPost(int UserID, int pageIndex, int pageSize);
        Task<List<Post>> DetailPost(int? id);
        Task<List<PostViewModel>> ListTopicPaging(string topicSlug, int pageIndex, int pageSize, int currentIDBigest);
        Task<List<PostViewModel>> ListTopic(string topicSlug);
        Task<List<PostViewModel>> ListFeaturedPost(int TypeID, int pageIndex, int pageSize);
        int CountPost();
        int CountPostUnsetCategory();
        int CountPost(int PostCategoryID);
        Task<List<Post>> ListPostTopic(string optionConditional);
        Task<List<PostViewModel>> ListEventPaging(int pageIndex, int pageSize);

        Task<List<PostViewModel>> ListAllEvent();

        Task<List<PostViewModel>> ListEventsIsGoingOnPaging(int pageIndex, int pageSize);

        Task<List<PostViewModel>> ListEventsEndedPaging(int pageIndex, int pageSize);

        Task<List<PostViewModel>> ListAllLibrary();

        Task<List<PostViewModel>> ListAllLibraryChild(int postCategoryId);

        Task<List<PostViewModel>> ListLibraryIsGoingOnPaging(int postCategoryId, int pageIndex, int pageSize);
        Task<List<Post>> ListLearnedLesson();
        Task<List<Post>> ListLegalrecords();
        Task<List<Post>> ListOperationalandfinancialrecords();
        Task<List<Post>> ListIncentivesformsandpurposesforcapitalfinancing();
        int? IncreaseLike(Post post);
        Task<List<PostViewModel>> GetSimilarPost(int id);
        Task<List<PostViewModel>> ListEventsInAdmin();
        Task<List<PostViewModel>> ListLibraryInAdmin();
    }
}
