using kennel_bambino.web.Data;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
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
        /// Add new Pattern or subPattern to database.
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
        /// Get all Patterns and subPatterns.
        /// </summary>
        /// <returns></returns>
        #region Get all Patterns
        public IEnumerable<Pattern> GetAllPatterns() => _context.Patterns.ToList();

        public async Task<IEnumerable<Pattern>> GetAllPatternsAsync() => await _context.Patterns.ToListAsync();
        #endregion

        /// <summary>
        /// Get Pattern by id from database.
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
        /// Update the Pattern's data from database.
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
        /// Remove the Pattern from database.
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
    }
}
