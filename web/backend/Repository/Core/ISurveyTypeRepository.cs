  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ISurveyTypeRepository
        {
            Task<List<SurveyType>> List();

            Task<List<SurveyType>> Search(string keyword);

            Task<List<SurveyType>> ListPaging(int pageIndex, int pageSize);

            Task<List<SurveyType>> Detail(int? postId);

            Task<SurveyType> Add(SurveyType SurveyType);

            Task Update(SurveyType SurveyType);

            Task Delete(SurveyType SurveyType);

            Task<int> DeletePermanently(int? SurveyTypeId);

            int CountSurveyType();
        }
    }
    