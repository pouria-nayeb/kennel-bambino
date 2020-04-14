using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Messages
{
    public class DeleteModel : PageModel
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(IMessageService messageService,
            ILogger<DeleteModel> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            TempData["Success"] = "Message successfully removed.";
            await _messageService.RemoveContactAsync(id);

            return RedirectToPage("Index");
        }
    }
}