using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models.CRM
{
    public partial class Transactions
    {
        public Transactions()
        {
            OrderTransaction = new HashSet<OrderTransaction>();
            TransactionMeta = new HashSet<TransactionMeta>();
        }

        public int Id { get; set; }
        public string GuId { get; set; }
        public int TransactionTypeId { get; set; }
        public int TransactionStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public int Active { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Amount { get; set; }
        public string SenderInfo { get; set; }
        public string ReceiverInfo { get; set; }

        public virtual TransactionStatus TransactionStatus { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<OrderTransaction> OrderTransaction { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<TransactionMeta> TransactionMeta { get; set; }
    }
}
