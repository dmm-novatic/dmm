
using A2F.ViewModel;
using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface ISurveySectionAccountRepository
    {
        Task<List<SurveySectionAccount>> List();

        Task<List<SurveySectionAccount>> Search(string keyword);

        Task<List<SurveySectionAccount>> ListPaging(int pageIndex, int pageSize);

        Task<List<SurveySectionAccount>> Detail(int? postId);

        Task<SurveySectionAccount> Add(SurveySectionAccount SurveySectionAccount);

        Task Update(SurveySectionAccount SurveySectionAccount);

        Task Delete(SurveySectionAccount SurveySectionAccount);

        Task<int> DeletePermanently(int? SurveySectionAccountId);

        int CountSurveySectionAccount();
        Task<List<SurveySectionAccount>> DetailAll(int? id);
        Task<List<SurveySectionAccount>> DetailBySurveyAccountIdAndSurveySection(int surveyAccountId, int surveySectionId);

        Task<List<SurveySectionAccount>> ListBySurveyAccountId(int surveyAccountId);
        Task<List<SurveySectionAccountViewModel>> ListViewModelBySurveyAccountId(int surveyAccountId);

        Task<List<SurveySectionAccountViewModel>> ListViewModel();

        Task<List<SurveySectionAccountViewModel>> ListViewModelBySurveyAccountId1(int SurveyAccountId);
    }
}
    