
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        NovaticDBContext db;
        public AccountTypeRepository(NovaticDBContext _db)
        {
            db = _db;
        }


        public async Task<List<AccountType>> List()
        {
            if (db != null)
            {
                return await (
                    from row in db.AccountType
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<AccountType>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from row in db.AccountType
                    where (row.Active == 1 && (row.Name.Contains(keyword) || row.Description.Contains(keyword)))
                    orderby row.Id descending
                    select row
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<AccountType>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from row in db.AccountType
                    where (row.Active == 1)
                    orderby row.Id descending
                    select row
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<AccountType>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.AccountType
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }


        public async Task<AccountType> Add(AccountType obj)
        {
            if (db != null)
            {
                await db.AccountType.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(AccountType obj)
        {
            if (db != null)
            {
                //Update that object
                db.AccountType.Attach(obj);
                // db.Entry(obj).Property(x => x.Name).IsModified = true;
                // db.Entry(obj).Property(x => x.Description).IsModified = true;
                // db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                //db.Entry(obj).Property(x => x.CreatedTime).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(AccountType obj)
        {
            if (db != null)
            {
                //Update that obj
                db.AccountType.Attach(obj);
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
                var obj = await db.AccountType.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.AccountType.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}

