using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.BodyTypes
{
    public class EditModel : PageModel
    {
        private readonly IBodyTypeService _bodyTypeService;
        private readonly ILogger<EditModel> _logger;

        // step 1: add constuctor
        public EditModel(IBodyTypeService bodyTypeService, ILogger<EditModel> logger)
        {
            // step 2: inject ibodytype servive
            _bodyTypeService = bodyTypeService;
            _logger = logger;
        }

        // step 3: create bodytype property
        [BindProperty]
        public BodyType BodyType { get; set; }

        // step 4: get bodytype by id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            BodyType = await _bodyTypeService.GetBodyTypeByIdAsync(id.Value);

            if (BodyType == null)
            {
                return NotFound();
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

                    _logger.LogError($"BodyType {nameof(EditModel)} database error.");

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"BodyType {nameof(EditModel)} invalid inputs.");

            return Page();
        }
    }
}