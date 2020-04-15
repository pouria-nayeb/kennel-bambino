using kennel_bambino.web.Data;
using kennel_bambino.web.Helpers;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Services
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GroupService> _logger;

        public GroupService(ApplicationDbContext context, ILogger<GroupService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Add new group or subgroup to database.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        #region Add new group
        public Group AddGroup(Group group, IFormFile imageFile)
        {
            try
            {
                group.ImageName = imageFile.UploadPhoto();

                _context.Groups.Add(group);
                _context.SaveChanges();


                return group;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Group> AddGroupAsync(Group group, IFormFile imageFile)
        {
            try
            {
                group.ImageName = imageFile.UploadPhoto();

                await _context.Groups.AddAsync(group);
                await _context.SaveChangesAsync();


                return group;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Get all groups and subgroups.
        /// </summary>
        /// <returns></returns>
        #region Get all groups
        public IEnumerable<Group> GetAllGroups() => _context.Groups.ToList();

        public async Task<IEnumerable<Group>> GetAllGroupsAsync() => await _context.Groups.ToListAsync();
        #endregion

        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <returns></returns>
        #region Get groups
        public IEnumerable<Group> GetGroups() => _context.Groups.Where(g => g.ParentId == null).ToList();

        public async Task<IEnumerable<Group>> GetGroupsAsync() => await _context.Groups
            .Where(g => g.ParentId == null)
            .ToListAsync();
        #endregion

        #region Get groups selectlist
        public List<SelectListItem> GetGroupSelectList() => _context.Groups
            .Where(g => g.ParentId == null)
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.GroupId.ToString()
            }).ToList();

        public async Task<List<SelectListItem>> GetGroupSelectListAsync() => await _context.Groups
            .Where(g => g.ParentId == null)
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.GroupId.ToString()
            }).ToListAsync();
        #endregion

        /// <summary>
        /// Get all subgroups.
        /// </summary>
        /// <returns></returns>
        #region Get subgroups
        public IEnumerable<Group> GetSubGroups() => _context.Groups
            .Where(g => g.ParentId != null).ToList();

        public async Task<IEnumerable<Group>> GetSubGroupsAsync() => await _context.Groups
            .Where(g => g.ParentId != null).ToListAsync();
        #endregion

        #region Get subgroups selectlist
        public List<SelectListItem> GetSubGroupSelectList(int groupId) => _context.Groups
            .Where(g => g.ParentId == groupId)
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.GroupId.ToString()
            }).ToList();

        public async Task<List<SelectListItem>> GetSubGroupSelectListAsync(int groupId) => await _context.Groups
            .Where(g => g.ParentId == groupId)
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.GroupId.ToString()
            }).ToListAsync();
        #endregion

        /// <summary>
        /// Get group by id from database.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        #region Get group by id
        public Group GetGroupById(int groupId) => _context.Groups
            .AsNoTracking()
            .SingleOrDefault(g => g.GroupId == groupId);

        public async Task<Group> GetGroupByIdAsync(int groupId) => await _context.Groups
            .AsNoTracking()
            .SingleOrDefaultAsync(g => g.GroupId == groupId);
        #endregion

        /// <summary>
        /// Update the group's data from database.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        #region Update group
        public Group UpdateGroup(Group group, IFormFile imageFile)
        {
            try
            {
                group.ImageName = imageFile.UpdateUploadedGroupPhoto(group);

                _context.Groups.Update(group);
                _context.SaveChanges();


                return group;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Group> UpdateGroupAsync(Group group, IFormFile imageFile)
        {
            try
            {
                group.ImageName = imageFile.UpdateUploadedGroupPhoto(group);

                _context.Groups.Update(group);
                await _context.SaveChangesAsync();


                return group;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove the group from database.
        /// </summary>
        /// <param name="groupId"></param>
        #region Remove group
        public void RemoveGroup(int groupId)
        {
            var group = GetGroupById(groupId);

            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public async Task RemoveGroupAsync(int groupId)
        {
            var group = await GetGroupByIdAsync(groupId);

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
        #endregion


        #region Groups count
        public int GroupCount() => _context.Groups.Count();

        public async Task<int> GroupCountAsync() => await _context.Groups.CountAsync();
        #endregion
    }
}
