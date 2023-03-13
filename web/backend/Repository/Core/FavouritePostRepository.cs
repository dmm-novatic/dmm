
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class FavouritePostRepository : IFavouritePostRepository
    {
        NovaticDBContext db;
        public FavouritePostRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<FavouritePost>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.FavouritePost
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<FavouritePost>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.FavouritePost
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<FavouritePost>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.FavouritePost
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<FavouritePost>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.FavouritePost
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public async Task<List<FavouritePost>> DetailFromUserIDAndPostID(int? userID, int? postID)
        {
            if (db != null)
            {
                return await (
                    from row in db.FavouritePost
                    where (row.PostId == postID && row.AccountId == userID)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<FavouritePost> Add(FavouritePost obj)
        {
            if (db != null)
            {
                await db.FavouritePost.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(FavouritePost obj)
        {
            if (db != null)
            {
                //Update that object
                db.FavouritePost.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.PostId).IsModified = true;
                db.Entry(obj).Property(x => x.AccountId).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(FavouritePost obj)
        {
            if (db != null)
            {
                //Update that obj
                db.FavouritePost.Attach(obj);
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
                var obj = await db.FavouritePost.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.FavouritePost.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}

