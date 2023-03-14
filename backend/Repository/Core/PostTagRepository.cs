
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class PostTagRepository : IPostTagRepository
    {
        NovaticDBContext db;
        public PostTagRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<PostTag>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostTag>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostTag>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostTag>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<List<PostTag>> DetailPost(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1 && row.PostId == id )
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<PostTag> Add(PostTag obj)
        {
            if (db != null)
            {
                await db.PostTag.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(PostTag obj)
        {
            if (db != null)
            {
                //Update that object
                db.PostTag.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.PostId).IsModified = true;
                db.Entry(obj).Property(x => x.TagId).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(PostTag obj)
        {
            if (db != null)
            {
                //Update that obj
                db.PostTag.Attach(obj);
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
                var obj = await db.PostTag.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.PostTag.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<PostTag>>DetailByTagID(int TagID)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1 && row.TagId==TagID)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostTag>> DetailByPostIDAndTagID(int PostID, int TagID)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTag
                    where (row.Active == 1 && row.TagId == TagID && row.PostId== PostID)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public int CountPost(int? TagID)
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result =  (
                    from row in db.PostTag
                    where (row.Active == 1 && row.TagId == TagID)
                    select row
                ).Count();
            }

            return result;
        }
    }
}

