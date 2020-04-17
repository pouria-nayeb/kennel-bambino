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
    public class EditModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IEyeColorService _eyeColorService;
        private readonly IPatternService _patternService;
        private readonly IGroupService _groupService;
        private readonly ILogger<EditModel> _logger;

        // step 1: add constuctor
        public EditModel(IPetService petService,
            IBodyTypeService bodyTypeService,
            IEyeColorService eyeColorService,
            IPatternService patternService,
            IGroupService groupService,
            ILogger<EditModel> logger)
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

        public SelectList SubGroupSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Pet = await _petService.GetPetByIdAsync(id.Value);

            await SeedInitialValues(Pet.BodyTypeId, Pet.EyeColorId, Pet.PatternId, Pet.GroupId, Pet.SubGroupId.Value);

            if (Pet == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Pet.RegisterDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                // admin inputs is valid
                if (await _petService.UpdatePetAsync(Pet, Images) != null)
                {
                    // success
                    TempData["Success"] = "Pet successfully updated.";
                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Pet {nameof(CreateModel)} database error.");

                    await SeedInitialValues(Pet.BodyTypeId, Pet.EyeColorId, Pet.PatternId, Pet.GroupId, Pet.SubGroupId.Value);

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Pet {nameof(CreateModel)} invalid inputs.");

            await SeedInitialValues(Pet.BodyTypeId, Pet.EyeColorId, Pet.PatternId, Pet.GroupId, Pet.SubGroupId.Value);

            return Page();
        }

        private async Task SeedInitialValues(int bodyTypeId, int eyeColorId, int patternId, int groupId, int subgroupId)
        {
            BodyTypeSelectList = new SelectList(await _bodyTypeService.GetBodyTypeSelectListAsync(), "Value", "Text", bodyTypeId);
            EyeColorSelectList = new SelectList(await _eyeColorService.GetEyeColorSelectListAsync(), "Value", "Text", eyeColorId);
            PatternSelectList = new SelectList(await _patternService.GetPatternSelectListAsync(), "Value", "Text", patternId);
            GroupSelectList = new SelectList(await _groupService.GetGroupSelectListAsync(), "Value", "Text", groupId);
            SubGroupSelectList = new SelectList(_groupService.GetSubGroupSelectList(groupId), "Value", "Text", subgroupId);
        }
    }
}