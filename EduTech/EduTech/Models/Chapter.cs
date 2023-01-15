using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int ChapterId { get; set; }
        public string? ChapterTitile { get; set; }
        public string? ChapterDescription { get; set; }
        public string? CourseCode { get; set; }

        public virtual Course? CourseCodeNavigation { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
