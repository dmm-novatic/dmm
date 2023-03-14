
using Novatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.ViewModel;

namespace Novatic.Repository
{
    public class AccountRepository : IAccountRepository
    {
        NovaticDBContext db;
        public AccountRepository(NovaticDBContext _db)
        {
            db = _db;
        }

        public async Task<List<Account>> ListAccount()
        {
            if (db != null)
            {
                return await (
                   from row in db.Account
                   where (row.Active == 1)
                   orderby row.Id descending
                   select row
               ).ToListAsync();
            }
            return null;
        }

        public async Task<List<AccountViewModel>> List()
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = "",
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<AccountViewModel>> ListByShopId()
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    from o in db.Orders
                    from s in db.Shop
                    where (
                        a.Active == 1
                        && a.AccountTypeId == at.Id
                        && a.Id == o.AccountId
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = "",
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                ).ToListAsync();
            }

            return null;
        }



        public async Task<List<AccountViewModel>> Search(string keyword)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && (a.Name.Contains(keyword) || a.Description.Contains(keyword))
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                ).ToListAsync();
            }

            return null;
        }


        public async Task<List<AccountViewModel>> ListPaging(int pageIndex, int pageSize)
        {
            int offSet = 0;
            offSet = (pageIndex - 1) * pageSize;
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                ).Skip(offSet).Take(pageSize).ToListAsync();
            }

            return null;
        }


        public async Task<List<AccountViewModel>> Detail(int? id)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && a.Id == id
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                    ).ToListAsync();
            }

            return null;
        }

        public async Task<List<AccountViewModel>> Detail(string username)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && a.Username == username
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                ).ToListAsync();
            }

            return null;
        }

        public async Task<List<AccountViewModel>> Login(Account obj)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && (a.Username == obj.Username || a.Email == obj.Username || a.Phone == obj.Phone)
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                    ).ToListAsync();
            }
            return null;
        }

        public async Task<List<AccountViewModel>> CheckUpdate(Account obj)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && (a.Username == obj.Username || a.Email == obj.Username || a.Phone == obj.Phone)
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                    ).ToListAsync();
            }
            return null;
        }

        public async Task<List<AccountViewModel>> CheckEmailExist(Account obj)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && (a.Email == obj.Email)
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                    ).ToListAsync();
            }
            return null;
        }

        public async Task<List<AccountViewModel>> CheckUsernameExist(Account obj)
        {
            if (db != null)
            {
                return await (
                    from a in db.Account
                    from at in db.AccountType
                    where (
                        a.Active == 1
                        && (a.Username == obj.Username)
                        && a.AccountTypeId == at.Id
                    )
                    select new AccountViewModel
                    {
                        Id = a.Id,
                        AccountTypeID = a.AccountTypeId,
                        Active = a.Active,
                        Name = a.Name,
                        Email = a.Email,
                        Username = a.Username,
                        Password = a.Password,
                        Photo = a.Photo,
                        Phone = a.Phone,
                        Address = a.Address,
                        Description = a.Description,
                        Info = a.Info,
                        IdCardNumber = a.IdCardNumber,
                        CompanyNumber = a.CompanyNumber,
                        CompanyName = a.CompanyName,
                        CompanyInfo = a.CompanyInfo,
                        GoogleId = a.GoogleId,
                        FacebookId = a.FacebookId,
                        CreatedTime = a.CreatedTime,
                        AccountTypeName = at.Name,
                        IsActivated = a.IsActivated,
                        // Update
                        IDCardNumberPhoto1 = a.IDCardNumberPhoto1,
                        IDCardNumberPhoto2 = a.IDCardNumberPhoto2,
                        DoB = a.DoB,
                        Zipcode = a.Zipcode,
                        AddressCity = a.AddressCity,
                        AddressDistrict = a.AddressDistrict,
                        AddressWard = a.AddressWard,
                    }
                    ).ToListAsync();
            }
            return null;
        }

        public async Task<Account> Add(Account obj)
        {
            if (db != null)
            {
                await db.Account.AddAsync(obj);
                await db.SaveChangesAsync();

                return obj;
            }

            return null;
        }


        public async Task Update(Account obj)
        {
            if (db != null)
            {
                //Update that object
                //Password won't be updated here
                db.Account.Attach(obj);
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Photo).IsModified = true;
                db.Entry(obj).Property(x => x.Phone).IsModified = true;
                db.Entry(obj).Property(x => x.Address).IsModified = true;
                db.Entry(obj).Property(x => x.Info).IsModified = true;
                db.Entry(obj).Property(x => x.IdCardNumber).IsModified = true;
                db.Entry(obj).Property(x => x.CompanyNumber).IsModified = true;
                db.Entry(obj).Property(x => x.CompanyName).IsModified = true;
                db.Entry(obj).Property(x => x.CompanyInfo).IsModified = true;
                db.Entry(obj).Property(x => x.GoogleId).IsModified = true;
                db.Entry(obj).Property(x => x.FacebookId).IsModified = true;
                db.Entry(obj).Property(x => x.AccountTypeId).IsModified = true;
                db.Entry(obj).Property(x => x.IsActivated).IsModified = true;
                db.Entry(obj).Property(x => x.IDCardNumberPhoto1).IsModified = true;
                db.Entry(obj).Property(x => x.IDCardNumberPhoto2).IsModified = true;
                db.Entry(obj).Property(x => x.DoB).IsModified = true;
                db.Entry(obj).Property(x => x.Zipcode).IsModified = true;
                db.Entry(obj).Property(x => x.AddressCity).IsModified = true;
                db.Entry(obj).Property(x => x.AddressDistrict).IsModified = true;
                db.Entry(obj).Property(x => x.AddressWard).IsModified = true;


                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task UpdateAccountVip(Account obj)
        {
            if (db != null)
            {
                //Update that object
                db.Account.Attach(obj);
                db.Entry(obj).Property(x => x.Name).IsModified = true;
                db.Entry(obj).Property(x => x.Description).IsModified = true;
                db.Entry(obj).Property(x => x.Active).IsModified = true;
                db.Entry(obj).Property(x => x.Photo).IsModified = true;
                db.Entry(obj).Property(x => x.Phone).IsModified = true;
                db.Entry(obj).Property(x => x.Address).IsModified = true;
                db.Entry(obj).Property(x => x.Info).IsModified = true;
                db.Entry(obj).Property(x => x.IdCardNumber).IsModified = true;
                db.Entry(obj).Property(x => x.CompanyNumber).IsModified = true;
                db.Entry(obj).Property(x => x.CompanyName).IsModified = true;
                db.Entry(obj).Property(x => x.CompanyInfo).IsModified = true;
                db.Entry(obj).Property(x => x.GoogleId).IsModified = true;
                db.Entry(obj).Property(x => x.FacebookId).IsModified = true;
                db.Entry(obj).Property(x => x.AccountTypeId).IsModified = true;
                db.Entry(obj).Property(x => x.IsActivated).IsModified = true;
                db.Entry(obj).Property(x => x.IDCardNumberPhoto1).IsModified = true;
                db.Entry(obj).Property(x => x.IDCardNumberPhoto2).IsModified = true;
                db.Entry(obj).Property(x => x.DoB).IsModified = true;
                db.Entry(obj).Property(x => x.Zipcode).IsModified = true;
                db.Entry(obj).Property(x => x.AddressCity).IsModified = true;
                db.Entry(obj).Property(x => x.AddressDistrict).IsModified = true;
                db.Entry(obj).Property(x => x.AddressWard).IsModified = true;

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


        public async Task Delete(Account obj)
        {
            if (db != null)
            {
                //Update that obj
                db.Account.Attach(obj);
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
                var obj = await db.Account.FirstOrDefaultAsync(x => x.Id == objId);

                if (obj != null)
                {
                    //Delete that obj
                    db.Account.Remove(obj);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Account>> DetailFromUserIDAndPassword(int? id, string password)
        {

            if (db != null)
            {
                return await (
                    from row in db.Account
                    where (row.Active == 1 && row.Id == id && row.Password == password)
                    select row)
                .ToListAsync();
            }
            return null;
        }

        public async Task<List<Account>> DetailAccount(int? id)
        {
            if (db != null)
            {
                return await (
                    from row in db.Account
                    where (row.Active == 1 && row.Id == id)
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public async Task<List<Account>> DetailByEmail(string email)
        {
            if (db != null)
            {
                return await (
                    from row in db.Account
                    where (row.Active == 1 && row.Email == email)
                    select row)
                .ToListAsync();
            }

            return null;
        }

        public int CountAccount()
        {
            int result = 0;

            if (db != null)
            {
                //Find the obj for specific obj id
                result = (
                    from row in db.Account
                    where row.Active == 1
                    select row
                ).Count();
            }

            return result;
        }

        public async Task<List<Account>> AutoDownGradeMembership()
        {
            if (db != null)
            {
                var listAccount = await ListAccount();
                DateTime currentDate = DateTime.Now;
                for (int i = 0; i < listAccount.Count; i++)
                {
                    DateTime EndDatetimeMembership = Convert.ToDateTime(listAccount[i].Description);
                    int res = DateTime.Compare(EndDatetimeMembership, currentDate);
                    if (res > 0)
                    {

                    }
                }
            }

            return null;
        }

        public Account GetAccount(int accountId)
        {
            if (db != null)
            {
                return (
                   from row in db.Account
                   where (row.Active == 1) && (row.Id == accountId)
                   select row
               ).First();
            }
            return null;
        }
    }
}

