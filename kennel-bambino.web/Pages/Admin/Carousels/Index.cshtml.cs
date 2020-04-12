using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Carousels
{
    public class IndexModel : PageModel
    {
        private readonly ICarouselService _carouselService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ICarouselService carouselService,
            ILogger<IndexModel> logger)
        {
            _carouselService = carouselService;
            _logger = logger;
        }

        public IEnumerable<Carousel> Carousels { get; private set; }
        public int CarouselsCount { get; private set; }

        public async Task OnGet()
        {
            Carousels = await _carouselService.GetCarouselsAsync();
            CarouselsCount = await _carouselService.CarouselsCountAsync();
        }
    }
}