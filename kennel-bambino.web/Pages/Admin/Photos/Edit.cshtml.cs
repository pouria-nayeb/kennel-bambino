using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Photos
{
    public class EditModel : PageModel
    {

        private readonly IPhotoService _photoService;
        private readonly ILogger<EditModel> _logger;

        // step 1: create a constructor
        public EditModel(IPhotoService photoService,
            ILogger<EditModel> logger)
        {
            // step 2: inject message service
            _photoService = photoService;
            _logger = logger;
        }

        [BindProperty]
        public Photo Photo { get; set; }

        public SelectList PetsSelectListItem { get; set; }

        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Photo = await _photoService.GetPhotoByIdAsync(id.Value);

            PetsSelectListItem = new SelectList(await _photoService.GetPetSelectListItemAsync(), "Value", "Text");

            if (Photo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (await _photoService.UpdatePhotoAsync(Photo, Image) != null)
                {
                    // success
                    TempData["Success"] = "Photo successfully updated.";

                    return RedirectToPage("Index");
                }
                else 
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Photo {nameof(EditModel)} database error.");

                    return Page();
                }
            }

            // wrong inputs
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Photo {nameof(EditModel)} database error.");

            return Page();
        }
    }
}