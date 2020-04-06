using kennel_bambino.web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace kennel_bambino.web.Helpers
{
    public static class UploadImageHelper
    {
        public static string UploadPhoto(this IFormFile imageFile, string folderName = "thumbnails")
        {
            if (imageFile != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{folderName}/", imageName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                return imageName;
            }

            return "default.jpg";
        }

        public static string UpdateUploadedGroupPhoto(this IFormFile imageFile, Group group)
        {
            if (imageFile != null)
            {
                if (group.ImageName.TextTransform() != "default.jpg")
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/thumbnails/", group.ImageName);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    return imageFile.UploadPhoto();
                }
            }

            return group.ImageName;
        }

        public static string UpdateUploadedPetPhoto(this IFormFile imageFile, Photo photo)
        {
            if (imageFile != null)
            {
                if (photo.PhotoName.TextTransform() != "default.jpg")
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/thumbnails/", photo.PhotoName);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    return imageFile.UploadPhoto();
                }
            }

            return photo.PhotoName;
        }

        public static string UpdateUploadedCarouselPhoto(this IFormFile imageFile, Carousel carousel)
        {
            if (imageFile != null)
            {
                if (carousel.ImageName.TextTransform() != "default.jpg")
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/carousels/", carousel.ImageName);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    return imageFile.UploadPhoto("carousels");
                }
            }

            return carousel.ImageName;
        }

        public static void RemoveUploadedFile(this Photo photo) 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/thumbnails/", photo.PhotoName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
