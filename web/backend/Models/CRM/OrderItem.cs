using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            OrderItemMeta = new HashSet<OrderItemMeta>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Orders Order { get; set; }
        public virtual ProductItem ProductItem { get; set; }
        public virtual ICollection<OrderItemMeta> OrderItemMeta { get; set; }
    }
}
