using kennel_bambino.web.Interfaces;
using kennel_bambino.web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Photos
{
    public class IndexModel : PageModel
    {
        private readonly IPhotoService _photoService;

        // step 1: create a constructor
        public IndexModel(IPhotoService photoService)
        {
            // step 2: inject photo service
            _photoService = photoService;
        }

        // step 3: strong-binding
        public PhotoPagingViewModel PhotoPagingVM { get; set; }

        public int PhotosCount { get; set; }


        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 32)
        {
            // step 4: feed PhotoPagingVM and PhotosCount
            PhotoPagingVM = await _photoService.GetPhotosAsync(pageNumber, pageSize);
            PhotosCount = await _photoService.PhotosCountAsync();
        }
    }
}