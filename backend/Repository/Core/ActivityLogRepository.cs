  
    using Novatic.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class ActivityLogRepository : IActivityLogRepository
        {
            NovaticDBContext db;
            public ActivityLogRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<ActivityLog>> List()
            {
                if (db != null)
                {
                    return await (
                        from row in db.ActivityLog
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<ActivityLog>> Search(string keyword)
            {
                if (db != null)
                {
                    return await (
                        from row in db.ActivityLog
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<ActivityLog>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    return await (
                        from row in db.ActivityLog
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();
                }

                return null;
            }


            public async Task<List<ActivityLog>> Detail(int? id)
            {
                if (db != null)
                {
                    return await (
                        from row in db.ActivityLog
                        where (row.Active == 1 && row.Id == id)
                        select row)
                    .ToListAsync();
                }

                return null;
            }


            public async Task<ActivityLog> Add(ActivityLog obj)
            {
                if (db != null)
                {
                    await db.ActivityLog.AddAsync(obj);
                    await db.SaveChangesAsync();

                    return obj;
                }

                return null;
            }


            public async Task Update(ActivityLog obj)
            {
                if (db != null)
                {
                    //Update that object
                    db.ActivityLog.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.AccountId).IsModified = true;
	                db.Entry(obj).Property(x => x.Name).IsModified = true;
	                db.Entry(obj).Property(x => x.Url).IsModified = true;
	                db.Entry(obj).Property(x => x.UrlSource).IsModified = true;
	                db.Entry(obj).Property(x => x.IpAddress).IsModified = true;
	                db.Entry(obj).Property(x => x.Device).IsModified = true;
	                db.Entry(obj).Property(x => x.Browser).IsModified = true;
	                db.Entry(obj).Property(x => x.Os).IsModified = true;
	                db.Entry(obj).Property(x => x.UserAgent).IsModified = true;
	                db.Entry(obj).Property(x => x.Description).IsModified = true;
	                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }


            public async Task Delete(ActivityLog obj)
            {
                if (db != null)
                {
                    //Update that obj
                    db.ActivityLog.Attach(obj);
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
                    var obj = await db.ActivityLog.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.ActivityLog.Remove(obj);

                        //Commit the transaction
                        result = await db.SaveChangesAsync();
                    }
                    return result;
                }

                return result;
            }
        }
    }

    