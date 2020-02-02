using Microsoft.AspNetCore.Http;

namespace SimpleImageGallery.Models
{
    public class UploadImageModel
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        // IFormFile, funciona igual ao MultiPartFile, do Spring.
        public IFormFile ImageUploaded { get; set; }
    }
}
