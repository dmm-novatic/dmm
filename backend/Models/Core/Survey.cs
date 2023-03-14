using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Survey
    {
        public Survey()
        {
            SurveyAccount = new HashSet<SurveyAccount>();
            SurveyMeta = new HashSet<SurveyMeta>();
            SurveySection = new HashSet<SurveySection>();
        }

        public int Id { get; set; }
        public int SurveyTypeId { get; set; }
        public string GuId { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public int? ViewCount { get; set; }
        public int? CommentCount { get; set; }
        public int? LikeCount { get; set; }
        public int Active { get; set; }
        public string Url { get; set; }
        public string Url2 { get; set; }
        public double Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public string Text2 { get; set; }
        public DateTime? PublishedTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual SurveyType SurveyType { get; set; }
        public virtual ICollection<SurveyAccount> SurveyAccount { get; set; }
        public virtual ICollection<SurveyMeta> SurveyMeta { get; set; }
        public virtual ICollection<SurveySection> SurveySection { get; set; }
    }
}
