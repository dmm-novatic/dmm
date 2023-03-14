
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface ISurveySectionRepository
    {
        Task<List<SurveySection>> List();

        Task<List<SurveySection>> Search(string keyword);

        Task<List<SurveySection>> ListPaging(int pageIndex, int pageSize);

        Task<List<SurveySection>> Detail(int? postId);

        Task<SurveySection> Add(SurveySection SurveySection);

        Task Update(SurveySection SurveySection);

        Task Delete(SurveySection SurveySection);

        Task<int> DeletePermanently(int? SurveySectionId);

        int CountSurveySection();
        Task<List<SurveySection>> ListBySurveyId(int surveyId);

        Task<List<SurveySection>> DetailByQuestion(int id);

    }
}
