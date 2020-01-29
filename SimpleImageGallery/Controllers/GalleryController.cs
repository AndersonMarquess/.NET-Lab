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

        private IEnumerable<GalleryImage> GetMockGalleryImages()
        {
            return new List<GalleryImage>() {
                new GalleryImage()
                {
                    Title = "Test",
                    Created = DateTime.Now,
                    Url = "https://images.pexels.com/photos/956003/pexels-photo-956003.jpeg?auto=compress&cs=tinysrgb&h=650&w=940",
                    Tags = GetMockTags()
                },
                new GalleryImage()
                {
                    Title = "On The Trail",
                    Created = DateTime.Now,
                    Url = "https://images.pexels.com/photos/1096038/pexels-photo-1096038.jpeg?auto=compress&cs=tinysrgb&h=650&w=940",
                    Tags = GetMockTags()
                },
                new GalleryImage()
                {
                    Title = "Downtown",
                    Created = DateTime.Now,
                    Url = "https://images.pexels.com/photos/3551207/pexels-photo-3551207.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260",
                    Tags = GetCityTags()
                }
            };
        }

        private IEnumerable<ImageTag> GetCityTags()
        {
            return new List<ImageTag>() {
                new ImageTag()
                {
                    Id = 3,
                    Description = "Urban"
                }
            };
        }

        private IEnumerable<ImageTag> GetMockTags()
        {
            return new List<ImageTag>() {
                new ImageTag()
                {
                    Id = 0,
                    Description = "Mock"
                },
                new ImageTag()
                {
                    Id = 1,
                    Description = "Test"
                }
            };
        }
    }
}