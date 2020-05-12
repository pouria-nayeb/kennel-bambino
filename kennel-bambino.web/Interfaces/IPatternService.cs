﻿using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IPatternService : IDisposable
    {
        #region Add new Pattern
        Pattern AddPattern(Pattern pattern);
        Task<Pattern> AddPatternAsync(Pattern pattern);
        #endregion

        #region Get Patterns
        List<Pattern> GetPatterns();
        Task<List<Pattern>> GetPatternsAsync();
        #endregion

        #region Get pattern selectlist
        List<SelectListItem> GetPatternSelectList();
        Task<List<SelectListItem>> GetPatternSelectListAsync();
        #endregion

        #region Get Pattern by id
        Pattern GetPatternById(int patternId);
        Task<Pattern> GetPatternByIdAsync(int patternId);
        #endregion

        #region Update Pattern
        Pattern UpdatePattern(Pattern pattern);
        Task<Pattern> UpdatePatternAsync(Pattern pattern);
        #endregion

        #region Remove Pattern
        void RemovePattern(int patternId);
        Task RemovePatternAsync(int patternId);
        #endregion

        #region PatternsCount
        int PatternCount();
        Task<int> PatternCountAsync();
        #endregion
    }
}
