using kennel_bambino.web.Data;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Services
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BodyTypeService> _logger;

        public BodyTypeService(ApplicationDbContext context, ILogger<BodyTypeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Add new BodyType to database.
        /// </summary>
        /// <param name="bodyType"></param>
        /// <returns></returns>
        #region Add new BodyType
        public BodyType AddBodyType(BodyType bodyType)
        {
            try
            {
                _context.BodyTypes.Add(bodyType);
                _context.SaveChanges();


                return bodyType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<BodyType> AddBodyTypeAsync(BodyType bodyType)
        {
            try
            {
                await _context.BodyTypes.AddAsync(bodyType);
                await _context.SaveChangesAsync();


                return bodyType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Get all bodyTypes.
        /// </summary>
        /// <returns></returns>
        #region Get all BodyTypes
        public List<BodyType> GetBodyTypes() => _context.BodyTypes
            .OrderByDescending(bt => bt.BodyTypeId)
            .ToList();

        public async Task<List<BodyType>> GetBodyTypesAsync() => await _context.BodyTypes
            .OrderByDescending(bt => bt.BodyTypeId)
            .ToListAsync();
        #endregion

        /// <summary>
        /// Get bodytype select list items
        /// </summary>
        /// <returns></returns>
        #region BodyType selectlistitem
        public List<SelectListItem> GetBodyTypeSelectList() => _context.BodyTypes.Select(b => new SelectListItem
        {
            Text = b.Title,
            Value = b.BodyTypeId.ToString()
        }).ToList();

        public async Task<List<SelectListItem>> GetBodyTypeSelectListAsync() => await _context.BodyTypes.Select(b => new SelectListItem
        {
            Text = b.Title,
            Value = b.BodyTypeId.ToString()
        }).ToListAsync();
        #endregion

        /// <summary>
        /// Get bodyType by id from database.
        /// </summary>
        /// <param name="bodyTypeId"></param>
        /// <returns></returns>
        #region Get BodyType by id
        public BodyType GetBodyTypeById(int bodyTypeId) => _context.BodyTypes
                .SingleOrDefault(g => g.BodyTypeId == bodyTypeId);

        public async Task<BodyType> GetBodyTypeByIdAsync(int bodyTypeId) => await _context.BodyTypes
            .SingleOrDefaultAsync(g => g.BodyTypeId == bodyTypeId);
        #endregion

        /// <summary>
        /// Update the bodyType's data from database.
        /// </summary>
        /// <param name="bodyType"></param>
        /// <returns></returns>
        #region Update BodyType
        public BodyType UpdateBodyType(BodyType bodyType)
        {
            try
            {
                _context.BodyTypes.Update(bodyType);
                _context.SaveChanges();


                return bodyType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<BodyType> UpdateBodyTypeAsync(BodyType bodyType)
        {
            try
            {
                _context.BodyTypes.Update(bodyType);
                await _context.SaveChangesAsync();


                return bodyType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove the bodyType from database.
        /// </summary>
        /// <param name="bodyTypeId"></param>
        #region Remove BodyType
        public void RemoveBodyType(int bodyTypeId)
        {
            var bodyType = GetBodyTypeById(bodyTypeId);

            _context.BodyTypes.Remove(bodyType);
            _context.SaveChanges();
        }

        public async Task RemoveBodyTypeAsync(int bodyTypeId)
        {
            var bodyType = await GetBodyTypeByIdAsync(bodyTypeId);

            _context.BodyTypes.Remove(bodyType);
            await _context.SaveChangesAsync();
        }
        #endregion

        /// <summary>
        /// Count of bodytypes in database.
        /// </summary>
        /// <returns></returns>
        #region BodyTypes count
        public int BodyTypesCount() => _context.BodyTypes.Count();

        public async Task<int> BodyTypesCountAsync() => await _context.BodyTypes.CountAsync();
        #endregion


        #region Helpers
        public void Dispose() 
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
