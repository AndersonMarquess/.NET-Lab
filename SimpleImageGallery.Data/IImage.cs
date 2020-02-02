using Microsoft.AspNetCore.Http;
using SimpleImageGallery.Data.Models;
using System.Collections.Generic;

namespace SimpleImageGallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> FindAll();
        IEnumerable<GalleryImage> FindAllByTag(string tag);
        GalleryImage FindById(int id);
        GalleryImage Create(string title, string tags, IFormFile imageUploaded);
    }
}
