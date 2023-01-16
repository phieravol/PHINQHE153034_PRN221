using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EduTech.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
	{

		private readonly ILogger<PrivacyModel> _logger;

		public PrivacyModel(ILogger<PrivacyModel> logger)
		{
			_logger = logger;
		}

		[AllowAnonymous]
		public void OnGet()
		{
		}
	}
}