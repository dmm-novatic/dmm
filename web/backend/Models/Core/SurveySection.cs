using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class SurveySection
    {
        public SurveySection()
        {
            InverseSurveySectionNavigation = new HashSet<SurveySection>();
            SurveySectionQuestion = new HashSet<SurveySectionQuestion>();
            Recomment = new HashSet<Recomment>();

        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int? SurveySectionId { get; set; }
        public int Active { get; set; }
        public double ProportionScore { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public string Text2 { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual SurveySection SurveySectionNavigation { get; set; }
        public virtual ICollection<SurveySection> InverseSurveySectionNavigation { get; set; }
        public virtual ICollection<SurveySectionQuestion> SurveySectionQuestion { get; set; }
        public virtual ICollection<Recomment> Recomment { get; set; }

    }
}
