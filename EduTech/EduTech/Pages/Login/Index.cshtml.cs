using EduTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduTech.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly EduTechContext eduContext;

        public User User { get; set; }

        public IndexModel(EduTechContext eduContext)
        {
            this.eduContext= eduContext;
        }
        public void OnGet()
        {
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    using (EduTechContext eduContext = new EduTechContext())
        //    {

        //    }
        //}
    }
}
