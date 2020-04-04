using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface ICarouselService
    {
        Carousel AddCarousel(Carousel carousel, IFormFile carouselFile);
        Task<Carousel> AddCarouselAsync(Carousel carousel, IFormFile carouselFile);

        IEnumerable<Carousel> GetCarousels();
        Task<IEnumerable<Carousel>> GetCarouselsAsync();

        Carousel GetCarouselById(int carouselId);
        Task<Carousel> GetCarouselByIdAsync(int carouselId);

        Carousel UpdateCarousel(Carousel carousel, IFormFile carouselFile);
        Task<Carousel> UpdateCarouselAsync(Carousel carousel, IFormFile carouselFile);

        void RemoveCarousel(int carouselId);
        Task RemoveCarouselAsync(int carouselId);
    }
}
