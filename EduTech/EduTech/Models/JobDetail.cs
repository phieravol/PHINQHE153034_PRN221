using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class JobDetail
    {
        public JobDetail()
        {
            JobAttributes = new HashSet<JobAttribute>();
        }

        public int JobDetailsId { get; set; }
        public string? JobDetailsValue { get; set; }

        public virtual ICollection<JobAttribute> JobAttributes { get; set; }
    }
}
