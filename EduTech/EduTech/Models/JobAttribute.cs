using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class JobAttribute
    {
        public string JobAttributeCode { get; set; } = null!;
        public string? JobAttributeName { get; set; }
        public int? JobId { get; set; }
        public int? JobDetailsId { get; set; }

        public virtual Job? Job { get; set; }
        public virtual JobDetail? JobDetails { get; set; }
    }
}
