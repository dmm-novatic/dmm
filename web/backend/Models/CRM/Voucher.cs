using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Voucher
    {
        public Voucher()
        {
            OrderVoucher = new HashSet<OrderVoucher>();
            VoucherMeta = new HashSet<VoucherMeta>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }

        public int PromotionId { get; set; }
        public int VoucherTypeId { get; set; }
        public int VoucherStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int Active { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
        public string Code { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Promotion Promotion { get; set; }
        public virtual VoucherStatus VoucherStatus { get; set; }
        public virtual VoucherType VoucherType { get; set; }
        public virtual ICollection<OrderVoucher> OrderVoucher { get; set; }
        public virtual ICollection<VoucherMeta> VoucherMeta { get; set; }
    }
}
