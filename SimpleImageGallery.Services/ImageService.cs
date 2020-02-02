using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleImageGallery.Services
{
    public class ImageService : IImage
    {
        private readonly SimpleImageGalleryDbContext _context;

        public ImageService(SimpleImageGalleryDbContext context)
        {
            this._context = context;
        }

        public GalleryImage Create(string title, string tags, IFormFile imageUploaded)
        {
            var model = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags),
                Created = DateTime.Now,
                Url = GetUrlForImage(imageUploaded)
            };
            SaveImageLocal(imageUploaded);
            return SaveGalleryImage(model);
        }

        private IEnumerable<ImageTag> ParseTags(string tags)
        {
            return tags.Split(',').Select(
                tag => new ImageTag { Description = tag.Trim().ToLowerInvariant() }
            ).ToList();
        }

        private string GetUrlForImage(IFormFile imageUploaded)
        {
            return "/images/" + imageUploaded.FileName;
        }

        private void SaveImageLocal(IFormFile imageUploaded)
        {
            string path = @"wwwroot" + GetUrlForImage(imageUploaded);
            using (var fileStream = File.Create(path))
            {
                imageUploaded.CopyTo(fileStream);
            }
        }

        private GalleryImage SaveGalleryImage(GalleryImage galleryImage)
        {
            var result = _context.GalleryImages.Add(galleryImage);
            _context.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<GalleryImage> FindAll()
        {
            return _context.GalleryImages.Include(img => img.Tags);
        }

        public IEnumerable<GalleryImage> FindAllByTag(string tag)
        {
            return FindAll().Where(img => img.Tags.Any(t => t.Description == tag));
        }

        public GalleryImage FindById(int id)
        {
            return FindAll().Where(img => img.Id == id).FirstOrDefault();
        }
    }
}
