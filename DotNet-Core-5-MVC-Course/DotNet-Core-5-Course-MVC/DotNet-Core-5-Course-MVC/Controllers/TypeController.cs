using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Core_5_Course_MVC.Database;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Core_5_Course_MVC.Controllers
{
    public class TypeController : Controller
    {
        private readonly ApplicationDbContext _database;

        public TypeController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            var types = _database.Type.ToList();
            return View(types);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Type type)
        {
            if (ModelState.IsValid)
            {
                _database.Type.Add(type);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var type = _database.Type.Find(Id);
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Type type)
        {
            if (ModelState.IsValid)
            {
                _database.Type.Update(type);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type);
        }
        
        public IActionResult Delete(int Id)
        {
            var type = _database.Type.Find(Id);
            _database.Type.Remove(type);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
