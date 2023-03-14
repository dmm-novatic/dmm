using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.ViewModel;
using Novatic.Util;

namespace Novatic.Repository
{
    public class PostMetaRepository : IPostMetaRepository
    {
        NovaticDBContext db;
        IPostCategoryRepository repositoryPostCategory;
        public PostMetaRepository(NovaticDBContext _db, IPostCategoryRepository _repositoryPostCategory)
        {
            db = _db;
            repositoryPostCategory = _repositoryPostCategory;
        }


        public async Task<List<PostMetaViewModel>> List()
        {
            if (db != null)
            {
                return await (
                    from pm in db.PostMeta
                    from p in db.Post
                    from pc in db.PostCategory
                    where (
                        pm.Active == 1
                        && pm.PostId == p.Id
                        && Convert.ToInt32(pm.Name) == pc.Id
                    )
                    orderby pm.Id descending
                    select new PostMetaViewModel
                    {
                        Id = pm.Id,
                        PostId = pm.PostId,
                        PostName = p.Name,
                        Active = pm.Active,
                        Name = pm.Name,
                        NameOfPostCategory = pc.Name,
                        Description = pm.Description,
                        CreatedTime = pm.CreatedTime
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostMetaViewModel>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from pm in db.PostMeta
                    from p in db.Post
                    from pc in db.PostCategory
                    where (
                        pm.Active == 1
                        && pm.PostId == p.Id
                        && Convert.ToInt32(pm.Name) == pc.Id
                        && (pm.Active == 1 && (pm.Name.Contains(keyword) || pm.Description.Contains(keyword)))
                    )
                    orderby pm.Id descending
                    select new PostMetaViewModel
                    {
                        Id = pm.Id,
                        PostId = pm.PostId,
                        PostName = p.Name,
                        Active = pm.Active,
                        Name = pm.Name,
                        NameOfPostCategory = pc.Name,
                        Description = pm.Description,
                        CreatedTime = pm.CreatedTime
                    }
                ).ToListAsync();
            }

            return null;
        }

        //public async Task<List<PostMetaViewModel>> ListByCategoryID(int postCategoryID)
        //{
        //    if (db != null)
        //    {
        //        return await (
        //            from pm in db.PostMeta
        //            from p in db.Post
        //            from pc in db.PostCategory
        //            where (
        //                pm.Active == 1
        //                && pm.PostId == p.Id
        //                && Convert.ToInt32(pm.Name) == pc.Id
        //                && Convert.ToInt32(pm.Name) == postCategoryID
        //            )
        //            orderby pm.Id descending
        //            select new PostMetaViewModel
        //            {
        //                Id = pm.Id,
        //                PostId = pm.PostId,
        //                PostName = p.Name,
        //                Active = pm.Active,
        //                Name = pm.Name,
        //                NameOfPostCategory = pc.Name,
        //                Description = pm.Description,
        //                CreatedTime = pm.CreatedTime
        //            }
        //        ).ToListAsync();
        //    }

        //    return null;
        //}

        public async Task<List<PostMeta>> ListByCategoryID(int postCategoryID, int pageIndex, int pageSize)
        {
            string allCategoryID = "";
            PostCategoryRepository pcr = new PostCategoryRepository(db);
            List<PostCategory> listAllCategory = await pcr.List();
            allCategoryID = NovaticUtil.getAllChildrenCategoryID(postCategoryID, listAllCategory);

            var allowedStatus = allCategoryID.Split(",");

            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.PostMeta
                    where (allowedStatus.Contains(row.Name) && row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }



        public async Task<List<PostMetaViewModel>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from pm in db.PostMeta
                    from p in db.Post
                    from pc in db.PostCategory
                    where (
                        pm.Active == 1
                        && pm.PostId == p.Id
                        && Convert.ToInt32(pm.Name) == pc.Id
                    )
                    orderby pm.Id descending
                    select new PostMetaViewModel
                    {
                        Id = pm.Id,
                        PostId = pm.PostId,
                        PostName = p.Name,
                        Active = pm.Active,
                        Name = pm.Name,
                        NameOfPostCategory = pc.Name,
                        Description = pm.Description,
                        CreatedTime = pm.CreatedTime
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostMetaViewModel>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from pm in db.PostMeta
                    from p in db.Post
                    from pc in db.PostCategory
                    where (
                        pm.Active == 1
                        && pm.Id == id
                        && pm.PostId == p.Id
                        && Convert.ToInt32(pm.Name) == pc.Id
                    )
                    orderby pm.Id descending
                    select new PostMetaViewModel
                    {
                        Id = pm.Id,
                        PostId = pm.PostId,
                        PostName = p.Name,
                        Active = pm.Active,
                        Name = pm.Name,
                        NameOfPostCategory = pc.Name,
                        Description = pm.Description,
                        CreatedTime = pm.CreatedTime
                    })
                .ToListAsync();
            }

            return null;
        }


        public async Task<PostMeta> Add(PostMeta obj)
        {
            if (db != null)
            {
                await db.PostMeta.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(PostMeta obj)
        {
            if (db != null)
            {
                //Update that object
                db.PostMeta.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.PostId).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(PostMeta obj)
        {
            if (db != null)
            {
                //Update that obj
                db.PostMeta.Attach(obj);
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
                var obj = await db.PostMeta.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.PostMeta.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}

