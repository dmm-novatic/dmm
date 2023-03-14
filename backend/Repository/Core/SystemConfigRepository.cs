
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class SystemConfigRepository : ISystemConfigRepository
    {
        NovaticDBContext db;
        public SystemConfigRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<SystemConfig>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
        public async Task<List<SystemConfig>> ListSlide()
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1 && (row.Code.Contains("SLIDE_") || row.Code.Contains("FINANCIAL_")))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
        public async Task<List<SystemConfig>> List9Category()
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1
                    && (row.Code.Contains("HOMEPAGE_CATEGORY_"))
                    )
                    //orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<SystemConfig>> ListLogo()
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1
                    && (row.Code.Contains("LOGO_"))
                    )
                    //orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<SystemConfig>> ListSocial()
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1
                    && (row.Code.Contains("LINK_"))
                    )
                    //orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }



        public async Task<List<SystemConfig>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<SystemConfig>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<SystemConfig>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public async Task<List<SystemConfig>> DetailByCode(string Code)
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1 && row.Code == Code)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<SystemConfig> Add(SystemConfig obj)
        {
            if (db != null)
            {
                await db.SystemConfig.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(SystemConfig obj)
        {
            if (db != null)
            {
                //Update that object
                db.SystemConfig.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Code).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(SystemConfig obj)
        {
            if (db != null)
            {
                //Update that obj
                db.SystemConfig.Attach(obj);
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
                var obj = await db.SystemConfig.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.SystemConfig.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
        public async Task<List<SystemConfig>> ListLogoAndBackgroundImage()
        {
            if (db != null)
            {
                return await (
                    from row in db.SystemConfig
                    where (row.Active == 1
                    && (row.Code.Contains("IMAGE_") || row.Code.Contains("BACKGROUND_"))
                    )
                    //orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<SystemConfig>> ListSotay()
        {
            if (db != null)
            {
                return await(
                    from row in db.SystemConfig
                    where (row.Active == 1 && row.Code == "SO_TAY_TRUC_TUYEN")
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }
    }
}

