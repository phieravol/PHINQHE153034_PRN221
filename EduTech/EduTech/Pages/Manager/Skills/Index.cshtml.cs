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
    public class IndexModel : PageModel
    {
        private readonly EduTech.Models.EduTechContext _context;

        public IndexModel(EduTech.Models.EduTechContext context)
        {
            _context = context;
        }

        public IList<Skill> Skill { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Skills != null)
            {
                Skill = await _context.Skills.ToListAsync();
            }
        }
    }
}
