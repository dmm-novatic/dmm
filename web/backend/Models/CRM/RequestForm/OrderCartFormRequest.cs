using System;

namespace Novatic.Models.CRM.RequestForm
{
    public class OrderCartFormRequest
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Active { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; } 
    }
}
