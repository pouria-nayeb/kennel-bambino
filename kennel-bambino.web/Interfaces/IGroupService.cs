using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IGroupService
    {
        #region Add new group
        Group AddGroup(Group group, IFormFile imageFile);
        Task<Group> AddGroupAsync(Group group, IFormFile imageFile);
        #endregion

        #region Get all groups (groups + subgroups)
        IEnumerable<Group> GetAllGroups();
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        #endregion

        #region Get groups (groups)
        IEnumerable<Group> GetGroups();
        Task<IEnumerable<Group>> GetGroupsAsync();
        #endregion

        #region Get subgroups (subgroups)
        IEnumerable<Group> GetSubGroups();
        Task<IEnumerable<Group>> GetSubGroupsAsync();
        #endregion

        #region Get group by id
        Group GetGroupById(int groupId);
        Task<Group> GetGroupByIdAsync(int groupId);
        #endregion

        #region Update group
        Group UpdateGroup(Group group, IFormFile imageFile);
        Task<Group> UpdateGroupAsync(Group group, IFormFile imageFile);
        #endregion

        #region Remove group
        void RemoveGroup(int groupId);
        Task RemoveGroupAsync(int groupId);
        #endregion
    }
}
