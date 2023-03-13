using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Authentication
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ValidTime { get; set; }

        public virtual Account Account { get; set; }
    }
}
