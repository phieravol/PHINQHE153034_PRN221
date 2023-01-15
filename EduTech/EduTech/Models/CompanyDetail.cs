using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class CompanyDetail
    {
        public CompanyDetail()
        {
            CompanyAttributes = new HashSet<CompanyAttribute>();
        }

        public int CompanyDetailsId { get; set; }
        public string? DetailsValue { get; set; }

        public virtual ICollection<CompanyAttribute> CompanyAttributes { get; set; }
    }
}
