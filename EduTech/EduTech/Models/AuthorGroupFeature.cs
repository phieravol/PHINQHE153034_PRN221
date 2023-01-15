using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class AuthorGroupFeature
    {
        public int GroupId { get; set; }
        public int? FeatureId { get; set; }

        public virtual Feature? Feature { get; set; }
        public virtual AuthorGroup Group { get; set; } = null!;
    }
}
