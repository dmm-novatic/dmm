  
    using Novatic.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class SurveyRepository : ISurveyRepository
        {
            NovaticDBContext db;
            public SurveyRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<Survey>> List()
            {
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.Survey
                            where (row.Active == 1 && row.Id != 1000003)
                            orderby row.Id descending
                            select row
                        ).ToListAsync();
                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<Survey>> Search(string keyword)
            {
                if (db != null)
                {
                    
                    try {
                            return await (
                                from row in db.Survey
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


            public async Task<List<Survey>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.Survey
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


            public async Task<List<Survey>> Detail(int? id)
            {
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.Survey
                            where (row.Active == 1 && row.Id == id)
                            select row)
                        .AsNoTracking().ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<Survey> Add(Survey obj)
            {
                if (db != null)
                {
                    try {
                        await db.Survey.AddAsync(obj);
                        await db.SaveChangesAsync();
    
                        return obj;

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task Update(Survey obj)
            {
                if (db != null)
                {
                    try {
                        //Update that object
                        db.Survey.Attach(obj);
                        // db.Entry(obj).Property(x => x.Name).IsModified = true;
                        // db.Entry(obj).Property(x => x.Description).IsModified = true;
                        // db.Entry(obj).Property(x => x.Active).IsModified = true;
                        	db.Entry(obj).Property(x => x.SurveyTypeId).IsModified = true;
	db.Entry(obj).Property(x => x.GuId).IsModified = true;
	db.Entry(obj).Property(x => x.Photo).IsModified = true;
	db.Entry(obj).Property(x => x.Video).IsModified = true;
	db.Entry(obj).Property(x => x.ViewCount).IsModified = true;
	db.Entry(obj).Property(x => x.CommentCount).IsModified = true;
	db.Entry(obj).Property(x => x.LikeCount).IsModified = true;
	db.Entry(obj).Property(x => x.Active).IsModified = true;
	db.Entry(obj).Property(x => x.Url).IsModified = true;
	db.Entry(obj).Property(x => x.Url2).IsModified = true;
	db.Entry(obj).Property(x => x.Score).IsModified = true;
	db.Entry(obj).Property(x => x.Name).IsModified = true;
	db.Entry(obj).Property(x => x.Description).IsModified = true;
	db.Entry(obj).Property(x => x.Text).IsModified = true;
	db.Entry(obj).Property(x => x.Name2).IsModified = true;
	db.Entry(obj).Property(x => x.Description2).IsModified = true;
	db.Entry(obj).Property(x => x.Text2).IsModified = true;
	db.Entry(obj).Property(x => x.PublishedTime).IsModified = true;

    
                        //Commit the transaction
                        await db.SaveChangesAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }
            }


            public async Task Delete(Survey obj)
            {
                if (db != null)
                {
                    try {
                        //Update that obj
                        db.Survey.Attach(obj);
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
                        var obj = await db.Survey.FirstOrDefaultAsync(x => x.Id == objId);
    
                        if (obj != null)
                        {
                            //Delete that obj
                            db.Survey.Remove(obj);
    
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


            public int CountSurvey()
            {
                int result = 0;

                if (db != null)
                {
                    try {
                        //Find the obj for specific obj id
                        result = (
                            from row in db.Survey
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

    