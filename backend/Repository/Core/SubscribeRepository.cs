
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class SubscribeRepository : ISubscribeRepository
    {
        NovaticDBContext db;
        public SubscribeRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Subscribe>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.Subscribe
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<Subscribe>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.Subscribe
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<Subscribe>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.Subscribe
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<Subscribe>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Subscribe
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<Subscribe> Add(Subscribe obj)
        {
            if (db != null)
            {
                await db.Subscribe.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Subscribe obj)
        {
            if (db != null)
            {
                //Update that object
                db.Subscribe.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(Subscribe obj)
        {
            if (db != null)
            {
                //Update that obj
                db.Subscribe.Attach(obj);
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
                var obj = await db.Subscribe.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.Subscribe.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Subscribe>> DetailByEmail(string email)
        {
            if (db != null)
            {
                return await (
                    from row in db.Subscribe
                    where (row.Active == 1 && row.Name == email)
                    select row)
                .ToListAsync();
            }

            return null;
        }
    }
}

