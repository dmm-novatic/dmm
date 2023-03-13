
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class TopicRepository : ITopicRepository
    {
        NovaticDBContext db;
        public TopicRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<Topic>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.Topic
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<Topic>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.Topic
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<Topic>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.Topic
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<Topic>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Topic
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<Topic> Add(Topic obj)
        {
            if (db != null)
            {
                await db.Topic.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Topic obj)
        {
            if (db != null)
            {
                //Update that object
                db.Topic.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Name2).IsModified = true;
                db.Entry(obj).Property(x => x.Slug).IsModified = true;
                db.Entry(obj).Property(x => x.Slug2).IsModified = true;
                db.Entry(obj).Property(x => x.Color).IsModified = true;
                db.Entry(obj).Property(x => x.Photo).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Text).IsModified = true;
                db.Entry(obj).Property(x => x.Description2).IsModified = true;
                db.Entry(obj).Property(x => x.Text2).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(Topic obj)
        {
            if (db != null)
            {
                //Update that obj
                db.Topic.Attach(obj);
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
                var obj = await db.Topic.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.Topic.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Topic>> DetailBySlug(string slug)
        {
            if (db != null)
            {
                return await (
                    from row in db.Topic
                    where (row.Active == 1 && (row.Slug.Contains(slug) || row.Slug2.Contains(slug)))
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public int CountTopic()
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result = (
                    from row in db.Topic
                    where row.Active == 1
                    select row
                ).Count();
            }

            return result;
        }
    }
}

