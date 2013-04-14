using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dummies.Models;
using Dummies.Models.Contexts;

namespace Dummies.Controllers
{
    public class OpenPositionController : Controller
    {
        private DummiesContext db = new DummiesContext();

        //
        // GET: /OpenPosition/

        public ActionResult Index()
        {
            var openpositions = db.OpenPositions.Include(o => o.BusinessUser).Include(o => o.PositionType);
            return View(openpositions.ToList());
        }

        //
        // GET: /OpenPosition/Details/5

        public ActionResult Details(int id = 0)
        {
            OpenPosition openposition = db.OpenPositions.Find(id);
            if (openposition == null)
            {
                return HttpNotFound();
            }
            return View(openposition);
        }

        //
        // GET: /OpenPosition/Create

        public ActionResult Create()
        {
            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name");
            return View();
        }

        //
        // POST: /OpenPosition/Create

        [HttpPost]
        public ActionResult Create(OpenPosition openposition)
        {
            if (ModelState.IsValid)
            {
                db.OpenPositions.Add(openposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName", openposition.BusinessUserId);
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name", openposition.PositionTypeId);
            return View(openposition);
        }

        //
        // GET: /OpenPosition/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OpenPosition openposition = db.OpenPositions.Find(id);
            if (openposition == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName", openposition.BusinessUserId);
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name", openposition.PositionTypeId);
            return View(openposition);
        }

        //
        // POST: /OpenPosition/Edit/5

        [HttpPost]
        public ActionResult Edit(OpenPosition openposition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openposition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName", openposition.BusinessUserId);
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name", openposition.PositionTypeId);
            return View(openposition);
        }

        //
        // GET: /OpenPosition/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OpenPosition openposition = db.OpenPositions.Find(id);
            if (openposition == null)
            {
                return HttpNotFound();
            }
            return View(openposition);
        }

        //
        // POST: /OpenPosition/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenPosition openposition = db.OpenPositions.Find(id);
            db.OpenPositions.Remove(openposition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}