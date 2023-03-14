using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.ViewModel
{
    public class PostTopicViewModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int PostId { get; set; }
        public string PostName { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
