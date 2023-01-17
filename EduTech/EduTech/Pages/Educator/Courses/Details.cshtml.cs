using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduTech.Models;

namespace EduTech.Pages.Educator.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly EduTech.Models.EduTechContext _context;

        public DetailsModel(EduTech.Models.EduTechContext context)
        {
            _context = context;
        }

      public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseCode == id);
            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }
            return Page();
        }
    }
}
