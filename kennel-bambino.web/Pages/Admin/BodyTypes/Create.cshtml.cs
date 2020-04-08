using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.BodyTypes
{
    public class CreateModel : PageModel
    {
        private readonly IBodyTypeService _bodyTypeService;

        // step 1: add constuctor
        public CreateModel(IBodyTypeService bodyTypeService)
        {
            // step 2: inject ibodytype servive
            _bodyTypeService = bodyTypeService;
        }

        // step 3: create bodytype property
        [BindProperty]
        public BodyType BodyType { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _bodyTypeService.AddBodyTypeAsync(BodyType) != null)
                {
                    // success
                    TempData["Success"] = "New BodyType successfully added.";
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