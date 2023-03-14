using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ViewStatusID { get; set; }
        public int IsChecked { get; set; }
    }
}
