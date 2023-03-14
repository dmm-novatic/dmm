
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public interface INotificationRepository
    {
        Task<List<Notification>> List();

        Task<List<Notification>> Search(string keyword);

        Task<List<Notification>> ListPaging(int pageIndex, int pageSize);

        Task<List<Notification>> Detail(int? postId);

        Task<Notification> Add(Notification Notification);

        Task Update(Notification Notification);

        Task UpdateStatus(Notification Notification);

        Task Delete(Notification Notification);

        Task<int> DeletePermanently(int? NotificationId);

        int CountNotification();
        int CountNotificationByAcountID(int accountID);
        Task<List<Notification>> GetNotificationsByAcountID(int accountID, int pageIndex, int pageSize);
        Task<List<Notification>> GetNotificationByAccountId(int accountId);

        Task<List<Notification>> ListNotification(int accountID);

        int CountNotificationByNonReaded(int accountID);
    }
}
