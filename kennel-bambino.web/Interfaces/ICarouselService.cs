using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface ICarouselService : IDisposable
    {
        #region Add new carousel
        Carousel AddCarousel(Carousel carousel, IFormFile carouselFile);
        Task<Carousel> AddCarouselAsync(Carousel carousel, IFormFile carouselFile);
        #endregion

        #region Get carousels
        IEnumerable<Carousel> GetCarousels();
        Task<IEnumerable<Carousel>> GetCarouselsAsync();
        #endregion

        #region Get carousel by id
        Carousel GetCarouselById(int carouselId);
        Task<Carousel> GetCarouselByIdAsync(int carouselId);
        #endregion

        #region Update carousel
        Carousel UpdateCarousel(Carousel carousel, IFormFile carouselFile);
        Task<Carousel> UpdateCarouselAsync(Carousel carousel, IFormFile carouselFile);
        #endregion

        #region Remove carousel
        void RemoveCarousel(int carouselId);
        Task RemoveCarouselAsync(int carouselId);
        #endregion

        #region Carousels count
        int CarouselsCount();
        Task<int> CarouselsCountAsync();
        #endregion
    }
}
