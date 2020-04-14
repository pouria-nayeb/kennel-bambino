using kennel_bambino.web.Interfaces;
using kennel_bambino.web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Messages
{
    public class IndexModel : PageModel
    {
        private readonly IMessageService _messageService;

        // step 1: create a constructor
        public IndexModel(IMessageService messageService)
        {
            // step 2: inject message service
            _messageService = messageService;
        }

        // step 3: strong-binding
        public ContactPagingViewModel ContactPagingVM { get; private set; }

        public int ContactsCount { get; private set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 24)
        {
            // step 4: feed ContactPagingVM and ContactsCount
            ContactPagingVM = await _messageService.GetContactsAsync(pageNumber, pageSize);
            ContactsCount = await _messageService.ContactsCountAsync();
        }
    }
}