using BACWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACWebsite.ViewModels
{
    public class JobTitleViewModel
    {
        public IEnumerable<JobTitle> Jobs { get; set; }
    }
}
