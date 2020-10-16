using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion.Models;

namespace Aplicacion.Controllers
{
    public class InstitucionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Institucions
        public ActionResult Index()
        {
            return View(db.Instituciones.ToList());
        }

        // GET: Institucions/Details/5
        public ActionResult Inactivar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institucion institucion = db.Instituciones.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inactivar(int id)
        {
            Institucion institucion = db.Instituciones.Find(id);
            if (institucion.EsActivo == 1)
            {
                institucion.EsActivo = 0;
            }
            else
            {
                institucion.EsActivo = 1;
            }
            db.Entry(institucion).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }







        // GET: Institucions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Institucions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Identificador,EsActivo,Usuario,Fecha")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                institucion.EsActivo = 1;
                institucion.Usuario = "Adiel";
                institucion.Fecha = DateTime.Now;
                db.Instituciones.Add(institucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(institucion);
        }

      

       

        // GET: Institucions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institucion institucion = db.Instituciones.Find(id);
            if (institucion == null)
            {
                return HttpNotFound();
            }
            return View(institucion);
        }

        // POST: Institucions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(institucion);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
