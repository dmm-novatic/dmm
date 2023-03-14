
using Novatic.Models.CRM;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        NovaticDBContext db;
        public OrdersRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Orders>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Orders
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


        public async Task<List<Orders>> ListByShopId(int shopId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Orders
                        where (row.Active == 1 && row.ShopId == shopId)
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


        public async Task<List<Orders>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Orders
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


        public async Task<List<Orders>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Orders
                        where (row.Active == 1)
                        orderby row.CreatedTime descending
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


        public async Task<List<Orders>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Orders
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


        public async Task<Orders> Add(Orders obj)
        {
            if (db != null)
            {
                try
                {
                    await db.Orders.AddAsync(obj);
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


        public async Task Update(Orders obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.Orders.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.GuId).IsModified = true;
                    db.Entry(obj).Property(x => x.OrderTypeId).IsModified = true;
                    db.Entry(obj).Property(x => x.OrderStatusId).IsModified = true;
                    db.Entry(obj).Property(x => x.OrderPaymentStatusId).IsModified = true;
                    db.Entry(obj).Property(x => x.AccountId).IsModified = true;
                    db.Entry(obj).Property(x => x.ShopId).IsModified = true;
                    db.Entry(obj).Property(x => x.Voucher).IsModified = true;
                    db.Entry(obj).Property(x => x.Price).IsModified = true;
                    db.Entry(obj).Property(x => x.TotalPrice).IsModified = true;
                    db.Entry(obj).Property(x => x.Discount).IsModified = true;
                    db.Entry(obj).Property(x => x.FinalPrice).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Info).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Feedback).IsModified = true;
                    db.Entry(obj).Property(x => x.DeliveryCode).IsModified = true;
                    db.Entry(obj).Property(x => x.ShippingUnit).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(Orders obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.Orders.Attach(obj);
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
                    var obj = await db.Orders.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Orders.Remove(obj);

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


        public int CountOrders()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Orders
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

        public async Task<List<Orders>> GetOrderByAcount(int AccountID, int orderStatusId)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Orders
                        where (row.Active == 1 && row.AccountId == AccountID && row.OrderStatusId == orderStatusId)
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

        public Orders GetORdersByOrderId(int orderId)
        {
            if (db != null)
            {

                try
                {
                    Orders orders = (
                        from row in db.Orders
                        where (row.Active == 1 && row.Id == orderId)
                        select row
                    ).First();
                    return orders;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<Orders>> ListByShopId(int shopId, int orderStatusId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Orders
                        where (row.Active == 1 && row.ShopId == shopId && row.OrderStatusId == orderStatusId)
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
    }
}

