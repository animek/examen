using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examenNa.DAL;
using examenNa.Models;

namespace examenNa.Controllers
{
    public class CoberturaController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Cobertura
        public ActionResult Index()
        {
            return View(db.Cobertura.ToList());
        }

        // GET: Cobertura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // GET: Cobertura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cobertura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                cobertura.UsuarioCreacion = "usuario@mail.com";
                cobertura.UsuarioModificacion = "usuario@mail.com";
                cobertura.FechaCreacion = DateTime.Now;
                cobertura.FechsModificacion = DateTime.Now;

                db.Cobertura.Add(cobertura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cobertura);
        }

        // GET: Cobertura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // POST: Cobertura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Cobertura cobertura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cobertura.UsuarioModificacion = "admin@mail.com";
                    cobertura.FechsModificacion = DateTime.Now;
                    cobertura.UsuarioCreacion = "admin@mail.com";
                    cobertura.FechaCreacion = DateTime.Now;

                    db.Entry(cobertura).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cobertura);

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // GET: Cobertura/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cobertura cobertura = db.Cobertura.Find(id);
        //    if (cobertura == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cobertura);
        //}

        //// POST: Cobertura/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cobertura cobertura = db.Cobertura.Find(id);
        //    db.Cobertura.Remove(cobertura);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
