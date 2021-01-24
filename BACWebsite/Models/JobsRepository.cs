using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACWebsite.Models
{
    public class JobsRepository : IJobTitleRepository
    {
        private readonly BACContext _appDbContext;

        public JobsRepository(BACContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<JobTitle> AllJobs
        {
            get
            {
                return _appDbContext.JobTitle;
            }
        }
    }
}
