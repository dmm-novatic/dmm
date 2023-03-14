  
    using Novatic.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class LanguageConfigRepository : ILanguageConfigRepository
        {
            NovaticDBContext db;
            public LanguageConfigRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<LanguageConfig>> List()
            {
                if (db != null)
                {
                    return await (
                        from row in db.LanguageConfig
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).AsNoTracking().ToListAsync();
                }

                return null;
            }


            public async Task<List<LanguageConfig>> Search(string keyword)
            {
                if (db != null)
                {
                    return await (
                        from row in db.LanguageConfig
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<LanguageConfig>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    return await (
                        from row in db.LanguageConfig
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();
                }

                return null;
            }


            public async Task<List<LanguageConfig>> Detail(int? id)
            {
                if (db != null)
                {
                    return await (
                        from row in db.LanguageConfig
                        where (row.Active == 1 && row.Id == id)
                        select row)
                    .ToListAsync();
                }

                return null;
            }


            public async Task<LanguageConfig> Add(LanguageConfig obj)
            {
                if (db != null)
                {
                    await db.LanguageConfig.AddAsync(obj);
                    await db.SaveChangesAsync();

                    return obj;
                }

                return null;
            }


            public async Task Update(LanguageConfig obj)
            {
                if (db != null)
                {
                    //Update that object
                    db.LanguageConfig.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.Name).IsModified = true;
	                db.Entry(obj).Property(x => x.Name2).IsModified = true;
	                db.Entry(obj).Property(x => x.Code).IsModified = true;
	                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;
                //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }


            public async Task Delete(LanguageConfig obj)
            {
                if (db != null)
                {
                    //Update that obj
                    db.LanguageConfig.Attach(obj);
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
                    var obj = await db.LanguageConfig.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.LanguageConfig.Remove(obj);

                        //Commit the transaction
                        result = await db.SaveChangesAsync();
                    }
                    return result;
                }

                return result;
            }
        }
    }

    