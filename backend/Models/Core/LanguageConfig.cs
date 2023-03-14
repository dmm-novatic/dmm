using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class LanguageConfig
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }


        public LanguageConfig() { }
        public LanguageConfig(int id, int active, string name, string name2, string code)
        {
            Id = id;
            Active = active;
            Name = name;
            Name2 = name2;
            Code = code;
            Description = name;
            CreatedTime = DateTime.Now;
        }

        public string GetLanguage(string lang)
        {
            return Name;
        }
    }
}
