﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            return View(await db.AcademySet.ToListAsync());
        }

        // GET: Academies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = await db.AcademySet.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Area,Region")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                db.AcademySet.Add(academy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(academy);
        }

        // GET: Academies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = await db.AcademySet.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Area,Region")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(academy);
        }

        // GET: Academies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academy academy = await db.AcademySet.FindAsync(id);
            if (academy == null)
            {
                return HttpNotFound();
            }
            return View(academy);
        }

        // POST: Academies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Academy academy = await db.AcademySet.FindAsync(id);
            db.AcademySet.Remove(academy);
            await db.SaveChangesAsync();
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
