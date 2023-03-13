using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            ProductItem = new HashSet<ProductItem>();
            WarehouseMeta = new HashSet<WarehouseMeta>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }
        public int ShopId { get; set; }
        public int WarehouseTypeId { get; set; }
        public int WarehouseStatusId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ContactPerson { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressWard { get; set; }
        public string AddressDetail { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual WarehouseStatus WarehouseStatus { get; set; }
        public virtual WarehouseType WarehouseType { get; set; }
        public virtual ICollection<ProductItem> ProductItem { get; set; }
        public virtual ICollection<WarehouseMeta> WarehouseMeta { get; set; }
    }
}
