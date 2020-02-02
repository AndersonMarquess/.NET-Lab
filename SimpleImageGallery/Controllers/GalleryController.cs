using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Data;
using SimpleImageGallery.Data.Models;
using SimpleImageGallery.Models;
using System;
using System.Collections.Generic;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            this._imageService = imageService;
        }

        public IActionResult Index()
        {
            var images = _imageService.FindAll();

            var model = new GalleryIndexModel()
            {
                Images = images,
                SearchQuery = ""
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var image = _imageService.FindById(id);
            return View(image);
        }
    }
}