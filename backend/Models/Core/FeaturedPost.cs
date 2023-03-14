using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class FeaturedPost
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int TypeID { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Post Post { get; set; }
    }
}
