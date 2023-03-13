  
    using Novatic.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class AccountMetaRepository : IAccountMetaRepository
        {
            NovaticDBContext db;
            public AccountMetaRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<AccountMeta>> List()
            {
                if (db != null)
                {
                    return await (
                        from row in db.AccountMeta
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<AccountMeta>> Search(string keyword)
            {
                if (db != null)
                {
                    return await (
                        from row in db.AccountMeta
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<AccountMeta>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    return await (
                        from row in db.AccountMeta
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();
                }

                return null;
            }


            public async Task<List<AccountMeta>> Detail(int? id)
            {
                if (db != null)
                {
                    return await (
                        from row in db.AccountMeta
                        where (row.Active == 1 && row.Id == id)
                        select row)
                    .ToListAsync();
                }

                return null;
            }


            public async Task<AccountMeta> Add(AccountMeta obj)
            {
                if (db != null)
                {
                    await db.AccountMeta.AddAsync(obj);
                    await db.SaveChangesAsync();

                    return obj;
                }

                return null;
            }


            public async Task Update(AccountMeta obj)
            {
                if (db != null)
                {
                    //Update that object
                    db.AccountMeta.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Id).IsModified = true;
	                db.Entry(obj).Property(x => x.AccountId).IsModified = true;
	                db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.Name).IsModified = true;
	                db.Entry(obj).Property(x => x.Description).IsModified = true;
	                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }


            public async Task Delete(AccountMeta obj)
            {
                if (db != null)
                {
                    //Update that obj
                    db.AccountMeta.Attach(obj);
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
                    var obj = await db.AccountMeta.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.AccountMeta.Remove(obj);

                        //Commit the transaction
                        result = await db.SaveChangesAsync();
                    }
                    return result;
                }

                return result;
            }
        }
    }

    