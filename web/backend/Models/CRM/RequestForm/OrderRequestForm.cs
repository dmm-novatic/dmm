using System;
using System.Collections.Generic;

namespace Novatic.Models.CRM.RequestForm
{
    public class OrderRequestForm
    {
        public int Id { get; set; }
        public string GuId { get; set; }
        public int OrderTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderPaymentStatusId { get; set; }
        public int AccountId { get; set; }
        public int ShopId { get; set; }
        public string voucherCode { get; set; }
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

        public string ShippingUnit { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<OrderCartFormRequest> ListCart { get; set; } 
    }
}
