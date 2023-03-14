using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Province
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
