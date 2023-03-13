using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novatic.ViewModel
{
    public class PostMetaViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string PostName { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string NameOfPostCategory { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
