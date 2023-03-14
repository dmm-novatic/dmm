using System;

namespace Novatic.Models.CRM.ResponseForm
{
    public class detailsOrderResponse
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
