using Novatic.Models;
using Novatic.Util;
using Novatic.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using A2F.Util;

namespace Novatic.Repository
{
    public class PostRepository : IPostRepository
    {
        NovaticDBContext db;
        ITagRepository repositoryTag;
        IPostCategoryRepository repositoryPostCategory;
        IPostMetaRepository repositoryPostMeta;
        public PostRepository(NovaticDBContext _db, ITagRepository _repositoryTag, IPostCategoryRepository _repositoryPostCategory, IPostMetaRepository _repositoryPostMeta)
        {
            db = _db;
            repositoryTag = _repositoryTag;
            repositoryPostCategory = _repositoryPostCategory;
            repositoryPostMeta = _repositoryPostMeta;
        }


        public async Task<List<PostViewModel>> List()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListHottestPost()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        //&& (DateTime.Now.AddDays(-30) < p.PublishedTime)
                        && (p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO && p.PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN &&
                        p.PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM && p.PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_KHAO_SAT_DOANH_NGHIEP_GOOGLEFORM
                        )
                    )
                    orderby p.ViewCount descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListInAdmin()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5 && p.PostCategoryId != SystemConstant.POST_CATEGORY_SU_KIEN && p.PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI && p.PostCategoryId != 10311
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListEventsInAdmin()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && p.PostCategoryId == SystemConstant.POST_CATEGORY_SU_KIEN
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListLibraryInAdmin()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && pc.ParentID == 10299
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostViewModel>> ListPhuluc5InAdmin()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && p.PostCategoryId == SystemConstant.POST_CATEGORY_PHU_LUC_5
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListLessonLearnedInAdmin()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && (p.PostCategoryId == SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 || pc.ParentID == SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2)
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListInAdvanceSearch()
        {
            var objPostCategory = await repositoryPostCategory.DetailBySlug("Bieu-Do");
            int categoryChartId = objPostCategory[0].Id;
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && p.PostCategoryId == categoryChartId
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostViewModel>> ListByUnsetCate()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (p.PostCategoryId == 10045 || p.PostCategoryId ==10057 || p.PostCategoryId == 10058 || p.PostCategoryId == 10067 || p.PostCategoryId == 10066 || p.PostCategoryId == 10059 || p.PostCategoryId == 10021 || p.PostCategoryId == 10009 || p.PostCategoryId == 10006 || p.PostCategoryId == 10004 || p.PostCategoryId == 10003 || p.PostCategoryId == 10001)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostViewModel>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (p.Name.Contains(keyword) || p.Description.Contains(keyword) || p.Name2.Contains(keyword) || p.Description2.Contains(keyword) || p.Text.Contains(keyword) || p.Text2.Contains(keyword))
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo, 
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }
            return null;
        }

        //Update chi tin tuc
        public async Task<List<PostViewModel>> SearchInAdmin(string keyword)
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1
                        && (p.Name.Contains(keyword) || p.Description.Contains(keyword) || p.Name2.Contains(keyword) || p.Description2.Contains(keyword) || p.Text.Contains(keyword) || p.Text2.Contains(keyword))
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }
            return null;
        }

        public async Task<List<PostViewModel>> SearchInAdvanceSearch(string keyword)
        {
            var objPostCategory = await repositoryPostCategory.DetailBySlug("Bieu-Do");
            int categoryChartId = objPostCategory[0].Id;
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1
                        && (p.Name.Contains(keyword) || p.Description.Contains(keyword) || p.Name2.Contains(keyword) || p.Description2.Contains(keyword) || p.Text.Contains(keyword) || p.Text2.Contains(keyword))
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.PostCategoryId == categoryChartId
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }
            return null;
        }

        public async Task<List<PostViewModel>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && p.PostCategoryId != 10301 && p.PostCategoryId != 10300 && p.PostCategoryId != 10299 
                       
                           && p.PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5 && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                           && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && p.PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI
                           && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                           && p.PostCategoryId != SystemConstant.POST_CATEGORY_VE_CHUNG_TOI && p.PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN
                           && p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO
                           && p.PostCategoryId != SystemConstant.POST_CATEGORY_KHAO_SAT_DOANH_NGHIEP_GOOGLEFORM
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;


            //if (db != null)
            //{
            //    return await (
            //        from row in db.Post
            //        where (row.Active == 1)
            //        orderby row.Id descending
            //        select row
            //    ).Skip(offSet).Take(pageSize).ToListAsync();
            //}

            //return null;
        }

        //List 1 vài sự kiện mới nhất 
        public async Task<List<PostViewModel>> ListEventPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == 10297
                    ) 
                    orderby p.OpenTime ascending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;

        }
        //List Paging Library
        public async Task<List<PostViewModel>> ListLibraryIsGoingOnPaging(int postCategoryId,int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == postCategoryId
                        && p.OpenTime < DateTime.Now && p.ClosedTime > DateTime.Now
                    )
                    orderby p.ClosedTime descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl,
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;

        }
        //List Paging Event dang dien ra
        public async Task<List<PostViewModel>> ListEventsIsGoingOnPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == 10297
                        && p.OpenTime < DateTime.Now && p.ClosedTime > DateTime.Now
                    )
                    orderby p.ClosedTime descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl,
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;

        }

        //List Paging Event dang dien ra
        public async Task<List<PostViewModel>> ListEventsEndedPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == 10297
                        && p.ClosedTime < DateTime.Now
                    )
                    orderby p.ClosedTime descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl,
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;

        }

        // List tất cả các sự kiện sắp xếp từ mới đến cũ
        public async Task<List<PostViewModel>> ListAllEvent()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == 10297

                    )
                    orderby p.OpenTime ascending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime= p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl,
                    }
                ).ToListAsync();
            }

            return null;
        }

        // List tất cả các thư viện sắp xếp từ mới đến cũ
        public async Task<List<PostViewModel>> ListAllLibrary()
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == 10299

                    )
                    orderby p.OpenTime ascending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl,
                    }
                ).ToListAsync();
            }

            return null;
        }
        // List tất cả các thư viện sắp xếp từ mới đến cũ
        public async Task<List<PostViewModel>> ListAllLibraryChild(int postCategoryId)
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        // Category Event
                        && p.PostCategoryId == postCategoryId
                    )
                    orderby p.OpenTime ascending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        EventAddress = p.EventAddress,
                        FileUrl = p.FileUrl,
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<Post>> ListPagingInAdmin(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from row in db.Post
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;


            //if (db != null)
            //{
            //    return await (
            //        from row in db.Post
            //        where (row.Active == 1)
            //        orderby row.Id descending
            //        select row
            //    ).Skip(offSet).Take(pageSize).ToListAsync();
            //}

            //return null;
        }


        public async Task<List<PostViewModel>> ListSearchPagingCreatedTime(int pageIndex,int pageSize,DateTime fromCreatedTime,DateTime toCreatedTime)
        {
            //DateTime fromDatetime = Convert.ToDateTime(fromCreatedTime);
            //DateTime toDatetime = Convert.ToDateTime(toCreatedTime);
            //String format = "yyyyMMddThhmmss";
            //DateTime dateValue;
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    //let dateTime=p.CreatedTime.Date
                    //let dateString = p.CreatedTime.ToString()
                    //let crT = DateTime.TryParseExact(dateString, "ddMMyyyyhmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue)
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0 
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                        && p.CreatedTime >= fromCreatedTime
                        && p.CreatedTime <= toCreatedTime
                        //&& ((DateTime.Compare(fromCreatedTime, dateTime)) <= 0)
                        //&& ((DateTime.Compare(toCreatedTime, dateTime)) >= 0)
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;


            //if (db != null)
            //{
            //    return await (
            //        from row in db.Post
            //        where (row.Active == 1)
            //        orderby row.Id descending
            //        select row
            //    ).Skip(offSet).Take(pageSize).ToListAsync();
            //}

            //return null;
        }




        public async Task<List<Post>> ListPagingPost(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.Post
                    where (row.Active == 1 && row.PostPublishStatusId != 0)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }

        public async Task<List<Post>> ListPagingPhuluc5(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.Post
                    where (row.Active == 1 && row.PostPublishStatusId != 0 && row.PostCategoryId == SystemConstant.POST_CATEGORY_PHU_LUC_5)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListSimilarPost(int postId)
        {

            var dataTag = await repositoryTag.ListByPostID(postId);
            // khởi tạo 1 list PostViewModel
            List<PostViewModel> data = new List<PostViewModel>();
            if (dataTag.Count != 0)
            {
                //get list posts same tag
                data = await ListTagPaging(dataTag[0].Slug, 1, 6, 99999);
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Id == postId)
                    {
                        data.RemoveAt(i);
                    }
                }
            }


            if (data.Count < 6)
            {
                //get list post same category
                var dataPost = await Detail(postId);
                //int soBaiConThieu = 6 - data.Count;
                var dataByCate = await ListCategoryPaging(dataPost[0].PostCategoryId, 1, 10, 99999);
                for (int i = 0; i < dataByCate.Count; i++)
                {
                    if (data.Count <= 6)
                    {
                        if (dataByCate[i].Id != postId)
                        {
                            data.Add(dataByCate[i]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            if (data.Count < 6)
            {
                var dataPost = await Detail(postId);
                //int soBaiConThieu = 6 - data.Count;
                var dataListChildCate = await repositoryPostCategory.ListbyParentId(dataPost[0].PostCategoryId);
                if (dataListChildCate.Count != 0)
                {
                    var dataByChilCate = await ListCategoryPaging(dataListChildCate[0].Id, 1, 10, 99999);
                    if (dataByChilCate.Count != 0)
                    {
                        for (int i = 0; i < dataByChilCate.Count; i++)
                        {
                            if (data.Count <= 6)
                            {
                                if (dataByChilCate[i].Id != postId)
                                {
                                    data.Add(dataByChilCate[i]);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            //trường hợp dành cho các bài về đồ thị mà publish = 0
            //viết thêm hàm để load các bài tương tự mà không cần publish != 0
            if (data.Count < 6)
            {
                //get list post same category
                var dataPostChart = await Detail(postId);
                //int soBaiConThieu = 6 - data.Count;
                var dataByCateChart = await ListCategoryPagingChart(dataPostChart[0].PostCategoryId, 1, 10, 99999);
                for (int i = 0; i < dataByCateChart.Count; i++)
                {
                    if (data.Count <= 6)
                    {
                        if (dataByCateChart[i].Id != postId)
                        {
                            data.Add(dataByCateChart[i]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return data;
        }

        public async Task<List<PostViewModel>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pl in db.PostLayout
                    where (
                        p.Active == 1
                        && p.Id == id
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pl.Id == p.PostLayoutId
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostLayoutName = pl.Name,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                        OpenTime = p.OpenTime,
                        ClosedTime = p.ClosedTime,
                        FileUrl = p.FileUrl,
                        EventAddress = p.EventAddress,
                        
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<Post> Add(Post obj)
        {
            if (db != null)
            {
                await db.Post.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Post obj)
        {
            if (db != null)
            {
                //Update that object


                //int id = Convert.ToInt32(obj.Id);
                //Post updatingObj = db.Post.Where(a => a.Id == id).FirstOrDefault();

                //updatingObj.PostTypeId = obj.PostTypeId;
                //updatingObj.PostAccountId = obj.PostAccountId;
                //updatingObj.PostCategoryId = obj.PostCategoryId;
                //updatingObj.PostLayoutId = obj.PostLayoutId;
                //updatingObj.PostPublishStatusId = obj.PostPublishStatusId;
                //updatingObj.PostCommentStatusId = obj.PostCommentStatusId;
                //updatingObj.GuId = obj.GuId;
                //updatingObj.Photo = obj.Photo;
                //updatingObj.Video = obj.Video;
                //updatingObj.ViewCount = obj.ViewCount;
                //updatingObj.CommentCount = obj.CommentCount;
                //updatingObj.LikeCount = obj.LikeCount;
                //updatingObj.Active = obj.Active;
                //updatingObj.Url = obj.Url;
                //updatingObj.Url2 = obj.Url2;
                //updatingObj.Name = obj.Name;
                //updatingObj.Description = obj.Description;
                //updatingObj.Text = obj.Text;
                //updatingObj.Name2 = obj.Name2;
                //updatingObj.Description2 = obj.Description2;
                //updatingObj.Text2 = obj.Text2;
                //updatingObj.PublishedTime = obj.PublishedTime;
                //updatingObj.CreatedTime = obj.CreatedTime;

                db.Post.Attach(obj);
                db.Entry(obj).Property(x => x.PostTypeId).IsModified = true;
                db.Entry(obj).Property(x => x.PostAccountId).IsModified = true;
                db.Entry(obj).Property(x => x.PostCategoryId).IsModified = true;
                db.Entry(obj).Property(x => x.PostLayoutId).IsModified = true;
                db.Entry(obj).Property(x => x.PostPublishStatusId).IsModified = true;
                db.Entry(obj).Property(x => x.PostCommentStatusId).IsModified = true;
                db.Entry(obj).Property(x => x.GuId).IsModified = true;
                db.Entry(obj).Property(x => x.Photo).IsModified = true;
                db.Entry(obj).Property(x => x.Video).IsModified = true;
                db.Entry(obj).Property(x => x.ViewCount).IsModified = true;
                db.Entry(obj).Property(x => x.CommentCount).IsModified = true;
                db.Entry(obj).Property(x => x.LikeCount).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Url).IsModified = true;
                db.Entry(obj).Property(x => x.Url2).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Text).IsModified = true;
                db.Entry(obj).Property(x => x.Name2).IsModified = true;
                db.Entry(obj).Property(x => x.Description2).IsModified = true;
                db.Entry(obj).Property(x => x.Text2).IsModified = true;
                db.Entry(obj).Property(x => x.OpenTime).IsModified = true;
                db.Entry(obj).Property(x => x.ClosedTime).IsModified = true;
                db.Entry(obj).Property(x => x.EventAddress).IsModified = true;
                db.Entry(obj).Property(x => x.FileUrl).IsModified = true;
                //db.Entry(obj).Property(x => x.PublishedTime).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(Post obj)
        {
            if (db != null)
            {
                //Update that obj
                db.Post.Attach(obj);
                db.Entry(obj).Property(x => x.Active).IsModified = true;

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public async Task<int> DeletePermanently(int? objId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                var obj = await db.Post.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.Post.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<PostViewModel>> ListCategory(string categorySlug)
        {
            if (db != null)
            {
                return await(
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (pc.Slug == categorySlug || pc.Slug2 == categorySlug)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }
            return null;
        }

        public async Task<List<PostViewModel>> ListCategoryPaging(int categoryID, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (pc.Id == categoryID)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        //Hàm để load các bài ở mục YouMayAlsoLike khi bài đó là đồ thị mà các method khác không load được
        public async Task<List<PostViewModel>> ListCategoryPagingChart(int categoryID, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1
                        && (pc.Id == categoryID)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }


        //Load paing theo category chính trong bảng Post
        public async Task<List<PostViewModel>> ListCategoryPagingRecursiveInPost(int categoryID, int pageIndex, int pageSize, int currentIDBigest)
        {
            string allCategoryID = "";
            PostCategoryRepository pcr = new PostCategoryRepository(db);
            List<PostCategory> listAllCategory = await pcr.List();
            allCategoryID = NovaticUtil.getAllChildrenCategoryID(categoryID, listAllCategory);

            var allowedStatus = allCategoryID.Split(",");

            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (allowedStatus.Contains(pc.Id.ToString()))
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }



        //Load paging theo category trong bảng Meta
        public async Task<List<PostViewModel>> ListCategoryPagingRecursiveInPostMeta(int categoryID, int pageIndex, int pageSize, int currentIDBigest)
        {
            string allCategoryID = "";
            PostCategoryRepository pcr = new PostCategoryRepository(db);
            List<PostCategory> listAllCategory = await pcr.List();
            allCategoryID = NovaticUtil.getAllChildrenCategoryID(categoryID, listAllCategory);

            var allowedStatus = allCategoryID.Split(",");

            //Load paging postmeta theo category
            var DataPostMeta = await repositoryPostMeta.ListByCategoryID(categoryID, pageIndex, pageSize);
            
            List<int> listPostIDInPostMeta = new List<int>();
            // tạo một mảng chứa các postId của các bài viết nằm trong bảng PostMeta
            if (DataPostMeta.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < DataPostMeta.Count; i++)
                {
                    listPostIDInPostMeta.Add(DataPostMeta[i].PostId);
                }
            }
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        //lọc các bài có id nằm trong bảng PostMeta (như kiểu "where in" trong sql server)
                        && listPostIDInPostMeta.Contains(p.Id)
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        //Gộp dữ liệu có được từ hai hàm trên và lọc dữ liệu
        public async Task<List<PostViewModel>> ListCategoryPagingRecursive(int categoryID, int pageIndex, int pageSize, int currentIDBigest)
        {
            var listInPost = await ListCategoryPagingRecursiveInPost(categoryID, pageIndex, pageSize, currentIDBigest);
            var listInPostMeta = await ListCategoryPagingRecursiveInPostMeta(categoryID, pageIndex, pageSize, currentIDBigest);
            if (listInPost is null && listInPostMeta is null)
            {
                return null;
            }
            else if (listInPost is null)
            {
                return listInPostMeta;
            }
            else if (listInPostMeta is null)
            {
                return listInPost;
            }
            else
            {
                //Gộp dữ liệu 2 list vào thành list data
                // Lọc luôn những bài viết có id trùng nhau
                var data = listInPost;
                for (int i = 0; i < listInPostMeta.Count; i++)
                {
                    for (int j = 0; j < data.Count; j++)
                    {
                        if (listInPostMeta[i].Id == data[j].Id)
                        {
                            break;
                        }
                        else
                        {
                            data.Add(listInPostMeta[i]);
                            break;
                        }
                    }
                }
                //Sắp xếp các mảng theo thứ tự giảm dần của PostID
                PostViewModel obj = new PostViewModel();
                List<PostViewModel> result = new List<PostViewModel>();
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < data.Count; j++)
                    {
                        if (data[i].Id > data[j].Id)
                        {
                            obj = data[i];
                            data[i] = data[j];
                            data[j] = obj;
                        }
                    }
                }
                if (data.Count < pageSize)
                {
                    return data;
                }
                else
                {
                    for (int i = 0; i < pageSize; i++)
                    {
                        result.Add(data[i]);
                    }
                    return result;
                }
            }
        }


        //public async Task<List<PostViewModel>> ListCategoryPagingRecursive(int categoryID, int pageIndex, int pageSize, int currentIDBigest)
        //{
        //    string allCategoryID = "";
        //    PostCategoryRepository pcr = new PostCategoryRepository(db);
        //    List<PostCategory> listAllCategory = await pcr.List();
        //    allCategoryID = NovaticUtil.getAllChildrenCategoryID(categoryID, listAllCategory);

        //    var allowedStatus = allCategoryID.Split(",");

        //    int offSet = 0;
        //    offSet = (pageIndex - 1) * pageSize;
        //    if (db != null)
        //    {
        //        var data = await (
        //            from p in db.Post
        //            join a in db.Account on p.PostAccountId equals a.Id
        //            join pc in db.PostCategory on p.PostCategoryId equals pc.Id
        //            join pm in db.PostMeta on p.PostCategoryId.ToString() equals pm.Name
        //            where (
        //                p.Active == 1 && p.PostPublishStatusId != 0
        //                && (allowedStatus.Contains(pc.Id.ToString()))
        //                || (allowedStatus.Contains(pm.Name.ToString()))
        //                && p.Id < currentIDBigest
        //            )
        //            orderby p.Id descending
        //            select new PostViewModel
        //            {
        //                Id = p.Id,
        //                PostTypeId = p.PostTypeId,
        //                PostAccountId = p.PostAccountId,
        //                PostCategoryId = p.PostCategoryId,
        //                PostLayoutId = p.PostLayoutId,
        //                PostPublishStatusId = p.PostPublishStatusId,
        //                PostCommentStatusId = p.PostCommentStatusId,
        //                Active = p.Active,
        //                Url = NovaticUtil.ConvertToURL(p.Url),
        //                Url2 = NovaticUtil.ConvertToURL(p.Url2),
        //                GuId = p.GuId,
        //                Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
        //                Video = p.Video,
        //                ViewCount = p.ViewCount,
        //                CommentCount = p.CommentCount,
        //                LikeCount = p.LikeCount,
        //                Name = p.Name,
        //                Description = p.Description,
        //                //Text = p.Text,
        //                Name2 = p.Name2,
        //                Description2 = p.Description2,
        //                //Text2 = p.Text2,
        //                PublishedTime = p.PublishedTime,
        //                CreatedTime = p.CreatedTime,
        //                PostAccountName = a.Name,
        //                PostAccountInfo = a.Info,
        //                PostAccountPhoto = a.Photo,
        //                PostAccountURL = a.Username,
        //                PostCategoryName = pc.Name,
        //                PostCategoryName2 = pc.Name2,
        //                PostCategoryColor = pc.Color,
        //                PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
        //            }
        //        ).Skip(offSet).Take(pageSize).ToListAsync();
        //        return data;
        //    }
        //    return null;
        //}


        public async Task<List<PostViewModel>> ListCategoryPaging(string categorySlug, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (pc.Slug == categorySlug || pc.Slug2 == categorySlug)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        public async Task<List<PostViewModel>> ListTag(string tagSlug)
        {
            if (db != null)
            {
                return await(
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pt in db.PostTag
                    from t in db.Tag
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (t.Slug == tagSlug || t.Slug2 == tagSlug)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pt.PostId == p.Id
                        && pt.TagId == t.Id
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }
            return null;
        }

        public async Task<List<PostViewModel>> ListTagPaging(string tagSlug, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pt in db.PostTag
                    from t in db.Tag
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (t.Slug == tagSlug || t.Slug2 == tagSlug)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pt.PostId == p.Id
                        && pt.TagId == t.Id
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        public async Task<List<PostViewModel>> ListAuthorPaging(string authorUsername, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && a.Username == authorUsername
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }


        // list search chỉ lọc các bài tin tức
        public async Task<List<PostViewModel>> ListSearchPaging(string keyWord, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        &&(p.Name.Contains(keyWord) || p.Description.Contains(keyWord) || p.Name2.Contains(keyWord) || p.Description2.Contains(keyWord)|| p.Text.Contains(keyWord) || p.Text2.Contains(keyWord))

                        && (p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && p.PostCategoryId != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO && p.PostCategoryId != SystemConstant.POST_CATEGORY_THU_VIEN &&
                        p.PostCategoryId != SystemConstant.POST_CATEGORY_UU_DAI && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG && p.PostCategoryId != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY
                        && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && p.PostCategoryId != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM && p.PostCategoryId != SystemConstant.POST_CATEGORY_PHU_LUC_5
                        )
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && p.Id < currentIDBigest
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        public Task<List<PostViewModel>> ListLatest()
        {
            throw new NotImplementedException();
        }

        public Task<List<PostViewModel>> ListLatestPopular()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PostViewModel>> ListFavouritePost(int UserID, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data =  await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from fp in db.FavouritePost
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (fp.AccountId == UserID)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && fp.PostId == p.Id
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }
        public async Task<List<PostViewModel>> ListPostByTemplateID(int layoutID, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && pc.Id == p.PostCategoryId
                        && p.PostLayoutId == layoutID
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }
        public async Task<List<PostViewModel>> ListReadedPost(int UserID, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from rp in db.ReadedPost
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (rp.AccountId == UserID)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && rp.PostId == p.Id
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        public async Task<List<Post>> DetailPost(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Post
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .AsNoTracking().ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> ListTopicPaging(string topicSlug, int pageIndex, int pageSize, int currentIDBigest)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from a in db.Account
                    from pt in db.PostTopic
                    from t in db.Topic
                    from pc in db.PostCategory
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (t.Slug == topicSlug || t.Slug2 == topicSlug)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pt.PostId == p.Id
                        && pt.TopicId == t.Id
                        && p.Id < currentIDBigest
                        && pt.Active == 1
                    )
                    orderby p.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryColor = pc.Color,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }
        public async Task<List<PostViewModel>> ListTopic(string topicSlug)
        {
            if (db != null)
            {
                return await (
                    from p in db.Post
                    from a in db.Account
                    from pc in db.PostCategory
                    from pt in db.PostTopic
                    from t in db.Topic
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && (t.Slug == topicSlug || t.Slug2 == topicSlug)
                        && a.Id == p.PostAccountId
                        && pc.Id == p.PostCategoryId
                        && pt.PostId == p.Id
                        && pt.TopicId == t.Id
                    )
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = NovaticUtil.ConvertToURL(a.Name),
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).ToListAsync();
            }
            return null;
        }
        public async Task<List<PostViewModel>> ListFeaturedPost(int TypeID, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from fp in db.FeaturedPost
                    from pc in db.PostCategory
                    from a in db.Account
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && fp.Active == 1
                        && (fp.TypeID == TypeID)
                        && pc.Id == p.PostCategoryId
                        && fp.PostId == p.Id
                        && a.Id == p.PostAccountId
                    )
                    orderby fp.Id descending
                    select new PostViewModel
                    {
                        Id = p.Id,
                        PostTypeId = p.PostTypeId,
                        PostAccountId = p.PostAccountId,
                        PostCategoryId = p.PostCategoryId,
                        PostLayoutId = p.PostLayoutId,
                        PostPublishStatusId = p.PostPublishStatusId,
                        PostCommentStatusId = p.PostCommentStatusId,
                        Active = p.Active,
                        Url = NovaticUtil.ConvertToURL(p.Url),
                        Url2 = NovaticUtil.ConvertToURL(p.Url2),
                        GuId = p.GuId,
                        Photo = (p.Photo != null) ? p.Photo : NovaticUtil.GetPostDefaultThumbnailPicture(),
                        Video = p.Video,
                        ViewCount = p.ViewCount,
                        CommentCount = p.CommentCount,
                        LikeCount = p.LikeCount,
                        Name = p.Name,
                        Description = p.Description,
                        //Text = p.Text,
                        Name2 = p.Name2,
                        Description2 = p.Description2,
                        //Text2 = p.Text2,
                        PublishedTime = p.PublishedTime,
                        CreatedTime = p.CreatedTime,
                        PostAccountName = a.Name,
                        PostAccountInfo = a.Info,
                        PostAccountPhoto = a.Photo,
                        PostAccountURL = a.Username,
                        PostCategoryName = pc.Name,
                        PostCategoryName2 = pc.Name2,
                        PostCategoryURL = NovaticUtil.ConvertToURL(pc.Name),
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
                return data;
            }
            return null;
        }

        public int CountPost()
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result = (
                    from row in db.Post
                    where row.Active == 1
                    select row
                ).Count();
            }

            return result;
        }

        public int CountPostUnsetCategory()
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result = (
                    from row in db.Post
                    where row.Active == 1 && (row.PostCategoryId == 10045 || row.PostCategoryId == 10057 || row.PostCategoryId == 10058 || row.PostCategoryId == 10067 || row.PostCategoryId == 10066 || row.PostCategoryId == 10059 || row.PostCategoryId == 10021 || row.PostCategoryId == 10009 || row.PostCategoryId == 10006 || row.PostCategoryId == 10004 || row.PostCategoryId == 10003 || row.PostCategoryId == 10001)
                    select row
                ).Count();
            }

            return result;
        }

        public int CountPost(int PostCategoryID)
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result = (
                    from row in db.Post
                    where (row.Active == 1 && row.PostCategoryId == PostCategoryID)
                    select row
                ).Count();
            }

            return result;
        }

        public async Task<List<Post>> CheckExistInChartCategory(string postName, int postCategoryID)
        {
            if (db != null)
            {
                return await (
                    from row in db.Post
                    where (row.Active == 1 && row.Name == postName && row.PostCategoryId == postCategoryID)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
    
        public async Task<List<Post>> ListPostTopic(string optionConditional)
        {
            if (db != null)
            {
                var data = await (
                    from p in db.Post
                    from pt in db.PostTag
                    from t in db.Tag
                    where (
                        p.Active == 1 && p.PostPublishStatusId != 0
                        && pt.PostId == p.Id
                        && pt.TagId == t.Id
                        && (t.Slug.Contains(optionConditional) || t.Slug2.Contains(optionConditional) || p.Url.Contains(optionConditional) || p.Url2.Contains(optionConditional))
                    )
                    orderby p.Id descending
                    select p
                ).ToListAsync();
                return data.GroupBy(p => p.Id).Select(row => row.First()).ToList();
            }
            return null;
        }

        public int? IncreaseLike(Post post)
        {
            int? like = post.LikeCount;
            return like;
        }

        public async Task<List<Post>> ListLearnedLesson()
        {
            return await (db.Post.Where(x => x.PostCategoryId == 10305 && x.Active == 1).ToListAsync());
        }

        public async Task<List<Post>> ListLegalrecords()
        {
            return await(db.Post.Where(x => x.PostCategoryId == 10308 && x.Active == 1).ToListAsync());
        }

        public async Task<List<Post>> ListOperationalandfinancialrecords()
        {
            return await(db.Post.Where(x => x.PostCategoryId == 10309 && x.Active == 1).ToListAsync());
        }

        public async Task<List<Post>> ListIncentivesformsandpurposesforcapitalfinancing()
        {
            return await(db.Post.Where(x => x.PostCategoryId == 10310 && x.Active == 1).ToListAsync());
        }

        public async Task<List<PostViewModel>> GetSimilarPost(int id)
        {
            List<PostViewModel> GetSimilarPost = new List<PostViewModel>();
            var dataPost = await Detail(id);
            var dataByCate = await ListCategoryPaging(dataPost[0].PostCategoryId, 1, 10, 99999);
            for (int i =0; i< dataByCate.Count; i++)
            {
                if(dataByCate[i].Id != id)
                {
                    GetSimilarPost.Add(dataByCate[i]);
                }
            }
            return GetSimilarPost;
        }
    }
}

