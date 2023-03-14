using System;

namespace Novatic.Models.CRM.ProductMetaRessponse
{
    public class CartResponseForm
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Active { get; set; }
        public int Quantity { get; set; }
        public int price { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string img { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

    }
}
