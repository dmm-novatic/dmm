using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class SurveySectionAccount
    {
        public int Id { get; set; }
        public int SurveyAccountId { get; set; }
        public int Active { get; set; }
        public double Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual SurveyAccount SurveyAccount { get; set; }
    }
}
