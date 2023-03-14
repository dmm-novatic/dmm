
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface IFavouritePostRepository
    {
        Task<List<FavouritePost>> List();

        Task<List<FavouritePost>> Search(string keyword);

        Task<List<FavouritePost>> ListPaging(int pageIndex, int pageSize);

        Task<List<FavouritePost>> Detail(int? postId);

        Task<List<FavouritePost>> DetailFromUserIDAndPostID(int? userID, int? postID);

        Task<FavouritePost> Add(FavouritePost FavouritePost);

        Task Update(FavouritePost FavouritePost);

        Task Delete(FavouritePost FavouritePost);

        Task<int> DeletePermanently(int? FavouritePostId);
    }
}
