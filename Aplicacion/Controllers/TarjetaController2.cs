using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class TarjetaController2 : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tarjeta
        public ActionResult Index()
        {
            return View("View");
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Inactivar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inactivar(int ID)
        {
            return View("View");
        }




    }
}