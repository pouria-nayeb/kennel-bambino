using kennel_bambino.web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IEyeColorService
    {
        #region Add new eyeColor
        EyeColor AddEyeColor(EyeColor eyeColor);
        Task<EyeColor> AddEyeColorAsync(EyeColor eyeColor);
        #endregion

        #region Get eyeColors
        List<EyeColor> GetEyeColors();
        Task<List<EyeColor>> GetEyeColorsAsync();
        #endregion

        #region Get eyeColor by id
        EyeColor GetEyeColorById(int eyeColorId);
        Task<EyeColor> GetEyeColorByIdAsync(int eyeColorId);
        #endregion

        #region Update eyeColor
        EyeColor UpdateEyeColor(EyeColor eyeColor);
        Task<EyeColor> UpdateEyeColorAsync(EyeColor eyeColor);
        #endregion

        #region Remove eyeColor
        void RemoveEyeColor(int eyeColorId);
        Task RemoveEyeColorAsync(int eyeColorId);
        #endregion

        #region EyeColorCount
        int EyeColorsCount();
        Task<int> EyeColorsCountAsync();
        #endregion
    }
}
