using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Topic
    {
        public Topic()
        {
            PostTopic = new HashSet<PostTopic>();
        }

        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Slug { get; set; }
        public string Slug2 { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Description2 { get; set; }
        public string Text2 { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<PostTopic> PostTopic { get; set; }
    }
}
