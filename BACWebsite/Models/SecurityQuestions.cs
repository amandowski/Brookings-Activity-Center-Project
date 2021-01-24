using System;
using System.Collections.Generic;

namespace BACWebsite.Models
{
    public partial class SecurityQuestions
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int? Question1 { get; set; }
        public string Answer1 { get; set; }
        public int? Question2 { get; set; }
        public string Answer2 { get; set; }
        public bool? IsCurrent { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual SecurityQuestionsOptions Question1Navigation { get; set; }
        public virtual SecurityQuestionsOptions Question2Navigation { get; set; }
    }
}
