
using A2F.Util;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        NovaticDBContext db;
        public PostCategoryRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<PostCategory>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1)
                    orderby row.Id ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        // Theo danh mục tin tức
        public async Task<List<PostCategory>> ListByNews()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.Id != SystemConstant.POST_CATEGORY_PHU_LUC_5 && row.Id != SystemConstant.POST_CATEGORY_SU_KIEN && row.Id != SystemConstant.POST_CATEGORY_THU_VIEN
                        && row.Id != SystemConstant.POST_CATEGORY_DAO_TAO_CO_BAN && row.Id != SystemConstant.POST_CATEGORY_DAO_TAO_NANG_CAO && row.Id != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM
                        && row.Id != SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 && row.Id != SystemConstant.POST_CATEGORY_HO_SO_PHAP_LY && row.Id != SystemConstant.POST_CATEGORY_HO_SO_HOAT_DONG
                        && row.Id != SystemConstant.POST_CATEGORY_UU_DAI)                   
                    orderby row.Id ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        // Theo danh mục tin phụ lục 5
        public async Task<List<PostCategory>> ListByPhuluc5()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.Id == SystemConstant.POST_CATEGORY_PHU_LUC_5)
                    orderby row.Id ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        // theo danh muc bai hoc kinh nghiem
        public async Task<List<PostCategory>> ListByLessonLearned()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && (row.ParentID == SystemConstant.POST_CATEGORY_BAI_HOC_KINH_NGHIEM2 ))
                    orderby row.Id ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        // Theo danh mục sự kiện
        public async Task<List<PostCategory>> ListByEvents()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.Id == SystemConstant.POST_CATEGORY_SU_KIEN)
                    orderby row.Id ascending
                    select row
                ).ToListAsync();
            }
            return null;
        }

        // Theo danh mục thư viện
        public async Task<List<PostCategory>> ListByLibrary()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.ParentID == 10299)
                    orderby row.Id ascending
                    select row
                ).ToListAsync();
            }
            return null;
        }


        public async Task<List<PostCategory>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostCategory>> DetailBySlug(string slug)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.Slug == slug)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostCategory>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostCategory>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public async Task<List<PostCategory>> ListbyParentId(int? parentId)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && row.ParentID == parentId)
                    orderby row.Id descending
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<List<PostCategory>> Detail(string slug)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostCategory
                    where (row.Active == 1 && (row.Slug == slug || row.Slug2 == slug))
                    select row)
                .ToListAsync();
            }
            return null;
        }


        public async Task<PostCategory> Add(PostCategory obj)
        {
            if (db != null)
            {
                await db.PostCategory.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(PostCategory obj)
        {
            if (db != null)
            {
                //Update that object
                db.PostCategory.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Name2).IsModified = true;
                db.Entry(obj).Property(x => x.Slug).IsModified = true;
                db.Entry(obj).Property(x => x.Slug2).IsModified = true;
                db.Entry(obj).Property(x => x.Color).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Photo).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;
                db.Entry(obj).Property(x => x.ParentID).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(PostCategory obj)
        {
            if (db != null)
            {
                //Update that obj
                db.PostCategory.Attach(obj);
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
                var obj = await db.PostCategory.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.PostCategory.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}

