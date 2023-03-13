
using A2F.ViewModel;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class SurveySectionAccountRepository : ISurveySectionAccountRepository
    {
        NovaticDBContext db;
        public SurveySectionAccountRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<SurveySectionAccount>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
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

        public async Task<List<SurveySectionAccount>> ListBySurveyAccountId(int surveyAccountId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
                        where (row.Active == 1 && row.SurveyAccountId == surveyAccountId)
                        orderby row.Id descending
                        select row
                    ).AsNoTracking().ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }
        public async Task<List<SurveySectionAccountViewModel>> ListViewModelBySurveyAccountId(int surveyAccountId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
                        where (row.Active == 1 && row.SurveyAccountId == surveyAccountId)
                        orderby row.Id descending
                        select new SurveySectionAccountViewModel
                        {
                            Id = row.Id,
                            Active = row.Active,
                            SurveyAccountId = row.SurveyAccountId,
                            Score = row.Score,
                            Name = row.Name,
                            Description = row.Description,
                            CreatedTime = row.CreatedTime,
                            ListRecomment = null
                        }
                    ).AsNoTracking().ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<SurveySectionAccountViewModel>> ListViewModel()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
                        from sa in db.SurveyAccount
                        from ac in db.Account
                        where (row.Active == 1 && sa.Active == 1 && ac.Active == 1 && row.SurveyAccountId == sa.Id && sa.AccountId == ac.Id)
                        orderby sa.Id descending
                        select new SurveySectionAccountViewModel
                        {
                            SurveyAccountScore = sa.Score,
                            SurveyAccountName = sa.Name,
                            AccountId = sa.AccountId,
                            AccountUsername = ac.Username,
                            Id = row.Id,
                            Active = row.Active,
                            SurveyAccountId = row.SurveyAccountId,
                            Score = row.Score,
                            Name = row.Name,
                            Description = row.Description,
                            CreatedTime = row.CreatedTime,
                            ListRecomment = null
                        }
                    ).AsNoTracking().ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        // Nam Listviewmodel có thêm thông tin tài khoản
        public async Task<List<SurveySectionAccountViewModel>> ListViewModelBySurveyAccountId1(int SurveyAccountId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
                        from sa in db.SurveyAccount
                        from ac in db.Account
                        where (row.Active == 1 && sa.Active == 1 && ac.Active == 1 && row.SurveyAccountId == sa.Id && sa.AccountId == ac.Id && sa.Id == SurveyAccountId)
                        orderby sa.Id descending
                        select new SurveySectionAccountViewModel
                        {
                            SurveyAccountScore = sa.Score,
                            SurveyAccountName = sa.Name,
                            AccountId = sa.AccountId,
                            AccountUsername = ac.Username,
                            Id = row.Id,
                            Active = row.Active,
                            SurveyAccountId = row.SurveyAccountId,
                            Score = row.Score,
                            Name = row.Name,
                            Description = row.Description,
                            CreatedTime = row.CreatedTime,
                            ListRecomment = null
                        }
                    ).AsNoTracking().ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }
        public async Task<List<SurveySectionAccount>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.SurveySectionAccount
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


        public async Task<List<SurveySectionAccount>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
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


        public async Task<List<SurveySectionAccount>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.SurveySectionAccount
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


        public async Task<SurveySectionAccount> Add(SurveySectionAccount obj)
        {
            if (db != null)
            {
                try
                {
                    await db.SurveySectionAccount.AddAsync(obj);
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


        public async Task Update(SurveySectionAccount obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.SurveySectionAccount.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.SurveyAccountId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Score).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(SurveySectionAccount obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.SurveySectionAccount.Attach(obj);
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
                    var obj = await db.SurveySectionAccount.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.SurveySectionAccount.Remove(obj);

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


        public int CountSurveySectionAccount()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.SurveySectionAccount
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

        public async Task<List<SurveySectionAccount>> DetailAll(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (from ssa in db.SurveySectionAccount
                                  where ssa.SurveyAccountId == id && ssa.Active == 1
                                  select ssa
                                  ).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
            return null;
        }
        public async Task<List<SurveySectionAccount>> DetailBySurveyAccountIdAndSurveySection(int surveyAccountId, int surveySectionId)
        {
            if (db != null)
            {
                try
                {
                    return (
                        from row in db.SurveySectionAccount
                        where (row.Active == 1 && row.SurveyAccountId == surveyAccountId && Convert.ToInt32(row.Description) == surveySectionId)
                        select row)
                    .AsEnumerable().ToList();

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

