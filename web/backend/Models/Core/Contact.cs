using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? SurveyAccountId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int Active { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual SurveyAccount SurveyAccount { get; set; }
    }
}
