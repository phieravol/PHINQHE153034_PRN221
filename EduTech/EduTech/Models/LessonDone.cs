using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class LessonDone
    {
        public int LessonId { get; set; }
        public string? Username { get; set; }
        public string? CourseCode { get; set; }

        public virtual Course? CourseCodeNavigation { get; set; }
        public virtual Lesson Lesson { get; set; } = null!;
        public virtual User? UsernameNavigation { get; set; }
    }
}
