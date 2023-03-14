namespace Novatic.Models.CRM.RequestForm
{
    public class CartRequestForm
    {
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
