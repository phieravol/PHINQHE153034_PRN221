using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class AuthorGroup
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
    }
}
