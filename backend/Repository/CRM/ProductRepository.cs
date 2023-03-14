
using Novatic.Models.CRM;
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Novatic.Repository
{
    public class ProductRepository : IProductRepository
    {
        NovaticDBContext db;
        public ProductRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Product>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Product
                        where (row.Active == 1) && (row.ProductStatusId != 1000003)
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


        public async Task<List<Product>> Search(string keyword)
        {
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Product
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

        public async Task<List<Product>> getListProductByCate(int cateID, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    if (cateID == 0)
                    {
                        return await (
                       from row in db.Product
                       orderby row.Id descending
                       select row
                   ).Skip(offSet).Take(pageSize).ToListAsync();
                    }
                    else
                    {
                        return await (
                        from row in db.Product
                        where (row.Active == 1 && row.ProductCategoryId == cateID) && (row.ProductStatusId != 1000003)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();

                    }


                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<Product>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Product
                        where (row.Active == 1) && (row.ProductStatusId != 1000003)
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


        public async Task<List<Product>> Detail(int? id)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Product
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



        public async Task<List<Product>> ListByShopId(int ShopId)
        {
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Product
                        where (row.Active == 1 && row.ShopId == ShopId)
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

        public async Task<Product> Add(Product obj)
        {
            if (db != null)
            {
                try
                {
                    await db.Product.AddAsync(obj);
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


        public async Task Update(Product obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that object
                    db.Product.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.GuId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductTypeId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductStatusId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductCategoryId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductBrandId).IsModified = true;
                    db.Entry(obj).Property(x => x.ProductDiscountTypeId).IsModified = true;
                    db.Entry(obj).Property(x => x.Name).IsModified = true;
                    db.Entry(obj).Property(x => x.Origin).IsModified = true;
                    db.Entry(obj).Property(x => x.Description).IsModified = true;
                    db.Entry(obj).Property(x => x.Active).IsModified = true;
                    db.Entry(obj).Property(x => x.Photo).IsModified = true;
                    db.Entry(obj).Property(x => x.Price).IsModified = true;
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


        public async Task Delete(Product obj)
        {
            if (db != null)
            {
                try
                {
                    //Update that obj
                    db.Product.Attach(obj);
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
                    var obj = await db.Product.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Product.Remove(obj);

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


        public int CountProduct()
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Product
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
        public int CountProductByCategory(int cateId)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Product
                        where (row.Active == 1 && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
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
        public int CountProductByBrand(int brandId)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Product
                        where (row.Active == 1 && row.ProductBrandId == brandId) && (row.ProductBrandId != 1000003)
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
        public int CountProductbyCate(int cateID)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Product
                        where (row.Active == 1) && (row.ProductCategoryId == cateID) && (row.ProductStatusId != 1000003)
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
        public async Task<List<Product>> getListProductByBrand(int branhId, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {

                try
                {
                    return await (
                        from row in db.Product
                        where (row.Active == 1 && row.ProductBrandId == branhId) && (row.ProductStatusId != 1000003)
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



        public async Task<List<Product>> getListProductByCateAndName(int cateId, int pageIndex, int pageSize, string textSearch, int shopId)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            string keyword = "";
            keyword = textSearch;
            // Xóa đầu cuối
            Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
            string[] sub = null;
            string first = "";
            int a = shopId;

            string last = "";
            if (keyword != null)
            {
                keyword = trimmer.Replace(keyword, " ");
                sub = keyword.Split(" ");
            }



            if (sub != null)
            {
                if (sub.Length > 1)
                {
                    first = sub[0];
                    last = sub[1];
                }

            }

            if (db != null)
            {
                try
                {
                    if (shopId == 0)
                    {
                        if (cateId == 0 && textSearch != null)
                        {
                            if (first != "" && last != "")
                            {
                                var data = await (
                                from row in db.Product
                                where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword) || (row.Name.Contains(first) && row.Name.Contains(last)) || (row.Description.Contains(first) && row.Description.Contains(last))))
                                orderby row.Id descending
                                select row
                                ).ToListAsync();
                                return data;
                            }
                            else
                            {
                                var data = await (
                                 from row in db.Product
                                 where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                                 orderby row.Id descending
                                 select row
                                                                               ).ToListAsync();
                                return data;
                            }


                        }
                        else if (cateId != 0 && textSearch != null)
                        {
                            if (first != "" && last != "")
                            {
                                return await (
                          from row in db.Product
                          where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword) || (row.Name.Contains(first) && row.Name.Contains(last)) || (row.Description.Contains(first) && row.Description.Contains(last))) && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
                          orderby row.Id descending
                          select row
                         ).Skip(offSet).Take(pageSize).ToListAsync();
                            }
                            else
                            {
                                return await (
                                from row in db.Product
                                where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)) && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
                                orderby row.Id descending
                                select row
                                ).Skip(offSet).Take(pageSize).ToListAsync();
                            }

                        }
                        else if (cateId != 0 && textSearch == null)
                        {

                            return await (
                      from row in db.Product
                      where (row.Active == 1 && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
                      orderby row.Id descending
                      select row
                     ).Skip(offSet).Take(pageSize).ToListAsync();


                        }
                        else if (cateId == 0 && textSearch == null)
                        {
                            return await (
                     from row in db.Product
                     where (row.Active == 1) && (row.ProductStatusId != 1000003)
                     orderby row.Id descending
                     select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();
                        }
                    }
                    else
                    {
                        if (cateId == 0 && textSearch != null)
                        {
                            if (first != "" && last != "")
                            {
                                var data = await (
                                from row in db.Product
                                where (row.Active == 1 && row.ShopId == shopId && (row.Name.Contains(keyword) || row.Description.Contains(keyword) || (row.Name.Contains(first) && row.Name.Contains(last)) || (row.Description.Contains(first) && row.Description.Contains(last))))
                                orderby row.Id descending
                                select row
                                ).ToListAsync();
                                return data;
                            }
                            else
                            {
                                var data = await (
                                 from row in db.Product
                                 where (row.Active == 1 && row.ShopId == shopId && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                                 orderby row.Id descending
                                 select row
                                                                               ).ToListAsync();
                                return data;
                            }


                        }
                        else if (cateId != 0 && textSearch != null)
                        {
                            if (first != "" && last != "")
                            {
                                return await (
                          from row in db.Product
                          where (row.Active == 1 && row.ShopId == shopId && (row.Name.Contains(keyword) || row.Description.Contains(keyword) || (row.Name.Contains(first) && row.Name.Contains(last)) || (row.Description.Contains(first) && row.Description.Contains(last))) && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
                          orderby row.Id descending
                          select row
                         ).Skip(offSet).Take(pageSize).ToListAsync();
                            }
                            else
                            {
                                return await (
                                from row in db.Product
                                where (row.Active == 1 && row.ShopId == shopId && (row.Name.Contains(keyword) || row.Description.Contains(keyword)) && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
                                orderby row.Id descending
                                select row
                                ).Skip(offSet).Take(pageSize).ToListAsync();
                            }

                        }
                        else if (cateId != 0 && textSearch == null)
                        {

                            return await (
                      from row in db.Product
                      where (row.Active == 1 && row.ShopId == shopId && row.ProductCategoryId == cateId) && (row.ProductStatusId != 1000003)
                      orderby row.Id descending
                      select row
                     ).Skip(offSet).Take(pageSize).ToListAsync();


                        }
                        else if (cateId == 0 && textSearch == null)
                        {
                            return await (
                     from row in db.Product
                     where (row.Active == 1 && row.ShopId == shopId && row.ProductStatusId != 1000003)
                     orderby row.Id descending
                     select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();
                        }
                    }



                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public Product getListId(int productID)
        {
            if (db != null)
            {
                try
                {
                    Product product = (from row in db.Product
                                       where (row.Active == 1) && (row.Id == productID)
                                       select row).First();

                    return product;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }

        public async Task<List<Product>> getListProductByShopID(int ShopId, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                try
                {
                    return await (
                        from row in db.Product
                        where (row.Active == 1 && row.ShopId == ShopId) && (row.ProductStatusId != 1000003)
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

        public int CountProductByShopID(int ShopID)
        {
            int result = 0;

            if (db != null)
            {
                try
                {
                    //Find the obj for specific obj id
                    result = (
                        from row in db.Product
                        where (row.Active == 1) && (row.ShopId == ShopID) && (row.ProductStatusId != 1000003)
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

