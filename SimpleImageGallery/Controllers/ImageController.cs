using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleImageGallery.Models;
using System;

namespace SimpleImageGallery.Controllers
{
    public class ImageController : Controller
    {

        public readonly IConfiguration _config;
        public string ApiKey { get; }

        public ImageController(IConfiguration config)
        {
            _config = config;
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
        public IActionResult UploadNewImage()
        {
            return Ok();
        }
    }
}