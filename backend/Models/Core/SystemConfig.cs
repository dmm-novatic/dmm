using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class SystemConfig
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }


        public SystemConfig() { }
        public SystemConfig(int id, int active, string name, string code, string description)
        {
            Id = id;
            Active = active;
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
