using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class UserSkill
    {
        public string? Username { get; set; }
        public int? SkillId { get; set; }
        public int? SkillLevel { get; set; }

        public virtual Skill? Skill { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
