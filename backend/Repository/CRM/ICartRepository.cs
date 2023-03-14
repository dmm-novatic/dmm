
using Novatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models.CRM;

namespace Novatic.Repository
{
    public interface ICartRepository
    {
        Task<List<Cart>> List();

        Task<List<Cart>> List(int accountID);

        Task<List<Cart>> Search(string keyword);

        Task<List<Cart>> ListPaging(int pageIndex, int pageSize);

        Task<List<Cart>> Detail(int? postId);

        Task<Cart> Add(Cart Cart);

        Task Update(Cart Cart);

        Task Delete(Cart Cart);

        Task<int> DeletePermanently(int? CartId);

        int CountCart();

        Cart checkExisProduct(int ProductId , int accountID);
        Cart GetCartById(int ID);

        int CountCartByAccountID(int AccountID);
    }
}
