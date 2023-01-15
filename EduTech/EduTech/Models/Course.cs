using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
        }

        public string CourseCode { get; set; } = null!;
        public string? CourseTitle { get; set; }
        public bool? IsPublic { get; set; }
        public int? TotalLesson { get; set; }
        public double? Duration { get; set; }
        public string? Description { get; set; }
        public string? CourseTarget { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
