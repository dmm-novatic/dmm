
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models.CRM;

namespace Novatic.Repository
{
    public class CartRepository : ICartRepository
    {
        NovaticDBContext db;
        public CartRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Cart>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Cart
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<List<Cart>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Cart
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                    ).ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<List<Cart>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Cart
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<List<Cart>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Cart
                        where (row.Active == 1 && row.Id == id)
                        select row)
                    .ToListAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task<Cart> Add(Cart obj)
        {
            if (db != null)
            {
                try
                {
                    await db.Cart.AddAsync(obj);
                    await db.SaveChangesAsync();

                    return obj;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }


        public async Task Update(Cart obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.Cart.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.AccountId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Quantity).IsModified = true;

                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(Cart obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.Cart.Attach(obj);
                    db.Entry(obj).Property(x => x.Active).IsModified = true;

                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }

        public async Task<int> DeletePermanently(int? objId)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    var obj = await db.Cart.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Cart.Remove(obj);

                        //Commit the transaction
                        result = await db.SaveChangesAsync();
                    }
                    return result;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return result;
        }


        public int CountCart()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Cart
                        where row.Active == 1
                        select row
                    ).Count();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return result;
        }

        public async Task<List<Cart>> List(int accountID)
        {
            if (db != null)
            {
                try
                {
                    return await(
                        from row in db.Cart
                        where row.Active == 1 && row.AccountId == accountID
                        orderby row.CreatedTime descending
                        select row
                    ).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public Cart checkExisProduct(int ProductId, int accountID)
        {
            if (db != null)
            {
                try
                {
                    return (
                        from row in db.Cart
                        where row.Active == 1 && row.AccountId == accountID && row.ProductId == ProductId
                        select row
                    ).First();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;

        }

        public int CountCartByAccountID(int AccountID)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Cart
                        where row.Active == 1 && row.AccountId == AccountID
                        select row
                    ).Count();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return result;
        }

        public Cart GetCartById(int ID)
        {
            if (db != null)
            {
                try
                {
                    return (
                        from row in db.Cart
                        where (row.Active == 1 && row.Id == ID)
                        select row
                    ).First();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }
    }
}

