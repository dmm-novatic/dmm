
using Novatic.Models;
using Novatic.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class CommentRepository : ICommentRepository
    {
        NovaticDBContext db;
        public CommentRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<CommentViewModel>> List()
        {
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    from p in db.Post
                    where (
                        cm.Approve == 1
                        && cm.Active == 1
                        && cm.PostId == p.Id
                        && ac.Id == cm.AccountId
                    )
                    orderby cm.Id descending
                    select new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        AccountName = ac.Name,
                        PostId = cm.PostId,
                        PostName = p.Name,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<CommentViewModel>> ListCommentAdmin()
        {
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    from p in db.Post
                    where (
                        cm.Active == 1
                        && cm.AccountId == ac.Id
                        && cm.PostId == p.Id
                    )
                    orderby cm.Id descending
                    select new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        AccountName = ac.Name,
                        PostId = cm.PostId,
                        PostName = p.Name,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<CommentViewModel>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    where (
                    cm.Approve == 1
                    && cm.AccountId == ac.Id
                    && cm.Active == 1
                    && (cm.Name.Contains(keyword) || cm.Description.Contains(keyword))
                    )
                    select new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        PostId = cm.PostId,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<CommentViewModel>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    from p in db.Post
                    where (
                        cm.Approve == 1
                        && cm.Active == 1
                        && cm.AccountId == ac.Id
                        && cm.PostId == p.Id
                        )
                    orderby cm.Id descending
                    select new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        AccountName = ac.Name,
                        PostId = cm.PostId,
                        PostName = p.Name,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }
        public async Task<List<CommentViewModel>> ListPagingPost(int PostID,int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    from p in db.Post
                    where (
                        cm.Active == 1
                        && cm.Approve == 1
                        && cm.AccountId == ac.Id
                        && cm.PostId == p.Id
                        && cm.PostId == PostID
                        )
                    orderby cm.Id descending
                    select new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        AccountName = ac.Name,
                        PostId = cm.PostId,
                        PostName = p.Name,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }

        public async Task<List<CommentViewModel>> ListPagingUser(int UserID, int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    from p in db.Post
                    from pc in db.PostCategory
                    where (
                        cm.Active == 1
                        && cm.Approve == 1
                        && cm.AccountId == ac.Id
                        && cm.PostId == p.Id
                        && p.PostCategoryId == pc.Id
                        && ac.Id == UserID
                        )
                    orderby cm.Id descending
                    select  new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        AccountName = ac.Name,
                        PostId = cm.PostId,
                        PostName = p.Name,
                        PostCategoryId = p.PostCategoryId,
                        PostCategoryName = pc.Name,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<CommentViewModel>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from cm in db.Comment
                    from ac in db.Account
                    where (
                    cm.Approve == 1
                    && cm.Active == 1
                    && cm.Id == id
                    )
                    select new CommentViewModel
                    {
                        Id = cm.Id,
                        AccountId = cm.AccountId,
                        PostId = cm.PostId,
                        Active = cm.Active,
                        Approve = cm.Approve,
                        Name = cm.Name,
                        Description = cm.Description,
                        Email = cm.Email,
                        Text = cm.Text,
                        Website = cm.Website,
                        CreatedTime = cm.CreatedTime,
                        Username = ac.Username,
                        Password = ac.Password,
                        Phone = ac.Phone,
                        Address = ac.Address,
                        Photo = ac.Photo,
                        Info = ac.Info,
                        IsChecked = cm.IsChecked
                    }
                    )
                .ToListAsync();
            }

            return null;
        }


        public async Task<Comment> Add(Comment obj)
        {
            if (db != null)
            {
                await db.Comment.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Comment obj)
        {
            if (db != null)
            {
                //Update that object
                db.Comment.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.PostId).IsModified = true;
                db.Entry(obj).Property(x => x.AccountId).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Approve).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Email).IsModified = true;
                db.Entry(obj).Property(x => x.Text).IsModified = true;
                db.Entry(obj).Property(x => x.Website).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;
                db.Entry(obj).Property(x => x.IsChecked).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(Comment obj)
        {
            if (db != null)
            {
                //Update that obj
                db.Comment.Attach(obj);
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
                var obj = await db.Comment.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.Comment.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public int CountCommentUnChecked()
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result = (
                    from row in db.Comment
                    where (row.Active == 1 && row.IsChecked == 0)
                    select row
                ).Count();
            }

            return result;
        }
    }
}

