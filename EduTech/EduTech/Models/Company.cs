using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyAttributes = new HashSet<CompanyAttribute>();
            Jobs = new HashSet<Job>();
        }

        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }

        public virtual ICollection<CompanyAttribute> CompanyAttributes { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
