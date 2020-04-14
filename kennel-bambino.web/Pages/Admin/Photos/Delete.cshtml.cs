using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Photos
{
    public class DeleteModel : PageModel
    {
        private readonly IPhotoService _photoService;

        public DeleteModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public Photo Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Photo = await _photoService.GetPhotoByIdAsync(id.Value);

            if (Photo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            TempData["Success"] = "Photo successfully removed.";
            await _photoService.RemovePhotoAsync(id);

            return RedirectToPage("Index");
        }
    }
}