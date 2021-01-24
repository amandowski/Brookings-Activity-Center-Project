using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACWebsite.Models
{
    public partial class Employee : IdentityUser
    {
        public Employee()
        {
            SecurityQuestions = new HashSet<SecurityQuestions>();
        }

        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public int JobTitleId { get; set; }
        [PersonalData]
        public DateTime Birthday { get; set; }
        [PersonalData]
        public string Address { get; set; }

        public virtual JobTitle JobTitle { get; set; }
        public virtual ICollection<SecurityQuestions> SecurityQuestions { get; set; }
    }
}
