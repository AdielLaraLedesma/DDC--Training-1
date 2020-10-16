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
    public class TarjetaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tarjetas
        public ActionResult Index()
        {
            return View(db.Tarjetas.ToList());
        }


        public ActionResult Inactivar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inactivar(int id)
        {
            Tarjeta tarjeta = db.Tarjetas.Find(id);
            if (tarjeta.EsActivo == 1)
            {
                tarjeta.EsActivo = 0;
            }
            else
            {
                tarjeta.EsActivo = 1;
            }
            db.Entry(tarjeta).State = EntityState.Modified;
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
        public ActionResult Create([Bind(Include = "ID,Numero,Institucion_ID,EsActivo,Usuario,Fecha")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                tarjeta.EsActivo = 1;
                tarjeta.Usuario = "Adiel";
                tarjeta.Institucion_ID = 2;
                tarjeta.Fecha = DateTime.Now;
                db.Tarjetas.Add(tarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarjeta);
        }





        // GET: Tarjetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }





        // GET: Institucions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = db.Tarjetas.Find(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: Institucions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Numero")]Tarjeta tarjeta)
        {
            tarjeta.Institucion_ID = 2;
            if (ModelState.IsValid)
            {
                db.Entry(tarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarjeta);
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
