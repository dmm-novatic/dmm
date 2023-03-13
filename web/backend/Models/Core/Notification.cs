using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Novatic.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public int AccountId { get; set; }
        public int NotificationStatusId { get; set; }
        public string Name { get; set; }
        public int? SenderId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
