using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int Active { get; set; }
        public int Priority { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Url2 { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
