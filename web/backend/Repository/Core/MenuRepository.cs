
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class MenuRepository : IMenuRepository
    {
        NovaticDBContext db;
        public MenuRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Menu>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.Menu
                    where (row.Active == 1)
                    orderby row.Priority ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<Menu>> ListMenuHeader()
        {
            if (db != null)
            {
                return await (
                    from row in db.Menu
                    where (row.Active == 1 && row.GroupID == 1)
                    orderby row.Priority ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<Menu>> ListMenuFooter()
        {
            if (db != null)
            {
                return await (
                    from row in db.Menu
                    where (row.Active == 1 && row.GroupID == 2)
                    orderby row.Priority ascending
                    select row
                ).ToListAsync();
            }

            return null;
        }



        public async Task<List<Menu>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.Menu
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<Menu>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.Menu
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<Menu>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Menu
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<Menu> Add(Menu obj)
        {
            if (db != null)
            {
                await db.Menu.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Menu obj)
        {
            if (db != null)
            {
                //Update that object
                db.Menu.Attach(obj);
                db.Entry(obj).Property(x => x.ParentId).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Priority).IsModified = true;
                db.Entry(obj).Property(x => x.GroupID).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Name2).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Url).IsModified = true;
                db.Entry(obj).Property(x => x.Url2).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(Menu obj)
        {
            if (db != null)
            {
                //Update that obj
                db.Menu.Attach(obj);
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
                var obj = await db.Menu.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.Menu.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}

