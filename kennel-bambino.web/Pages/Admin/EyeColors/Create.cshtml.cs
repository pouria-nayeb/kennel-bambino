using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.EyeColors
{
    public class CreateModel : PageModel
    {
        private readonly IEyeColorService _eyeColorService;
        private readonly ILogger<CreateModel> _logger;

        // step 1: add constuctor
        public CreateModel(IEyeColorService eyeColorService, ILogger<CreateModel> logger)
        {
            // step 2: inject ieyecolor servive
            _eyeColorService = eyeColorService;
            _logger = logger;
        }

        // step 3: create eyecolor property
        [BindProperty]
        public EyeColor EyeColor { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _eyeColorService.AddEyeColorAsync(EyeColor) != null)
                {
                    // success
                    TempData["Success"] = "New EyeColor successfully added.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"EyeColor {nameof(CreateModel)} database error.");

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"EyeColor {nameof(CreateModel)} invalid inputs.");

            return Page();
        }
    }
}