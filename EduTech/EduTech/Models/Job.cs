using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class Job
    {
        public Job()
        {
            JobAttributes = new HashSet<JobAttribute>();
        }

        public int JobId { get; set; }
        public string? JobsTitle { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<JobAttribute> JobAttributes { get; set; }
    }
}
