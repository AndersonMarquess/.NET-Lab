using DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Controllers
{
    public class FiltroController : Controller
    {
        // GET: Filtro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filtrar(Filtro filtro)
        {
            if (ModelState.IsValid)
            {
                return Json(filtro);
            }

            return View("Index", filtro);
        }
    }
}