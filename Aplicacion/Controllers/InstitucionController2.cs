using Aplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Controllers
{
    public class InstitucionController2 : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Institucion
        public ActionResult Index()
        {
            /*var viewB = db.Instituciones.ToList();
            ViewBag.Index = viewB;
            return View();*/

            return View(db.Instituciones.ToList());

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID,Nombre,Identificador,EsActivo,Usuario,Fecha")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.Instituciones.Add(institucion);
                db.SaveChanges();
                return RedirectToAction("View");
            }
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