using System;
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
    public class StatisticsController : Controller
    {
        private ModelStatContainer db = new ModelStatContainer();

        // GET: Statistics
        public async Task<ActionResult> Index()
        {
            var statisticSet = db.StatisticSet.Include(s => s.Academy);
            return View(await statisticSet.ToListAsync());
        }

        // GET: Statistics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistic statistic = await db.StatisticSet.FindAsync(id);
            if (statistic == null)
            {
                return HttpNotFound();
            }
            return View(statistic);
        }

        // GET: Statistics/Create
        public ActionResult Create()
        {
            ViewBag.AcademyId = new SelectList(db.AcademySet, "Id", "Name");
            return View();
        }

        // POST: Statistics/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,DateStart,DateEnd,Published,Score,AcademyId")] Statistic statistic)
        {
            if (ModelState.IsValid)
            {
                db.StatisticSet.Add(statistic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AcademyId = new SelectList(db.AcademySet, "Id", "Name", statistic.AcademyId);
            return View(statistic);
        }

        // GET: Statistics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistic statistic = await db.StatisticSet.FindAsync(id);
            if (statistic == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademyId = new SelectList(db.AcademySet, "Id", "Name", statistic.AcademyId);
            return View(statistic);
        }

        // POST: Statistics/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,DateStart,DateEnd,Published,Score,AcademyId")] Statistic statistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statistic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AcademyId = new SelectList(db.AcademySet, "Id", "Name", statistic.AcademyId);
            return View(statistic);
        }

        // GET: Statistics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistic statistic = await db.StatisticSet.FindAsync(id);
            if (statistic == null)
            {
                return HttpNotFound();
            }
            return View(statistic);
        }

        // POST: Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Statistic statistic = await db.StatisticSet.FindAsync(id);
            db.StatisticSet.Remove(statistic);
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
