using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class FavouritePost
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Account Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
