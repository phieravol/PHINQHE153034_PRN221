using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class CompanyAttribute
    {
        public string AttributeCode { get; set; } = null!;
        public string? AttributeName { get; set; }
        public int? CompanyId { get; set; }
        public int? CompanyDetailsId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual CompanyDetail? CompanyDetails { get; set; }
    }
}
