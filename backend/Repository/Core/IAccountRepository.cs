
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.ViewModel;

namespace Novatic.Repository
{
    public interface IAccountRepository
    {
        Task<List<AccountViewModel>> List();
        Task<List<AccountViewModel>> ListByShopId();

        Task<List<Account>> ListAccount();

        Task<List<AccountViewModel>> Search(string keyword);

        Task<List<AccountViewModel>> ListPaging(int pageIndex, int pageSize);

        Task<List<AccountViewModel>> Detail(int? postId);

        Task<List<AccountViewModel>> Detail(string username);

        Task<List<AccountViewModel>> Login(Account Account);

        Task<List<AccountViewModel>> CheckEmailExist(Account Account);
        Task<List<AccountViewModel>> CheckUsernameExist(Account Account);

        Task<Account> Add(Account Account);

        Task Update(Account Account);
        Task UpdateAccountVip(Account Account);
        
        Task Delete(Account Account);

        Task<int> DeletePermanently(int? AccountId);
        Task<List<Account>> DetailFromUserIDAndPassword(int? Id, string password);
        Task<List<Account>> DetailAccount(int? id);
        Task<List<Account>> DetailByEmail(string email);
        Task<List<Account>> AutoDownGradeMembership();
        int CountAccount();

        Account GetAccount(int accountId);
    }
}
