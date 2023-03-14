using System;
using System.Collections.Generic;

namespace Novatic.Models
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Active { get; set; }
        public double Score { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual Question Question { get; set; }
    }
}
