  
    using Novatic.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Novatic.Repository
    {
        public class MessageRepository : IMessageRepository
        {
            NovaticDBContext db;
            public MessageRepository(NovaticDBContext _db)
            {
                db = _db;
            }


            public async Task<List<Message>> List()
            {
                if (db != null)
                {
                    return await (
                        from row in db.Message
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<Message>> Search(string keyword)
            {
                if (db != null)
                {
                    return await (
                        from row in db.Message
                        where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


            public async Task<List<Message>> ListPaging(int pageIndex, int pageSize)
            {
                int offSet = 0;
                offSet = (pageIndex - 1) * pageSize;
                if (db != null)
                {
                    return await (
                        from row in db.Message
                        where (row.Active == 1)
                        orderby row.Id descending
                        select row
                    ).Skip(offSet).Take(pageSize).ToListAsync();
                }

                return null;
            }


            public async Task<List<Message>> Detail(int? id)
            {
                if (db != null)
                {
                    return await (
                        from row in db.Message
                        where (row.Active == 1 && row.Id == id)
                        select row)
                    .ToListAsync();
                }

                return null;
            }


            public async Task<Message> Add(Message obj)
            {
                if (db != null)
                {
                    await db.Message.AddAsync(obj);
                    await db.SaveChangesAsync();

                    return obj;
                }

                return null;
            }


            public async Task Update(Message obj)
            {
                if (db != null)
                {
                    //Update that object
                    db.Message.Attach(obj);
                    // db.Entry(obj).Property(x => x.Name).IsModified = true;
                    // db.Entry(obj).Property(x => x.Description).IsModified = true;
                    // db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.Active).IsModified = true;
	                db.Entry(obj).Property(x => x.Name).IsModified = true;
	                db.Entry(obj).Property(x => x.Sender).IsModified = true;
	                db.Entry(obj).Property(x => x.Source).IsModified = true;
	                db.Entry(obj).Property(x => x.Description).IsModified = true;
	                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;
	                db.Entry(obj).Property(x => x.ViewStatusID).IsModified = true;
	                db.Entry(obj).Property(x => x.IsChecked).IsModified = true;


                    //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }


            public async Task Delete(Message obj)
            {
                if (db != null)
                {
                    //Update that obj
                    db.Message.Attach(obj);
                    db.Entry(obj).Property(x => x.Active).IsModified = true;

                    //Commit the transaction
                    await db.SaveChangesAsync();
                }
            }

            public async Task<int> DeletePermanently(int? objId)
            {
                int result = 0;

                if (db != null)
                {
                    //Find the obj for specific obj id
                    var obj = await db.Message.FirstOrDefaultAsync(x => x.Id == objId);

                    if (obj != null)
                    {
                        //Delete that obj
                        db.Message.Remove(obj);

                        //Commit the transaction
                        result = await db.SaveChangesAsync();
                    }
                    return result;
                }

                return result;
            }
            public async Task<List<Message>> ListMessage()
            {
                if (db != null)
                {
                    return await (
                        from row in db.Message
                        where (row.Active == 1 && row.ViewStatusID==10001)
                        orderby row.Id descending
                        select row
                    ).ToListAsync();
                }

                return null;
            }


        }
    }

    