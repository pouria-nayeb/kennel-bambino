using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kennel_bambino.web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IMessageService _messageService;

        public ContactModel(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Contact.SubmitDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (await _messageService.AddContactAsync(Contact) != null)
                {
                    TempData["Success"] = "Your message sent successfully.";

                    return RedirectToPage("Contact");
                }
                else 
                {
                    ViewData["Message"] = "Database error, please report this issue to our admin.";

                    return Page();
                }
            }
            ViewData["Message"] = "Invalid inputs, please fill all the fields.";

            return Page();
        }
    }
}