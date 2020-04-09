using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.EyeColors
{
    public class DeleteModel : PageModel
    {
        private readonly IEyeColorService _eyeColorService;

        // step 1: add constuctor
        public DeleteModel(IEyeColorService eyeColorService)
        {
            // step 2: inject ieyecolor servive
            _eyeColorService = eyeColorService;
        }

        // step 3: create eyecolor property
        [BindProperty]
        public EyeColor EyeColor { get; set; }

        // step 4: get eyecolor by id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EyeColor = await _eyeColorService.GetEyeColorByIdAsync(id.Value);

            if (EyeColor == null)
            {
                return BadRequest();
            }

            return Page();
        }

        // step 5: remove eyecolor.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // success
            TempData["Success"] = "EyeColor successfully removed.";
            await _eyeColorService.RemoveEyeColorAsync(id);

            return RedirectToPage("Index");
        }
    }
}