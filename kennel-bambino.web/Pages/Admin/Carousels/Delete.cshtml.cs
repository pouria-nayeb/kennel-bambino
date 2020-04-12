using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Carousels
{
    public class DeleteModel : PageModel
    {
        private readonly ICarouselService _carouselService;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(ICarouselService carouselService,
            ILogger<DeleteModel> logger)
        {
            _carouselService = carouselService;
            _logger = logger;
        }

        public Carousel Carousel { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int id) 
        {
            TempData["Success"] = "Carousel successfully removed.";
            await _carouselService.RemoveCarouselAsync(id);

            return RedirectToPage("Index");
        }

    }
}