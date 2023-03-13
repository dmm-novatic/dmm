  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface ISurveySectionAccountDetailRepository
        {
            Task<List<SurveySectionAccountDetail>> List();

            Task<List<SurveySectionAccountDetail>> Search(string keyword);

            Task<List<SurveySectionAccountDetail>> ListPaging(int pageIndex, int pageSize);

            Task<List<SurveySectionAccountDetail>> Detail(int? postId);

            Task<SurveySectionAccountDetail> Add(SurveySectionAccountDetail SurveySectionAccountDetail);

            Task Update(SurveySectionAccountDetail SurveySectionAccountDetail);

            Task Delete(SurveySectionAccountDetail SurveySectionAccountDetail);

            Task<int> DeletePermanently(int? SurveySectionAccountDetailId);

            int CountSurveySectionAccountDetail();
        }
    }
    