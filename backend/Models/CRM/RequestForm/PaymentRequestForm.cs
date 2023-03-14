namespace Novatic.Models.CRM.RequestForm
{
    public class PaymentRequestForm
    {
        public string OrderId { get; set; }
        public string CartID { get; set; }
        public int Amount { get; set; }
        public string OrderInfor { get; set; }

    }
}
