using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace kennel_bambino.web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IPetService petService,
            ILogger<IndexModel> logger)
        {
            _petService = petService;
            _logger = logger;
        }

        public List<Pet> Pets { get; private set; }

        public async Task OnGetAsync()
        {
            Pets = await _petService.LatestPetsAsync();
            var date = DateTime.Now;
        }
    }
}
