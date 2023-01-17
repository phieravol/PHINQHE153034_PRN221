using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduTech.Models;

namespace EduTech.Pages.Manager.Skills
{
    public class EditModel : PageModel
    {
        private readonly EduTech.Models.EduTechContext _context;

        public EditModel(EduTech.Models.EduTechContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Skill Skill { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill =  await _context.Skills.FirstOrDefaultAsync(m => m.SkillId == id);
            if (skill == null)
            {
                return NotFound();
            }
            Skill = skill;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(Skill.SkillId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SkillExists(int id)
        {
          return _context.Skills.Any(e => e.SkillId == id);
        }
    }
}
