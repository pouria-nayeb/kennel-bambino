using kennel_bambino.web.Data;
using kennel_bambino.web.Helpers;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using kennel_bambino.web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PhotoService> _logger;

        public PhotoService(ApplicationDbContext context, ILogger<PhotoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Add new Photo or subPhoto to database.
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        #region Add new photo
        public Photo AddPhoto(Photo Photo, IFormFile imageFile)
        {
            try
            {
                Photo.PhotoName = imageFile.UploadPhoto();

                _context.Photos.Add(Photo);
                _context.SaveChanges();


                return Photo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Photo> AddPhotoAsync(Photo Photo, IFormFile imageFile)
        {
            try
            {
                Photo.PhotoName = imageFile.UploadPhoto();

                await _context.Photos.AddAsync(Photo);
                await _context.SaveChangesAsync();


                return Photo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Get all Photos.
        /// </summary>
        /// <returns></returns>
        #region Get all Photos
        public PhotoPagingViewModel GetPhotos(int pageNumber = 1, int pageSize = 30)
        {
            IQueryable<Photo> photos = _context.Photos;

            int take = pageSize;
            int skip = (pageNumber - 1) * take;
            int contactsCount = photos.Count();

            int pageCount = (int)Math.Ceiling(Decimal.Divide(contactsCount, take));

            return new PhotoPagingViewModel
            {
                Photos = photos.Skip(skip).Take(take)
                .OrderByDescending(p => p.PhotoId)
                .ToList(),
                PageNumber = pageNumber,
                PageCount = pageCount
            };
        }

        public async Task<PhotoPagingViewModel> GetPhotosAsync(int pageNumber = 1, int pageSize = 30)
        {
            IQueryable<Photo> photos = _context.Photos;

            int take = pageSize;
            int skip = (pageNumber - 1) * take;
            int contactsCount = photos.Count();

            int pageCount = (int)Math.Ceiling(Decimal.Divide(contactsCount, take));

            return new PhotoPagingViewModel
            {
                Photos = await photos.Skip(skip).Take(take)
                .OrderByDescending(p => p.PhotoId)
                .ToListAsync(),
                PageNumber = pageNumber,
                PageCount = pageCount
            };
        }
        #endregion

        /// <summary>
        /// Get photo by id from database.
        /// </summary>
        /// <param name="PhotoId"></param>
        /// <returns></returns>
        #region Get photo by id
        public Photo GetPhotoById(int photoId) => _context.Photos
            .SingleOrDefault(g => g.PhotoId == photoId);

        public async Task<Photo> GetPhotoByIdAsync(int photoId) => await _context.Photos
            .SingleOrDefaultAsync(g => g.PhotoId == photoId);
        #endregion

        /// <summary>
        /// Update the photo's data from database.
        /// </summary>
        /// <param name="Photo"></param>
        /// <returns></returns>
        #region Update Photo
        public Photo UpdatePhoto(Photo photo, IFormFile imageFile)
        {
            try
            {
                photo.PhotoName = imageFile.UpdateUploadedPetPhoto(photo);

                _context.Photos.Update(photo);
                _context.SaveChanges();


                return photo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Photo> UpdatePhotoAsync(Photo photo, IFormFile imageFile)
        {
            try
            {
                photo.PhotoName = imageFile.UpdateUploadedPetPhoto(photo);

                _context.Photos.Update(photo);
                await _context.SaveChangesAsync();


                return photo;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove the photo from database.
        /// </summary>
        /// <param name="PhotoId"></param>
        #region Remove Photo
        public void RemovePhoto(int photoId)
        {
            var photo = GetPhotoById(photoId);

            photo.RemoveUploadedFile();

            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public async Task RemovePhotoAsync(int photoId)
        {
            var photo = await GetPhotoByIdAsync(photoId);

            photo.RemoveUploadedFile();

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
        }
        #endregion

        /// <summary>
        /// Search photos based on alt.
        /// </summary>
        /// <param name="alt"></param>
        /// <returns></returns>
        #region Search photo
        public List<Photo> SearchPhoto(string alt) => _context.Photos
            .Where(p => p.PhotoName.TextTransform().Contains(alt.TextTransform()))
            .ToList();

        public async Task<List<Photo>> SearchPhotoAsync(string alt) => await _context.Photos
            .Where(p => p.PhotoName.TextTransform().Contains(alt.TextTransform()))
            .ToListAsync();
        #endregion
    }
}
