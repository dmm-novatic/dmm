using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.ViewModel
{
    public class SurveySectionViewModel
    {
        //SurveySection
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
        //Question
        public int IdQuestion { get; set; }
        public int? QuestionTypeId { get; set; }
        public int ActiveQuestion { get; set; }
        public string PhotoQuestion { get; set; }
        public double ScoreQuestion { get; set; }
        public string NameQuestion { get; set; }
        public string DescriptionQuestion { get; set; }
        public string TextQuestion { get; set; }
        public string Name2Question { get; set; }
        public string Description2Question { get; set; }
        public string Text2Question { get; set; }
        public DateTime CreatedTimeQuestion { get; set; }

    }
}
