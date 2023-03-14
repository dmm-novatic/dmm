using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class ActivityLog
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlSource { get; set; }
        public string IpAddress { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
        public string Os { get; set; }
        public string UserAgent { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Account Account { get; set; }
    }
}
