using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Patterns
{
    public class CreateModel : PageModel
    {
        private readonly IPatternService _patternService;
        private readonly ILogger<CreateModel> _logger;

        // step 1: add constuctor
        public CreateModel(IPatternService patternService, ILogger<CreateModel> logger)
        {
            // step 2: inject ipattern servive
            _patternService = patternService;
            _logger = logger;
        }

        // step 3: create pattern property
        [BindProperty]
        public Pattern Pattern { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _patternService.AddPatternAsync(Pattern) != null)
                {
                    // success
                    TempData["Success"] = "New Pattern successfully added.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Pattern {nameof(CreateModel)} database error.");

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Pattern {nameof(CreateModel)} invalid inputs.");

            return Page();
        }
    }
}