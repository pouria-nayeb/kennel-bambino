using kennel_bambino.web.Interfaces;
using kennel_bambino.web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly IPetService _petService;

        public IndexModel(IPetService petService)
        {
            _petService = petService;
        }

        public PetPagingViewModel PetPagingVM { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 12)
        {
            PetPagingVM = await _petService.GetAllPetsAsync(pageNumber, pageSize);
        }
    }
}