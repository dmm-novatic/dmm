using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Tag
    {
        public Tag()
        {
            PostTag = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Slug { get; set; }
        public string Slug2 { get; set; }
        public int PostCount { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<PostTag> PostTag { get; set; }

    }
}
