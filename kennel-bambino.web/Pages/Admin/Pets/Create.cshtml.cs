using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Pets
{
    public class CreateModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IEyeColorService _eyeColorService;
        private readonly IPatternService _patternService;
        private readonly IGroupService _groupService;
        private readonly ILogger<CreateModel> _logger;

        // step 1: add constuctor
        public CreateModel(IPetService petService,
            IBodyTypeService bodyTypeService,
            IEyeColorService eyeColorService,
            IPatternService patternService,
            IGroupService groupService,
            ILogger<CreateModel> logger)
        {
            // step 2: inject ieyecolor servive
            _petService = petService;
            _bodyTypeService = bodyTypeService;
            _eyeColorService = eyeColorService;
            _patternService = patternService;
            _groupService = groupService;
            _logger = logger;
        }

        // step 3: create eyecolor property
        [BindProperty]
        public Pet Pet { get; set; }

        public List<IFormFile> Images { get; set; }

        public SelectList BodyTypeSelectList { get; set; }

        public SelectList EyeColorSelectList { get; set; }

        public SelectList PatternSelectList { get; set; }

        public SelectList GroupSelectList { get; set; }

        public async Task OnGetAsync()
        {
            await SeedInitialValues();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Pet.RegisterDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _petService.AddPetAsync(Pet, Images) != null)
                {
                    // success
                    TempData["Success"] = "New Pet successfully added.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Pet {nameof(CreateModel)} database error.");

                    await SeedInitialValues();

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Pet {nameof(CreateModel)} invalid inputs.");

            await SeedInitialValues();

            return Page();
        }

        private async Task SeedInitialValues() 
        {
            BodyTypeSelectList = new SelectList(await _bodyTypeService.GetBodyTypeSelectListAsync(), "Value", "Text");
            EyeColorSelectList = new SelectList(await _eyeColorService.GetEyeColorSelectListAsync(), "Value", "Text");
            PatternSelectList = new SelectList(await _patternService.GetPatternSelectListAsync(), "Value", "Text");
            GroupSelectList = new SelectList(await _groupService.GetGroupSelectListAsync(), "Value", "Text");
        }
    }
}