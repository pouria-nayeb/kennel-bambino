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
    public class EditModel : PageModel
    {
        private readonly IBodyTypeService _bodyTypeService;

        // step 1: add constuctor
        public EditModel(IBodyTypeService bodyTypeService)
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

        // step 5: update bodytype details
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _bodyTypeService.UpdateBodyTypeAsync(BodyType) != null)
                {
                    // success
                    TempData["Success"] = "BodyType successfully updated.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            return Page();
        }
    }
}