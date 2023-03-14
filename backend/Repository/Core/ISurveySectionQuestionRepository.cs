  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ISurveySectionQuestionRepository
        {
            Task<List<SurveySectionQuestion>> List();

            Task<List<SurveySectionQuestion>> Search(string keyword);

            Task<List<SurveySectionQuestion>> ListPaging(int pageIndex, int pageSize);

            Task<List<SurveySectionQuestion>> Detail(int? postId);

            Task<SurveySectionQuestion> Add(SurveySectionQuestion SurveySectionQuestion);

            Task Update(SurveySectionQuestion SurveySectionQuestion);

            Task Delete(SurveySectionQuestion SurveySectionQuestion);

            Task<int> DeletePermanently(int? SurveySectionQuestionId);

            int CountSurveySectionQuestion();
            Task<List<SurveySectionQuestion>> ListBySurveySectionId(int surveysectionid);
        }
    }
    