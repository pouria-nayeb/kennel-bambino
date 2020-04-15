using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Groups
{
    public class EditModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IGroupService groupService,
            ILogger<EditModel> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [BindProperty]
        public Group Group { get; set; }

        public int? ParentId { get; set; }

        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? parentId)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Group = await _groupService.GetGroupByIdAsync(id.Value);

            SeedParentId(parentId);

            if (Group == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // admin inputs is valid

                if (await _groupService.UpdateGroupAsync(Group, Image) != null)
                {
                    // success
                    TempData["Success"] = "Group successfully updated.";

                    return RedirectToPage("Index");
                }
                else
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Carousel {nameof(CreateModel)} database error.");

                    SeedParentId(Group.ParentId);

                    return Page();
                }
            }

            // wrong inputs
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Carousel {nameof(CreateModel)} database error.");

            SeedParentId(Group.ParentId);

            return Page();
        }

        private void SeedParentId(int? parentId) 
        {
            ParentId = parentId;
        }
    }
}