using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Promotion
    {
        public Promotion()
        {
            PromotionMeta = new HashSet<PromotionMeta>();
            Voucher = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int Active { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ShopId { get; set; }

        public virtual ICollection<PromotionMeta> PromotionMeta { get; set; }
        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
