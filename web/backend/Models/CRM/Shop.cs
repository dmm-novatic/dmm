using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Shop
    {
        public Shop()
        {
            Orders = new HashSet<Orders>();
            ShopMeta = new HashSet<ShopMeta>();
            Warehouse = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }
        public int ShopTypeId { get; set; }
        public int ShopStatusId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int Active { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressWard { get; set; }
        public string AddressDetail { get; set; }

        public virtual Account Account { get; set; }
        public virtual ShopStatus ShopStatus { get; set; }
        public virtual ShopType ShopType { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Orders> Orders { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<ShopMeta> ShopMeta { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
