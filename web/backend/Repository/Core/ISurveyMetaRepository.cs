  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ISurveyMetaRepository
        {
            Task<List<SurveyMeta>> List();

            Task<List<SurveyMeta>> Search(string keyword);

            Task<List<SurveyMeta>> ListPaging(int pageIndex, int pageSize);

            Task<List<SurveyMeta>> Detail(int? postId);

            Task<SurveyMeta> Add(SurveyMeta SurveyMeta);

            Task Update(SurveyMeta SurveyMeta);

            Task Delete(SurveyMeta SurveyMeta);

            Task<int> DeletePermanently(int? SurveyMetaId);

            int CountSurveyMeta();
        }
    }
    