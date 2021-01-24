using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACWebsite.Models
{
    public interface IJobTitleRepository
    {
        IEnumerable<JobTitle> AllJobs { get; }
    }
}
