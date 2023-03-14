using Newtonsoft.Json;
using System;

namespace Novatic.Models
{
    public class Recomment
    {
        public int Id { get; set; }
        public int SurveySectionId { get; set; }
        public int Active { get; set; }
        public double MinScore { get; set; }
        public double MaxScore { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public DateTime CreatedTime { get; set; }
        [JsonIgnore]
        public virtual SurveySection SurveySection { get; set; }
    }
}
