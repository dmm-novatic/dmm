
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class RecommentRepository : IRecommentRepository
    {
        NovaticDBContext db;
        public RecommentRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Recomment>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Recomment
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }
        public async Task<List<Recomment>> ListBySurveySectionId(int surveySectionId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Recomment
                        where (row.Active == 1 && row.SurveySectionId == surveySectionId)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<Recomment>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Recomment
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                    ).ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<List<Recomment>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Recomment
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<List<Recomment>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Recomment
                        where (row.Active == 1 && row.Id == id)
                        select row)
                    .ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<Recomment> Add(Recomment obj)
        {
            if (db != null)
            {
                try
                {
                    await db.Recomment.AddAsync(obj);
                    await db.SaveChangesAsync();

                    return obj;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task Update(Recomment obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.Recomment.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.SurveySectionId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Name2).IsModified = true;
                    db.Entry(obj).Property(x => x.Description2).IsModified = true;
                    db.Entry(obj).Property(x => x.MinScore).IsModified = true;
                    db.Entry(obj).Property(x => x.MaxScore).IsModified = true;
                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(Recomment obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.Recomment.Attach(obj);
                    db.Entry(obj).Property(x => x.Active).IsModified = true;

                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }

        public async Task<int> DeletePermanently(int? objId)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    var obj = await db.Recomment.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Recomment.Remove(obj);

                        //Commit the transaction
                        result = await db.SaveChangesAsync();
                    }
                    return result;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return result;
        }


        public int CountRecomment()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Recomment
                        where row.Active == 1
                        select row
                    ).Count();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return result;
        }
    }
}

