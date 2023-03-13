using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Novatic.Models.CRM;

namespace Novatic.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountMeta = new HashSet<AccountMeta>();
            ActivityLog = new HashSet<ActivityLog>();
            Authentication = new HashSet<Authentication>();
            Comment = new HashSet<Comment>();
            FavouritePost = new HashSet<FavouritePost>();
            ReadedPost = new HashSet<ReadedPost>();
            Post = new HashSet<Post>();
            Contact = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string IdCardNumber { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        public string IDCardNumberPhoto1 { get; set; }
        public string IDCardNumberPhoto2 { get; set; }
        public DateTime? DoB { get; set; }
        public string Zipcode { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressWard { get; set; }
        public int IsActivated { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<AccountMeta> AccountMeta { get; set; }
        public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        public virtual ICollection<Authentication> Authentication { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<FavouritePost> FavouritePost { get; set; }
        public virtual ICollection<ReadedPost> ReadedPost { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<SurveyAccount> SurveyAccount { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Shop> Shop { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
