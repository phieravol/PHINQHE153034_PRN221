using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class SkillCourse
    {
        public int SkillId { get; set; }
        public string? CourseCode { get; set; }

        public virtual Course? CourseCodeNavigation { get; set; }
        public virtual Skill Skill { get; set; } = null!;
    }
}
