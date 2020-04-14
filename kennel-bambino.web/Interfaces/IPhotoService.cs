using kennel_bambino.web.Models;
using kennel_bambino.web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IPhotoService
    {
        #region Add new photo
        Photo AddPhoto(Photo photo, IFormFile imageFile);
        Task<Photo> AddPhotoAsync(Photo photo, IFormFile imageFile);
        #endregion

        #region Get photos
        PhotoPagingViewModel GetPhotos(int pageNumber, int pageSize);
        Task<PhotoPagingViewModel> GetPhotosAsync(int pageNumber, int pageSize);
        #endregion

        #region Get photo by id
        Photo GetPhotoById(int photoId);
        Task<Photo> GetPhotoByIdAsync(int photoId);
        #endregion

        #region PetSelectListItem
        List<SelectListItem> GetPetSelectListItem();
        Task<List<SelectListItem>> GetPetSelectListItemAsync();
        #endregion

        #region Update photo
        Photo UpdatePhoto(Photo photo, IFormFile imageFile);
        Task<Photo> UpdatePhotoAsync(Photo photo, IFormFile imageFile);
        #endregion

        #region Remove photo
        void RemovePhoto(int photoId);
        Task RemovePhotoAsync(int photoId);
        #endregion

        #region Photos count
        int PhotosCount();
        Task<int> PhotosCountAsync();
        #endregion

        #region Search photo
        List<Photo> SearchPhoto(string alt);
        Task<List<Photo>> SearchPhotoAsync(string alt);
        #endregion
    }
}
