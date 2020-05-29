using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Models;

namespace DotNet_Framework_ASP.NET_MVC_e_jQuery_UI.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View(ClienteComCodigo(id));
        }

        private static Cliente ClienteComCodigo(int codigo)
        {
            return Context.RecuperarClientesMock().FirstOrDefault(c => c.Codigo == codigo);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                Context.Adicionar(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                Context.Atualizar(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ClienteComCodigo(id));
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Context.RemoverComCodigo(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult List()
        {
            var clientes = Context.RecuperarClientesMock();
            int[] ids = new int[] { 11, 22, 33, 44, 55 };
            if (clientes.Count() % 2 == 1)
            {
                ViewBag.Ids = string.Join(",", ids);
            }
            return PartialView(clientes);
        }
    }
}
