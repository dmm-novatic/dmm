using System;

namespace Novatic.Models.CRM.RequestForm
{
    public class TransactionsRequestForm
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ReceiverInfor { get; set; }

    }
}
