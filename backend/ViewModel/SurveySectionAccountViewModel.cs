using Novatic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.ViewModel
{
    public class SurveySectionAccountViewModel
    {
        public int Id { get; set; }
        public int SurveyAccountId { get; set; }
        public string SurveyAccountName { get; set; }
        public double SurveyAccountScore { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public int AccountId { get; set; }
        public string AccountUsername { get; set; }
        public DateTime CreatedTime { get; set; }
        public int Active { get; set; }
        public string Description { get; set; }
        public string ListRecomment { get; set; }
        [JsonIgnore]
        public virtual SurveyAccount SurveyAccount { get; set; }
    }
}
