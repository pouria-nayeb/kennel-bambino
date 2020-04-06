using kennel_bambino.web.Data;
using kennel_bambino.web.Helpers;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CarouselService> _logger;

        public CarouselService(ApplicationDbContext context, ILogger<CarouselService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Add new carousel to database.
        /// </summary>
        /// <param name="carousel"></param>
        /// <param name="carouselFile"></param>
        /// <returns></returns>
        #region Add new carousel
        public Carousel AddCarousel(Carousel carousel, IFormFile carouselFile)
        {
            try
            {
                carousel.ImageName = carouselFile.UploadPhoto("carousels");

                _context.Carousels.Add(carousel);
                _context.SaveChanges();

                return carousel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Carousel> AddCarouselAsync(Carousel carousel, IFormFile carouselFile)
        {
            try
            {
                carousel.ImageName = carouselFile.UploadPhoto("carousels");

                await _context.Carousels.AddAsync(carousel);
                await _context.SaveChangesAsync();

                return carousel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Get all carousels.
        /// </summary>
        /// <returns></returns>
        #region Get carousels
        public IEnumerable<Carousel> GetCarousels() => _context.Carousels.ToList();

        public async Task<IEnumerable<Carousel>> GetCarouselsAsync() => await _context.Carousels.ToListAsync();
        #endregion

        /// <summary>
        /// Get carousel by id from database.
        /// </summary>
        /// <param name="carouselId"></param>
        /// <returns></returns>
        #region Get carousel by id
        public Carousel GetCarouselById(int carouselId) => _context.Carousels
            .SingleOrDefault(c => c.CarouselId == carouselId);

        public async Task<Carousel> GetCarouselByIdAsync(int carouselId) => await _context.Carousels
            .SingleOrDefaultAsync(c => c.CarouselId == carouselId);
        #endregion

        /// <summary>
        /// Update the carousel's data from database.
        /// </summary>
        /// <param name="carousel"></param>
        /// <param name="carouselFile"></param>
        /// <returns></returns>
        #region Update carousel
        public Carousel UpdateCarousel(Carousel carousel, IFormFile carouselFile)
        {
            try
            {
                carousel.ImageName = carouselFile.UpdateUploadedCarouselPhoto(carousel);

                _context.Carousels.Update(carousel);
                _context.SaveChanges();

                return carousel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Carousel> UpdateCarouselAsync(Carousel carousel, IFormFile carouselFile)
        {
            try
            {
                carousel.ImageName = carouselFile.UpdateUploadedCarouselPhoto(carousel);

                _context.Carousels.Update(carousel);
                await _context.SaveChangesAsync();

                return carousel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove the carousel from database.
        /// </summary>
        /// <param name="carouselId"></param>
        #region Remove carousel
        public void RemoveCarousel(int carouselId)
        {
            var carousel = GetCarouselById(carouselId);

            _context.Carousels.Remove(carousel);
            _context.SaveChanges();
        }

        public async Task RemoveCarouselAsync(int carouselId)
        {
            var carousel = await GetCarouselByIdAsync(carouselId);

            _context.Carousels.Remove(carousel);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
