
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.ViewModel;

namespace Novatic.Repository
{
    public class PostTopicRepository : IPostTopicRepository
    {
        NovaticDBContext db;
        public PostTopicRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<PostTopic>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTopic
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostTopic>> ListByTopicId(int TopicId)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTopic
                    where (row.Active == 1 && row.TopicId == TopicId)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostTopicViewModel>> ListViewModelByTopicId(int topicId)
        {
            if (db != null)
            {
                return await (
                    from pt in db.PostTopic
                    from p in db.Post
                    from t in db.Topic
                    where(
                        pt.Active == 1 && pt.TopicId == topicId
                        && pt.PostId == p.Id
                        && pt.TopicId == t.Id
                    )
                    select new PostTopicViewModel
                    {
                        Id = pt.Id,
                        TopicId = pt.TopicId,
                        TopicName = t.Name,
                        PostId = pt.PostId,
                        PostName = p.Name,
                        Active = pt.Active,
                        Name = pt.Name,
                        Description = pt.Description,
                        CreatedTime = pt.CreatedTime
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<PostTopicViewModel>> SearchViewModelByTopicId(int topicId, string keyword)
        {
            if (db != null)
            {
                return await (
                    from pt in db.PostTopic
                    from p in db.Post
                    from t in db.Topic
                    where (
                        pt.Active == 1 && pt.TopicId == topicId
                        && (pt.Name.Contains(keyword)|| pt.Description.Contains(keyword))
                        && pt.PostId == p.Id
                        && pt.TopicId == t.Id
                    )
                    select new PostTopicViewModel
                    {
                        Id = pt.Id,
                        TopicId = pt.TopicId,
                        TopicName = t.Name,
                        PostId = pt.PostId,
                        PostName = p.Name,
                        Active = pt.Active,
                        Name = pt.Name,
                        Description = pt.Description,
                        CreatedTime = pt.CreatedTime
                    }
                ).ToListAsync();
            }

            return null;
        }

        public int CountByTopicId(int topicId)
        {
            int result = 0;
            if (db != null)
            {
                result = (
                    from row in db.PostTopic
                    where row.Active == 1 && row.TopicId == topicId
                    select row
                ).Count();
            }
            return result;
        }

        public async Task<List<PostTopic>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTopic
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostTopic>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.PostTopic
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<PostTopic>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.PostTopic
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<PostTopic> Add(PostTopic obj)
        {
            if (db != null)
            {
                await db.PostTopic.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(PostTopic obj)
        {
            if (db != null)
            {
                //Update that object
                db.PostTopic.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.PostId).IsModified = true;
                db.Entry(obj).Property(x => x.TopicId).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(PostTopic obj)
        {
            if (db != null)
            {
                //Update that obj
                db.PostTopic.Attach(obj);
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
                var obj = await db.PostTopic.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.PostTopic.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<int> CheckExistForAutoCreate(int postId, int topicId)
        {
            int result = 0;
            if (db != null)
            {
                var obj = await db.PostTopic.FirstOrDefaultAsync(x => x.PostId == postId && x.TopicId == topicId && x.Active == 1);
                if (obj != null)
                {
                    result = 1;
                }
            }
            return result;
        }
    }
}

