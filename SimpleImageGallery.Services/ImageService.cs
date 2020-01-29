using Microsoft.EntityFrameworkCore;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using System.Collections.Generic;
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
            return _context.GalleryImages.FirstOrDefault(gallery => gallery.Id == id);
        }
    }
}
