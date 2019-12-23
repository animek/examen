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
    public class PlanController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: Plan
        public ActionResult Index()
        {
            var plan = db.Plan.Include(p => p.Cobertura);
            return View(plan.ToList());
        }

        // GET: Plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plan/Create
        public ActionResult Create()
        {
            List<Cobertura> sortedNumbers = db.Cobertura.OrderBy(x=>x.NombreCobertura).ToList();  
            ViewBag.IdCobertura = new SelectList(sortedNumbers, "IdCobertura", "NombreCobertura");
            return View(); 
        }

        // POST: Plan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plan plan)

        {
            if (ModelState.IsValid)
            {
                plan.FechaCreacion = DateTime.Now;
                plan.UsuarioCreacion = "admin@mail.com";

                plan.FechsModificacion = DateTime.Now;
                plan.UsuarioModificacion = "admin@mail.com";

                db.Plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCobertura = new SelectList(db.Cobertura, "IdCobertura", "NombreCobertura", plan.IdCobertura);
            return View(plan);
        }

        // GET: Plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCobertura = new SelectList(db.Cobertura, "IdCobertura", "NombreCobertura", plan.IdCobertura);
            return View(plan);
        }

        // POST: Plan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plan plan)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    plan.UsuarioModificacion = "admin@mail.com";
                    plan.FechsModificacion = DateTime.Now;

                    db.Entry(plan).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdCobertura = new SelectList(db.Cobertura, "IdCobertura", "NombreCobertura", plan.IdCobertura);
                return View(plan);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        // GET: Plan/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Plan plan = db.Plan.Find(id);
        //    if (plan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(plan);
        //}

        //// POST: Plan/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Plan plan = db.Plan.Find(id);
        //    db.Plan.Remove(plan);
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
