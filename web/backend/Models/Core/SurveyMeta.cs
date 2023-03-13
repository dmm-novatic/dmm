using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class SurveyMeta
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
