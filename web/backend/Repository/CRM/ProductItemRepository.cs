
using Novatic.Models.CRM;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class ProductItemRepository : IProductItemRepository
    {
        NovaticDBContext db;
        public ProductItemRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<ProductItem>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.ProductItem
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


        public async Task<List<ProductItem>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.ProductItem
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


        public async Task<List<ProductItem>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.ProductItem
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


        public async Task<List<ProductItem>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.ProductItem
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


        public async Task<ProductItem> Add(ProductItem obj)
        {
            if (db != null)
            {
                try
                {
                    await db.ProductItem.AddAsync(obj);
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


        public async Task Update(ProductItem obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.ProductItem.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.GuId).IsModified = true;
                    db.Entry(obj).Property(x => x.WarehouseId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductId).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Quantity).IsModified = true;
                    db.Entry(obj).Property(x => x.QuantityAvailable).IsModified = true;
                    db.Entry(obj).Property(x => x.BuyPrice).IsModified = true;
                    db.Entry(obj).Property(x => x.ListPrice).IsModified = true;
                    db.Entry(obj).Property(x => x.SalePrice).IsModified = true;
                    db.Entry(obj).Property(x => x.Photo).IsModified = true;
                    db.Entry(obj).Property(x => x.Info).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }
        }


        public async Task Delete(ProductItem obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.ProductItem.Attach(obj);
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
                    var obj = await db.ProductItem.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.ProductItem.Remove(obj);

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


        public int CountProductItem()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.ProductItem
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

        public ProductItem GetByProductID(int productId)
        {
            if (db != null)
            {
                try
                {
                    return (
                        from row in db.ProductItem
                        where (row.Active == 1) && (row.ProductId == productId)
                        select row
                    ).AsNoTracking().First();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public ProductItem GetById(int Id)
        {
            if (db != null)
            {
                try
                {
                    return (
                        from row in db.ProductItem
                        where (row.Active == 1) && (row.Id == Id)
                        select row
                    ).AsNoTracking().First();
                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<ProductItem>> getListProductItemByShopID(int shopId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                 from PI in db.ProductItem
                 from P in db.Product
                 where (
                     PI.Active == 1 && PI.ProductId == P.Id && P.ShopId == shopId
                 )
                 orderby PI.CreatedTime descending
                 select PI
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

