using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Carousels
{
    public class EditModel : PageModel
    {
        private readonly ICarouselService _carouselService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(ICarouselService carouselService,
            ILogger<EditModel> logger)
        {
            _carouselService = carouselService;
            _logger = logger;
        }

        [BindProperty]
        public Carousel Carousel { get; set; }

        public IFormFile Image { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Carousel = await _carouselService.GetCarouselByIdAsync(id.Value);

            if (Carousel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid

                if (await _carouselService.UpdateCarouselAsync(Carousel, Image) != null)
                {
                    // success
                    TempData["Success"] = "Carousel successfully updated.";

                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Carousel {nameof(CreateModel)} database error.");

                    return Page();
                }
            }

            // wrong inputs
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Carousel {nameof(CreateModel)} database error.");

            return Page();
        }
    }
}