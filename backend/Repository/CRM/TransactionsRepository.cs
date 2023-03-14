  
    using Novatic.Models.CRM; using Novatic.Models; 
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class TransactionsRepository : ITransactionsRepository
        {
            NovaticDBContext db;
            public TransactionsRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<Transactions>> List()
            {
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.Transactions
                            where (row.Active == 1)
                            orderby row.Id descending
                            select row
                        ).ToListAsync();
                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<Transactions>> Search(string keyword)
            {
                if (db != null)
                {
                    
                    try {
                            return await (
                                from row in db.Transactions
                                where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                                orderby row.Id descending
                                select row
                            ).ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<Transactions>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.Transactions
                            where (row.Active == 1)
                            orderby row.Id descending
                            select row
                        ).Skip(offSet).Take(pageSize).ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task<List<Transactions>> Detail(int? id)
            {
                if (db != null)
                {
                    try {
                        return await (
                            from row in db.Transactions
                            where (row.Active == 1 && row.Id == id)
                            select row)
                        .ToListAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


        public async Task<List<Transactions>> ListByShopId(int shopId)
        {
            if (db != null)
            {
                try
                {
                    var data = await db.Transactions.Where(t => db.OrderTransaction.Any(
                         ot => ot.TransactionId == t.Id && db.Orders.Any(
                             o => o.Id == ot.OrderId && o.ShopId == shopId
                             )
                        )).ToListAsync();
                    return data;

                }
                catch (Exception e)
                {
                    string error = e.Message;
                }
            }

            return null;
        }



        public async Task<Transactions> Add(Transactions obj)
            {
                if (db != null)
                {
                    try {
                        await db.Transactions.AddAsync(obj);
                        await db.SaveChangesAsync();
    
                        return obj;

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return null;
            }


            public async Task Update(Transactions obj)
            {
                if (db != null)
                {
                    try {
                        //Update that object
                        db.Transactions.Attach(obj);
                        // db.Entry(obj).Property(x => x.Name).IsModified = true;
                        // db.Entry(obj).Property(x => x.Description).IsModified = true;
                        // db.Entry(obj).Property(x => x.Active).IsModified = true;
                        	db.Entry(obj).Property(x => x.GuId).IsModified = true;
	db.Entry(obj).Property(x => x.TransactionTypeId).IsModified = true;
	db.Entry(obj).Property(x => x.TransactionStatusId).IsModified = true;
	db.Entry(obj).Property(x => x.Name).IsModified = true;
	db.Entry(obj).Property(x => x.Description).IsModified = true;
	db.Entry(obj).Property(x => x.Info).IsModified = true;
	db.Entry(obj).Property(x => x.Active).IsModified = true;
	db.Entry(obj).Property(x => x.Amount).IsModified = true;
	db.Entry(obj).Property(x => x.SenderInfo).IsModified = true;
	db.Entry(obj).Property(x => x.ReceiverInfo).IsModified = true;

    
                        //Commit the transaction
                        await db.SaveChangesAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }
            }


            public async Task Delete(Transactions obj)
            {
                if (db != null)
                {
                    try {
                        //Update that obj
                        db.Transactions.Attach(obj);
                        db.Entry(obj).Property(x => x.Active).IsModified = true;
    
                        //Commit the transaction
                        await db.SaveChangesAsync();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }
            }

            public async Task<int> DeletePermanently(int? objId)
            {
                int result = 0;

                if (db != null)
                {
                    try {
                        //Find the obj for specific obj id
                        var obj = await db.Transactions.FirstOrDefaultAsync(x => x.Id == objId);
    
                        if (obj != null)
                        {
                            //Delete that obj
                            db.Transactions.Remove(obj);
    
                            //Commit the transaction
                            result = await db.SaveChangesAsync();
                        }
                        return result;

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return result;
            }


            public int CountTransactions()
            {
                int result = 0;

                if (db != null)
                {
                    try {
                        //Find the obj for specific obj id
                        result = (
                            from row in db.Transactions
                            where row.Active == 1
                            select row
                        ).Count();

                    } catch(Exception e){
                        string error = e.Message;
                    }
                }

                return result;
            }

        public Transactions GetById(int Id)
        {
            if (db != null)
            {
                try
                {
                    return (
                        from row in db.Transactions
                        where (row.Active == 1) && (row.Id == Id)                     
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

    