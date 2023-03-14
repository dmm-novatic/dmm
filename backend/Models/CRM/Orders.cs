using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItem = new HashSet<OrderItem>();
            OrderMeta = new HashSet<OrderMeta>();
            OrderTransaction = new HashSet<OrderTransaction>();
            OrderVoucher = new HashSet<OrderVoucher>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderPaymentStatusId { get; set; }
        public int AccountId { get; set; }
        public int ShopId { get; set; }
        public string Voucher { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public int Discount { get; set; }
        public int FinalPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int Active { get; set; }
        public string Feedback { get; set; }

        public DateTime CreatedTime { get; set; }

        public string DeliveryCode { get; set; }
        public string ShippingUnit { get; set; }
        public virtual Account Account { get; set; }

        public virtual OrderPaymentStatus OrderPaymentStatus { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Shop Shop { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderItem> OrderItem { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderMeta> OrderMeta { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderTransaction> OrderTransaction { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderVoucher> OrderVoucher { get; set; }
    }
}
