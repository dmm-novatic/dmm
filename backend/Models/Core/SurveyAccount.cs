using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class SurveyAccount
    {
        public SurveyAccount()
        {
            SurveySectionAccount = new HashSet<SurveySectionAccount>();
            SurveySectionAccountDetail = new HashSet<SurveySectionAccountDetail>();
            Contact = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int SurveyId { get; set; }
        public int Active { get; set; }
        public double Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Name2 { get; set; }

        public virtual Account Account { get; set; }
        public virtual Survey Survey { get; set; }
        [JsonIgnore]
        public virtual ICollection<SurveySectionAccount> SurveySectionAccount { get; set; }
        [JsonIgnore]
        public virtual ICollection<SurveySectionAccountDetail> SurveySectionAccountDetail { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
    }
}
