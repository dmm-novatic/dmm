using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2F.ViewModel
{
    public class SurveySectionAccountDetailViewModel
    {  
        // SurveySectionAccountDetail
        public int Id { get; set; }
        public int Active { get; set; }
        public int SurveySectionAccount { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }

        // SurveySectionAccount
        public int IdSurveySection { get; set; }
        public int SurveyAccountId { get; set; }
        public double ScoreSurveySection { get; set; }
        public string NameSurveySection { get; set; }
        public string DescriptionSurveySection { get; set; }

        // SurveyAccount
        public int IdSurveyAccount { get; set; }
        public int AccountId { get; set; }
        public int SurveyId { get; set; }
        public int ScoreSurveyAccount { get; set; }
        public string NameSurveyAccount { get; set; }
        public string DescriptionSurveyAccount { get; set; }
        public string Text { get; set; }

    }
}
