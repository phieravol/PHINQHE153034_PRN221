using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class JobsUser
    {
        public string? Username { get; set; }
        public int? JobId { get; set; }
        public string? JobsExperience { get; set; }

        public virtual Job? Job { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
