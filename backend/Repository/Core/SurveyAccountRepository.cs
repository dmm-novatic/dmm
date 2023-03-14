
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class SurveyAccountRepository : ISurveyAccountRepository
    {
        NovaticDBContext db;
        public SurveyAccountRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<SurveyAccount>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveyAccount
                        from ac in db.Account
                        where (row.Active == 1 && ac.Active == 1 && row.AccountId == ac.Id)
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

        public async Task<List<SurveyAccount>> ListBySurveyId(int SurveyId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveyAccount
                        from ac in db.Account
                        where (row.Active == 1 && ac.Active == 1 && row.AccountId == ac.Id && row.SurveyId == SurveyId)
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


        public async Task<List<SurveyAccount>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.SurveyAccount
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


        public async Task<List<SurveyAccount>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveyAccount
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


        public async Task<List<SurveyAccount>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveyAccount
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


        public async Task<SurveyAccount> Add(SurveyAccount obj)
        {
            if (db != null)
            {
                try
                {
                    await db.SurveyAccount.AddAsync(obj);
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


        public async Task Update(SurveyAccount obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.SurveyAccount.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.AccountId).IsModified = true;
                    db.Entry(obj).Property(x => x.SurveyId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Score).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Text).IsModified = true;
                    db.Entry(obj).Property(x => x.Name2).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(SurveyAccount obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.SurveyAccount.Attach(obj);
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
                    var obj = await db.SurveyAccount.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.SurveyAccount.Remove(obj);

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


        public int CountSurveyAccount()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.SurveyAccount
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

        public async Task<List<SurveyAccount>> DetailByUserID(int userid)
        {
            if (db != null)
            {
                try
                {
                    return await (from sa in db.SurveyAccount
                                  where sa.AccountId == userid && sa.Active == 1
                                  select sa).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
            return null;
        }

        public async Task<List<SurveyAccount>> DetailByAccountId(int? id, int surveyTypeId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveyAccount
                        from survey in db.Survey
                        where(row.SurveyId == survey.Id && row.Active ==1 && survey.SurveyTypeId == surveyTypeId && row.AccountId == id)
                        //where (row.Active == 1 && row.AccountId == id && survey.SurveyTypeId == surveyTypeId && row.SurveyId == row.Id)
                        orderby row.Id descending
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

        public async Task<List<SurveyAccount>> DetailByAccountId(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveyAccount
                        where (row.Active == 1 && row.AccountId == id)
                        orderby row.Id descending
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

        public async Task<List<SurveyAccount>> ListSurveyAccountBySurveyId(int SurveyId)
        {
            if (db != null)
            {
                try
                {
                    return await(
                        from row in db.SurveyAccount
                        where (row.Active == 1 && row.SurveyId == SurveyId)
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
    }
}

