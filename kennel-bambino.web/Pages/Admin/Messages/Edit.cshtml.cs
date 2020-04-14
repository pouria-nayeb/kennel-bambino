using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Messages
{
    public class EditModel : PageModel
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<EditModel> _logger;

        // step 1: create a constructor
        public EditModel(IMessageService messageService,
            ILogger<EditModel> logger)
        {
            // step 2: inject message service
            _messageService = messageService;
            _logger = logger;
        }

        // step 3: strong-binding
        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Contact = await _messageService.GetContactByIdAsync(id.Value);

            if (Contact == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (await _messageService.UpdateContactAsync(Contact) != null)
                {
                    // success
                    TempData["Success"] = "Message successfully updated.";

                    return RedirectToPage("Index");
                }
                else 
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Message {nameof(EditModel)} database error.");

                    return Page();
                }
            }

            // wrong inputs
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Message {nameof(EditModel)} database error.");

            return Page();
        }

    }
}