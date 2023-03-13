
using Novatic.Models.CRM;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class ShopRepository : IShopRepository
    {
        NovaticDBContext db;
        public ShopRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Shop>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Shop
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


        public async Task<List<Shop>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Shop
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


        public async Task<List<Shop>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Shop
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


        public async Task<List<Shop>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Shop
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


        public async Task<List<Shop>> ListByAccountId(int id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Shop
                        where (row.Active == 1 && row.AccountId == id)
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


        public async Task<List<Shop>> DetailByAccountId(int? accountId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Shop
                        where (row.Active == 1 && row.AccountId == accountId)
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


        public async Task<Shop> Add(Shop obj)
        {
            if (db != null)
            {
                try
                {
                    await db.Shop.AddAsync(obj);
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


        public async Task Update(Shop obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.Shop.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.GuId).IsModified = true;
                    db.Entry(obj).Property(x => x.ShopTypeId).IsModified = true;
                    db.Entry(obj).Property(x => x.ShopStatusId).IsModified = true;
                    db.Entry(obj).Property(x => x.AccountId).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Photo).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Info).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.ContactPerson).IsModified = true;
                    db.Entry(obj).Property(x => x.Email).IsModified = true;
                    db.Entry(obj).Property(x => x.Phone).IsModified = true;
                    db.Entry(obj).Property(x => x.AddressCity).IsModified = true;
                    db.Entry(obj).Property(x => x.AddressDistrict).IsModified = true;
                    db.Entry(obj).Property(x => x.AddressWard).IsModified = true;
                    db.Entry(obj).Property(x => x.AddressDetail).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(Shop obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.Shop.Attach(obj);
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
                    var obj = await db.Shop.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Shop.Remove(obj);

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


        public int CountShop()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Shop
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

        public async Task<List<Shop>> ListTop5()
        {

            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Shop
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Take(5).ToListAsync();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public Shop GetShopbyID(int ID)
        {
            if (db != null)
            {
                try
                {
                    return (from row in db.Shop
                            where (row.Active == 1) && (row.Id == ID)
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

