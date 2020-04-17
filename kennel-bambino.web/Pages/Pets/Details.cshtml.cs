using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kennel_bambino.web.Pages.Pets
{
    public class DetailsModel : PageModel
    {
        private readonly IPetService _petService;

        public DetailsModel(IPetService petService)
        {
            _petService = petService;
        }

        public Pet Pet { get; private set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Pet = await _petService.GetPetByIdAsync(id.Value);

            if (Pet == null)
            {
                return BadRequest();
            }

            return Page();
        }
    }
}