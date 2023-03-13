  
    using Novatic.Models.CRM; using Novatic.Models; 
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class PromotionMetaRepository : IPromotionMetaRepository
        {
            NovaticDBContext db;
            public PromotionMetaRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<PromotionMeta>> List()
            {
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.PromotionMeta
                            where (row.Active == 1)
                            orderby row.Id descending
                            select row
                        ).ToListAsync();
                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<PromotionMeta>> Search(string keyword)
            {
                if (db != null)
                {
                    
                    try {
                            return await (
                                from row in db.PromotionMeta
                                where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                                orderby row.Id descending
                                select row
                            ).ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<PromotionMeta>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.PromotionMeta
                            where (row.Active == 1)
                            orderby row.Id descending
                            select row
                        ).Skip(offSet).Take(pageSize).ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<PromotionMeta>> Detail(int? id)
            {
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.PromotionMeta
                            where (row.Active == 1 && row.Id == id)
                            select row)
                        .ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<PromotionMeta> Add(PromotionMeta obj)
            {
                if (db != null)
                {
                    try {
                        await db.PromotionMeta.AddAsync(obj);
                        await db.SaveChangesAsync();
    
                        return obj;

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task Update(PromotionMeta obj)
            {
                if (db != null)
                {
                    try {
                        //Update that object
                        db.PromotionMeta.Attach(obj);
                        // db.Entry(obj).Property(x => x.Name).IsModified = true;
                        // db.Entry(obj).Property(x => x.Description).IsModified = true;
                        // db.Entry(obj).Property(x => x.Active).IsModified = true;
                        	db.Entry(obj).Property(x => x.PromotionId).IsModified = true;
	db.Entry(obj).Property(x => x.Active).IsModified = true;
	db.Entry(obj).Property(x => x.Name).IsModified = true;
	db.Entry(obj).Property(x => x.Key).IsModified = true;
	db.Entry(obj).Property(x => x.Value).IsModified = true;
	db.Entry(obj).Property(x => x.Description).IsModified = true;

    
                        //Commit the transaction
                        await db.SaveChangesAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }
            }


            public async Task Delete(PromotionMeta obj)
            {
                if (db != null)
                {
                    try {
                        //Update that obj
                        db.PromotionMeta.Attach(obj);
                        db.Entry(obj).Property(x => x.Active).IsModified = true;
    
                        //Commit the transaction
                        await db.SaveChangesAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }
            }

            public async Task<int> DeletePermanently(int? objId)
            {
                int result = 0;

                if (db != null)
                {
                    try {
                        //Find the obj for specific obj id
                        var obj = await db.PromotionMeta.FirstOrDefaultAsync(x => x.Id == objId);
    
                        if (obj != null)
                        {
                            //Delete that obj
                            db.PromotionMeta.Remove(obj);
    
                            //Commit the transaction
                            result = await db.SaveChangesAsync();
                        }
                        return result;

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return result;
            }


            public int CountPromotionMeta()
            {
                int result = 0;

                if (db != null)
                {
                    try {
                        //Find the obj for specific obj id
                        result = (
                            from row in db.PromotionMeta
                            where row.Active == 1
                            select row
                        ).Count();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return result;
            }
        }
    }

    