using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Patterns
{
    public class EditModel : PageModel
    {
        private readonly IPatternService _patternService;
        private readonly ILogger<EditModel> _logger;

        // step 1: add constuctor
        public EditModel(IPatternService patternService, ILogger<EditModel> logger)
        {
            // step 2: inject ipattern servive
            _patternService = patternService;
            _logger = logger;
        }

        // step 3: create pattern property
        [BindProperty]
        public Pattern Pattern { get; set; }

        // step 4: get pattern by id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Pattern = await _patternService.GetPatternByIdAsync(id.Value);

            if (Pattern == null)
            {
                return NotFound();
            }

            return Page();
        }

        // step 5: update pattern details
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _patternService.UpdatePatternAsync(Pattern) != null)
                {
                    // success
                    TempData["Success"] = "Pattern successfully updated.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Pattern {nameof(EditModel)} database error.");

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Pattern {nameof(EditModel)} invalid inputs.");

            return Page();
        }
    }
}