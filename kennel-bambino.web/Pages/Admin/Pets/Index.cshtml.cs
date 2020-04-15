using kennel_bambino.web.Interfaces;
using kennel_bambino.web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Pets
{
    public class IndexModel : PageModel
    {
        private readonly IPetService _petService;

        public IndexModel(IPetService petService)
        {
            _petService = petService;
        }

        public PetPagingViewModel PetPagingVM { get; private set; }

        public int PetsCount { get; private set; }

        public async Task OnGet(int pageNumber = 1, int pageSize = 32)
        {
            PetPagingVM = await _petService.GetAllPetsAsync(pageNumber, pageSize);
            PetsCount = await _petService.PetsCountAsync();
        }
    }
}