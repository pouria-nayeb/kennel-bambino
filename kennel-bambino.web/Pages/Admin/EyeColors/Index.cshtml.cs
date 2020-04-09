using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.EyeColors
{
    public class IndexModel : PageModel
    {
        private readonly IEyeColorService _eyeColorService;

        // step 1: add constuctor
        public IndexModel(IEyeColorService eyeColorService)
        {
            // step 2: inject eyecolor servive
            _eyeColorService = eyeColorService;
        }

        // step 3: create property
        public List<EyeColor> EyeColors { get; private set; }
        public int EyeColorsCount { get; set; }

        public async Task OnGet()
        {
            // step 4: feed EyeColors property with data in database.
            EyeColors = await _eyeColorService.GetEyeColorsAsync();
            EyeColorsCount = await _eyeColorService.EyeColorsCountAsync();
        }
    }
}
