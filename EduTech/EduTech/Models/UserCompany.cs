using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class UserCompany
    {
        public string? Username { get; set; }
        public int? CompanyId { get; set; }
        public string? Position { get; set; }

        public virtual Company? Company { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
