using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Pages.Admin.Groups
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;

        public IndexModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IEnumerable<Group> Groups { get; private set; }

        public IEnumerable<Group> SubGroups { get; private set; }

        public int GroupsCount { get; private set; }

        public async Task OnGet()
        {
            Groups = await _groupService.GetGroupsAsync();

            SubGroups = await _groupService.GetSubGroupsAsync();

            GroupsCount = await _groupService.GroupCountAsync();
        }
    }
}