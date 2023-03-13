
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface INotificationStatusRepository
    {
        Task<List<NotificationStatus>> List();

        Task<List<NotificationStatus>> Search(string keyword);

        Task<List<NotificationStatus>> ListPaging(int pageIndex, int pageSize);

        Task<List<NotificationStatus>> Detail(int? postId);

        Task<NotificationStatus> Add(NotificationStatus NotificationStatus);

        Task Update(NotificationStatus NotificationStatus);

        Task Delete(NotificationStatus NotificationStatus);

        Task<int> DeletePermanently(int? NotificationStatusId);

        int CountNotificationStatus();
    }
}
