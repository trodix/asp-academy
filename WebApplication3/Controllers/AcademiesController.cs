using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AcademiesController : Controller
    {
        private ModelStatContainer db = new ModelStatContainer();

        // GET: Academies
        public ActionResult Index()
        {
            return View(db.AcademySet.ToList());
        }

        // GET: Academies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = db.AcademySet.Find(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // GET: Academies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Academies/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                db.AcademySet.Add(academy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academy);
        }

        // GET: Academies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = db.AcademySet.Find(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // POST: Academies/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academy);
        }

        // GET: Academies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = db.AcademySet.Find(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // POST: Academies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Academy academy = db.AcademySet.Find(id);
            db.AcademySet.Remove(academy);
            db.SaveChanges();
            return RedirectToAction("Index");
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
