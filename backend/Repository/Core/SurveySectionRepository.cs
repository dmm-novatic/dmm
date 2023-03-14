
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class SurveySectionRepository : ISurveySectionRepository
    {
        NovaticDBContext db;
        public SurveySectionRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<SurveySection>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySection
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
        public async Task<List<SurveySection>> ListBySurveyId(int surveyId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySection
                        where (row.Active == 1 && row.SurveyId == surveyId)
                        orderby row.Id ascending
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

        public async Task<List<SurveySection>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.SurveySection
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


        public async Task<List<SurveySection>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySection
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


        public async Task<List<SurveySection>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySection
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


        public async Task<SurveySection> Add(SurveySection obj)
        {
            if (db != null)
            {
                try
                {
                    await db.SurveySection.AddAsync(obj);
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


        public async Task Update(SurveySection obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.SurveySection.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.SurveyId).IsModified = true;
                    db.Entry(obj).Property(x => x.SurveySectionId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.ProportionScore).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Text).IsModified = true;
                    db.Entry(obj).Property(x => x.Name2).IsModified = true;
                    db.Entry(obj).Property(x => x.Description2).IsModified = true;
                    db.Entry(obj).Property(x => x.Text2).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(SurveySection obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.SurveySection.Attach(obj);
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
                    var obj = await db.SurveySection.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.SurveySection.Remove(obj);

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


        public int CountSurveySection()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.SurveySection
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

        public async Task<List<SurveySection>> DetailByQuestion(int id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySection
                        from svsq in db.SurveySectionQuestion
                        from q in db.Question
                        where (row.Active == 1 && svsq.Active == 1 && q.Active == 1
                        && row.Id == svsq.SurveySectionId
                        && q.Id == svsq.QuestionId
                        && q.Id == id)
                        select row)
                    .AsNoTracking().ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }
    }
}

