using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EduTech.Models;

namespace EduTech.Pages.Manager.Skills
{
    public class DetailsModel : PageModel
    {
        private readonly EduTech.Models.EduTechContext _context;

        public DetailsModel(EduTech.Models.EduTechContext context)
        {
            _context = context;
        }

      public Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FirstOrDefaultAsync(m => m.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }
            else 
            {
                Skill = skill;
            }
            return Page();
        }
    }
}
