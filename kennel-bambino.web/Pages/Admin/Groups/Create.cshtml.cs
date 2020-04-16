using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Groups
{
    public class CreateModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(IGroupService groupService,
            ILogger<CreateModel> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [BindProperty]
        public Group Group { get; set; }

        public int? ParentId { get; private set; }

        public IFormFile Image { get; set; }

        public void OnGetAsync(int? id)
        {
            FeedParentId(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (await _groupService.AddGroupAsync(Group, Image) != null)
                {
                    TempData["Success"] = "New Group successfully added.";

                    return RedirectToPage("Index");
                }
                else 
                {
                    // db failure
                    ViewData["Message"] = "Database error, contact the developer to fix the error.";

                    _logger.LogError($"Pattern {nameof(CreateModel)} database error.");

                    FeedParentId(Group.ParentId);

                    return Page();
                }
            }

            // invalid inputs by admin
            ViewData["Message"] = "Your inputs is not valid.";

            _logger.LogError($"Pattern {nameof(CreateModel)} invalid inputs.");

            FeedParentId(Group.ParentId);

            return Page();
        }

        private void FeedParentId(int? parentId) 
        {
            ParentId = parentId;
        }
    }
}