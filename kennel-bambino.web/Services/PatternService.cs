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
    public class PatternService : IPatternService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PatternService> _logger;

        public PatternService(ApplicationDbContext context, ILogger<PatternService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Add new pattern to database.
        /// </summary>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        #region Add new Pattern
        public Pattern AddPattern(Pattern pattern)
        {
            try
            {
                _context.Patterns.Add(pattern);
                _context.SaveChanges();


                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Pattern> AddPatternAsync(Pattern pattern)
        {
            try
            {
                await _context.Patterns.AddAsync(pattern);
                await _context.SaveChangesAsync();


                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Get all patterns and subPatterns.
        /// </summary>
        /// <returns></returns>
        #region Get all Patterns
        public List<Pattern> GetPatterns() => _context.Patterns.ToList();

        public async Task<List<Pattern>> GetPatternsAsync() => await _context.Patterns.ToListAsync();
        #endregion

        #region Get pattern selectlist
        public List<SelectListItem> GetPatternSelectList() => _context.Patterns.Select(p => new SelectListItem
        {
            Text = p.Name,
             Value = p.PatternId.ToString()
        }).ToList();

        public async Task<List<SelectListItem>> GetPatternSelectListAsync() => await _context.Patterns.Select(p => new SelectListItem
        {
            Text = p.Name,
            Value = p.PatternId.ToString()
        }).ToListAsync();
        #endregion

        /// <summary>
        /// Get pattern by id from database.
        /// </summary>
        /// <param name="PatternId"></param>
        /// <returns></returns>
        #region Get Pattern by id
        public Pattern GetPatternById(int patternId) => _context.Patterns
            .SingleOrDefault(g => g.PatternId == patternId);

        public async Task<Pattern> GetPatternByIdAsync(int patternId) => await _context.Patterns
            .SingleOrDefaultAsync(g => g.PatternId == patternId);
        #endregion

        /// <summary>
        /// Update the pattern's data from database.
        /// </summary>
        /// <param name="Pattern"></param>
        /// <returns></returns>
        #region Update Pattern
        public Pattern UpdatePattern(Pattern pattern)
        {
            try
            {
                _context.Patterns.Update(pattern);
                _context.SaveChanges();


                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Pattern> UpdatePatternAsync(Pattern pattern)
        {
            try
            {
                _context.Patterns.Update(pattern);
                await _context.SaveChangesAsync();


                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove the pattern from database.
        /// </summary>
        /// <param name="patternId"></param>
        #region Remove Pattern
        public void RemovePattern(int patternId)
        {
            var Pattern = GetPatternById(patternId);

            _context.Patterns.Remove(Pattern);
            _context.SaveChanges();
        }

        public async Task RemovePatternAsync(int patternId)
        {
            var Pattern = await GetPatternByIdAsync(patternId);

            _context.Patterns.Remove(Pattern);
            await _context.SaveChangesAsync();
        }
        #endregion

        /// <summary>
        /// Patterns count.
        /// </summary>
        /// <returns></returns>
        #region PatternsCount
        public int PatternCount() => _context.Patterns.Count();

        public async Task<int> PatternCountAsync() => await _context.Patterns.CountAsync();
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
