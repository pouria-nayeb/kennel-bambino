using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IBodyTypeService : IDisposable
    {
        #region Add new BodyType
        BodyType AddBodyType(BodyType bodyType);
        Task<BodyType> AddBodyTypeAsync(BodyType bodyType);
        #endregion

        #region Get bodyTypes
        List<BodyType> GetBodyTypes();
        Task<List<BodyType>> GetBodyTypesAsync();
        #endregion

        #region Get bodttype selectlist
        List<SelectListItem> GetBodyTypeSelectList();
        Task<List<SelectListItem>> GetBodyTypeSelectListAsync();
        #endregion

        #region Get BodyType by id
        BodyType GetBodyTypeById(int bodyTypeId);
        Task<BodyType> GetBodyTypeByIdAsync(int bodyTypeId);
        #endregion

        #region Update BodyType
        BodyType UpdateBodyType(BodyType bodyType);
        Task<BodyType> UpdateBodyTypeAsync(BodyType bodyType);
        #endregion

        #region Remove BodyType
        void RemoveBodyType(int bodyTypeId);
        Task RemoveBodyTypeAsync(int bodyTypeId);
        #endregion

        #region BodyTypesCount
        int BodyTypesCount();
        Task<int> BodyTypesCountAsync();
        #endregion
    }
}
