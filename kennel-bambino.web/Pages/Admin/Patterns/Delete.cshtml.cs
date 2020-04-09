using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Patterns
{
    public class DeleteModel : PageModel
    {
        private readonly IPatternService _patternService;

        // step 1: add constuctor
        public DeleteModel(IPatternService patternService)
        {
            // step 2: inject ipattern servive
            _patternService = patternService;
        }

        // step 3: create pattern property
        [BindProperty]
        public Pattern Pattern { get; set; }

        // step 4: get pattern by id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pattern = await _patternService.GetPatternByIdAsync(id.Value);

            if (Pattern == null)
            {
                return BadRequest();
            }

            return Page();
        }

        // step 5: remove pattern.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // success
            TempData["Success"] = "Pattern successfully removed.";
            await _patternService.RemovePatternAsync(id);

            return RedirectToPage("Index");
        }
    }
}