using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.EyeColors
{
    public class EditModel : PageModel
    {
        private readonly IEyeColorService _eyeColorService;
        private readonly ILogger<EditModel> _logger;

        // step 1: add constuctor
        public EditModel(IEyeColorService eyeColorService, ILogger<EditModel> logger)
        {
            // step 2: inject ieyecolor servive
            _eyeColorService = eyeColorService;
            _logger = logger;
        }

        // step 3: create eyecolor property
        [BindProperty]
        public EyeColor EyeColor { get; set; }

        // step 4: get eyecolor by id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            EyeColor = await _eyeColorService.GetEyeColorByIdAsync(id.Value);

            if (EyeColor == null)
            {
                return NotFound();
            }

            return Page();
        }

        // step 5: update eyecolor details
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _eyeColorService.UpdateEyeColorAsync(EyeColor) != null)
                {
                    // success
                    TempData["Success"] = "EyeColor successfully updated.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"EyeColor {nameof(EditModel)} database error.");

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"EyeColor {nameof(EditModel)} invalid inputs.");

            return Page();
        }
    }
}