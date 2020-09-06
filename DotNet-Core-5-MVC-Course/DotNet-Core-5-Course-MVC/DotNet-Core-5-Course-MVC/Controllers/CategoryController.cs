using System.Linq;
using DotNet_Core_5_Course_MVC.Database;
using DotNet_Core_5_Course_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Core_5_Course_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CategoryController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            var categories = _database.Category.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            _database.Add(category);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
