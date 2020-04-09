using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Patterns
{
    public class IndexModel : PageModel
    {
        private readonly IPatternService _patternService;

        // step 1: add constuctor
        public IndexModel(IPatternService patternService)
        {
            // step 2: inject ipattern servive
            _patternService = patternService;
        }

        // step 3: create property
        public List<Pattern> Patterns { get; private set; }
        public int PatternsCount { get; set; }

        public async Task OnGet()
        {
            // step 4: feed Patterns property with data in database.
            Patterns = await _patternService.GetPatternsAsync();
            PatternsCount = await _patternService.PatternCountAsync();
        }
    }
}
