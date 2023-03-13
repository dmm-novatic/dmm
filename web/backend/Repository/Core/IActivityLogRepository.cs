  
    using Novatic.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public interface IActivityLogRepository
        {
            Task<List<ActivityLog>> List();

            Task<List<ActivityLog>> Search(string keyword);

            Task<List<ActivityLog>> ListPaging(int pageIndex, int pageSize);

            Task<List<ActivityLog>> Detail(int? postId);

            Task<ActivityLog> Add(ActivityLog ActivityLog);

            Task Update(ActivityLog ActivityLog);

            Task Delete(ActivityLog ActivityLog);

            Task<int> DeletePermanently(int? ActivityLogId);
        }
    }
    