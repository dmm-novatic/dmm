using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Active { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }
    }
}
