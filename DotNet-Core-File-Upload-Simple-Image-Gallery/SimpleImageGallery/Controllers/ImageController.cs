using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleImageGallery.Data;
using SimpleImageGallery.Models;
using System;

namespace SimpleImageGallery.Controllers
{
    public class ImageController : Controller
    {

        private readonly IConfiguration _config;
        private readonly IImage _imageService;
        public string ApiKey { get; }

        public ImageController(IConfiguration config, IImage imageService)
        {
            _config = config;
            _imageService = imageService;
            ApiKey = _config["ApiKey"];
            Console.WriteLine(ApiKey);
        }

        public IActionResult Upload()
        {
            var model = new UploadImageModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadNewImage(UploadImageModel imageModel)
        {
            _imageService.Create(imageModel.Title, imageModel.Tags, imageModel.ImageUploaded);
            return RedirectToAction("Index", "Gallery");
        }
    }
}