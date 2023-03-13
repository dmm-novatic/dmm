
using Novatic.Models.CRM;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        NovaticDBContext db;
        public ProductCategoryRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<ProductCategory>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.ProductCategory
                        where (row.Active == 1) && (!row.Name.Contains("banner"))
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


        public async Task<List<ProductCategory>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.ProductCategory
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword))) && (row.Name.Contains("banner"))
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
        public async Task<List<ProductCategory>> SearchById(string keyword)
        {
            if (db != null)
            {

                try
                {
                    if (int.Parse(keyword) == 0)
                    {
                        return await (
                        from row in db.ProductCategory
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                    }
                    else
                    {
                        return await (
                        from row in db.ProductCategory
                        where (row.Active == 1 && (row.Id == (int.Parse(keyword)) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                        ).ToListAsync();
                    }


                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<ProductCategory>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.ProductCategory
                        where (row.Active == 1) && (row.Name.Contains("banner"))
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


        public async Task<List<ProductCategory>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.ProductCategory
                        where (row.Active == 1 && row.Id == id) && (row.Name.Contains("banner"))
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


        public async Task<ProductCategory> Add(ProductCategory obj)
        {
            if (db != null)
            {
                try
                {
                    await db.ProductCategory.AddAsync(obj);
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


        public async Task Update(ProductCategory obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.ProductCategory.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.ParentId).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
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


        public async Task Delete(ProductCategory obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.ProductCategory.Attach(obj);
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
                    var obj = await db.ProductCategory.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.ProductCategory.Remove(obj);

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


        public int CountProductCategory()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.ProductCategory
                        where row.Active == 1 && (row.Name.Contains("banner"))
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
    }
}

