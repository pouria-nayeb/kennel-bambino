using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kennel_bambino.web.Pages.Admin.BodyTypes
{
    public class DeleteModel : PageModel
    {
        private readonly IBodyTypeService _bodyTypeService;

        // step 1: add constuctor
        public DeleteModel(IBodyTypeService bodyTypeService)
        {
            // step 2: inject ibodytype servive
            _bodyTypeService = bodyTypeService;
        }

        // step 3: create bodytype property
        [BindProperty]
        public BodyType BodyType { get; set; }

        // step 4: get bodytype by id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BodyType = await _bodyTypeService.GetBodyTypeByIdAsync(id.Value);

            if (BodyType == null)
            {
                return BadRequest();
            }

            return Page();
        }

        // step 5: remove bodytype.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            // success
            TempData["Success"] = "BodyType successfully removed.";
            await _bodyTypeService.RemoveBodyTypeAsync(id);

            return RedirectToPage("Index");
        }
    }
}