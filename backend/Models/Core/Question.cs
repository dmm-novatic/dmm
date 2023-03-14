using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            SurveySectionAccountDetailAnswer = new HashSet<SurveySectionAccountDetail>();
            SurveySectionAccountDetailQuestion = new HashSet<SurveySectionAccountDetail>();
            SurveySectionQuestion = new HashSet<SurveySectionQuestion>();
        }

        public int Id { get; set; }
        public int? QuestionTypeId { get; set; }
        public int Active { get; set; }
        public string Photo { get; set; }
        public double Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public string Text2 { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<SurveySectionAccountDetail> SurveySectionAccountDetailAnswer { get; set; }
        public virtual ICollection<SurveySectionAccountDetail> SurveySectionAccountDetailQuestion { get; set; }
        public virtual ICollection<SurveySectionQuestion> SurveySectionQuestion { get; set; }
    }
}
