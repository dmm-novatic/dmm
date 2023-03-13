using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class ProductItem
    {
        public ProductItem()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int QuantityAvailable { get; set; }
        public int BuyPrice { get; set; }
        public int ListPrice { get; set; }
        public int SalePrice { get; set; }
        public string Photo { get; set; }
        public string Info { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
