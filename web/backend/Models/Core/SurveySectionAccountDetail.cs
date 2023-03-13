using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class SurveySectionAccountDetail
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public int SurveySectionAccount { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public double Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        [JsonIgnore]
        public virtual Question Answer { get; set; }
        [JsonIgnore]
        public virtual Question Question { get; set; }
        [JsonIgnore]
        public virtual SurveyAccount SurveySectionAccountNavigation { get; set; }
    }
}
