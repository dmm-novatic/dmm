
using Novatic.Models.CRM;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        NovaticDBContext db;
        public OrderItemRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<OrderItem>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.OrderItem
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


        public async Task<List<OrderItem>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.OrderItem
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


        public async Task<List<OrderItem>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.OrderItem
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


        public async Task<List<OrderItem>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.OrderItem
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

        //incomplete
        public async Task<List<OrderItem>> ListByShopId(int? shopId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.OrderItem
                        where (row.Active == 1 && row.Id == shopId)
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

        public async Task<OrderItem> Add(OrderItem obj)
        {
            if (db != null)
            {
                try
                {
                    await db.OrderItem.AddAsync(obj);
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


        public async Task Update(OrderItem obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.OrderItem.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.OrderId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductItemId).IsModified = true;
                    db.Entry(obj).Property(x => x.Quantity).IsModified = true;
                    db.Entry(obj).Property(x => x.Price).IsModified = true;
                    db.Entry(obj).Property(x => x.TotalPrice).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(OrderItem obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.OrderItem.Attach(obj);
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
                    var obj = await db.OrderItem.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.OrderItem.Remove(obj);

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


        public int CountOrderItem()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.OrderItem
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

        public async Task AddRange(List<OrderItem> OrderItem)
        {

            if (db != null)
            {
                try
                {
                    await db.OrderItem.AddRangeAsync(OrderItem);
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }

        public async Task<List<OrderItem>> ListByOrderId(int orderId)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.OrderItem
                        where (row.Active == 1 && row.OrderId == orderId)
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

