using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public string? LessonTitle { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsPublic { get; set; }
        public string? VideoUrl { get; set; }
        public string? LessonDetail { get; set; }
        public int? ChapterId { get; set; }

        public virtual Chapter? Chapter { get; set; }
    }
}
