using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.BodyTypes
{
    public class IndexModel : PageModel
    {
        private readonly IBodyTypeService _bodyTypeService;

        // step 1: add constuctor
        public IndexModel(IBodyTypeService bodyTypeService)
        {
            // step 2: inject ibodytype servive
            _bodyTypeService = bodyTypeService;
        }

        // step 3: create property
        public List<BodyType> BodyTypes { get; private set; }
        public int BodyTypesCount { get; set; }

        public async Task OnGet()
        {
            // step 4: feed BodyTypes property with data in database.
            BodyTypes = await _bodyTypeService.GetAllBodyTypesAsync();
            BodyTypesCount = await _bodyTypeService.BodyTypesCountAsync();
        }
    }
}
