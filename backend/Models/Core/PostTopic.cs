﻿using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class PostTopic
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int PostId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Post Post { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
