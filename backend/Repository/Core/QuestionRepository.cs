
using A2F.ViewModel;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        NovaticDBContext db;
        public QuestionRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Question>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Question
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

        public async Task<List<SurveySectionViewModel>> ListQuestionViewModelBySurveySectionId(int surveySectionId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from q in db.Question
                        from ssq in db.SurveySectionQuestion
                        from ss in db.SurveySection
                        where (q.Active == 1 && ssq.Active == 1 && ss.Active == 1 
                        && q.Id == ssq.QuestionId
                        && ss.Id == ssq.SurveySectionId
                        && ss.Id == surveySectionId
                        )
                        orderby q.Id ascending
                        select new SurveySectionViewModel
                        {
                            Id = ss.Id,
                            SurveyId = ss.SurveyId,
                            SurveySectionId = ss.SurveySectionId,
                            ProportionScore = ss.ProportionScore,
                            Name = ss.Name,
                            Description = ss.Description,
                            Text = ss.Text,
                            Name2 = ss.Name2,
                            Description2 = ss.Description2,
                            Text2 =ss.Text2,
                            CreatedTime = ss.CreatedTime,
                            IdQuestion = q.Id,
                            QuestionTypeId = q.QuestionTypeId,
                            PhotoQuestion = q.Photo,
                            ScoreQuestion = q.Score,
                            NameQuestion = q.Name,
                            DescriptionQuestion = q.Description,
                            TextQuestion = q.Text,
                            Name2Question =q.Name2,
                            Description2Question = q.Description2,
                            Text2Question = q.Text2,
                            CreatedTimeQuestion = q.CreatedTime,
                        }
                    ).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<List<Question>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Question
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


        public async Task<List<Question>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Question
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


        public async Task<List<Question>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Question
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


        public async Task<Question> Add(Question obj)
        {
            if (db != null)
            {
                try
                {
                    await db.Question.AddAsync(obj);
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


        public async Task Update(Question obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.Question.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.QuestionTypeId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Photo).IsModified = true;
                    db.Entry(obj).Property(x => x.Score).IsModified = true;
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


        public async Task Delete(Question obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.Question.Attach(obj);
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
                    var obj = await db.Question.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Question.Remove(obj);

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


        public int CountQuestion()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Question
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

