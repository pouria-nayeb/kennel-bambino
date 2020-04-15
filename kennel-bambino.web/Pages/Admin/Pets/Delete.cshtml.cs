using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kennel_bambino.web.Pages.Admin.Pets
{
    public class DeleteModel : PageModel
    {
        private readonly IPetService _petService;

        public DeleteModel(IPetService petService)
        {
            _petService = petService;
        }

        public Pet Pet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }

            Pet = await _petService.GetPetByIdAsync(id.Value);

            if (Pet == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) 
        {
            TempData["Success"] = "Pet successfully removed.";
            await _petService.RemovePetAsync(id);

            return RedirectToPage("Index");
        }
    }
}