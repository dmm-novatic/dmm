
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface ISurveyAccountRepository
    {
        Task<List<SurveyAccount>> List();

        Task<List<SurveyAccount>> Search(string keyword);

        Task<List<SurveyAccount>> ListPaging(int pageIndex, int pageSize);

        Task<List<SurveyAccount>> Detail(int? postId);

        Task<SurveyAccount> Add(SurveyAccount SurveyAccount);

        Task Update(SurveyAccount SurveyAccount);

        Task Delete(SurveyAccount SurveyAccount);

        Task<int> DeletePermanently(int? SurveyAccountId);

        int CountSurveyAccount();
        Task<List<SurveyAccount>> DetailByUserID(int userid);

        Task<List<SurveyAccount>> DetailByAccountId(int? id);

        Task<List<SurveyAccount>> DetailByAccountId(int? id, int surveyTypeId);

        Task<List<SurveyAccount>> ListSurveyAccountBySurveyId(int SurveyId);

        Task<List<SurveyAccount>> ListBySurveyId(int SurveyId);
    }
}
