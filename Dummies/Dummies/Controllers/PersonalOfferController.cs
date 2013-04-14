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
    public class PersonalOfferController : Controller
    {
        private DummiesContext db = new DummiesContext();

        //
        // GET: /PersonalOffer/

        public ActionResult Index()
        {
            var personaloffers = db.PersonalOffers.Include(p => p.BusinessUser).Include(p => p.PositionType).Include(p => p.Student);
            return View(personaloffers.ToList());
        }

        //
        // GET: /PersonalOffer/Details/5

        public ActionResult Details(int id = 0)
        {
            PersonalOffer personaloffer = db.PersonalOffers.Find(id);
            if (personaloffer == null)
            {
                return HttpNotFound();
            }
            return View(personaloffer);
        }

        //
        // GET: /PersonalOffer/Create

        public ActionResult Create()
        {
            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name");
            ViewBag.StudentId = new SelectList(db.StudentProfiles, "StudentProfileId", "FacultyNumber");
            return View();
        }

        //
        // POST: /PersonalOffer/Create

        [HttpPost]
        public ActionResult Create(PersonalOffer personaloffer)
        {
            if (ModelState.IsValid)
            {
                db.PersonalOffers.Add(personaloffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName", personaloffer.BusinessUserId);
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name", personaloffer.PositionTypeId);
            ViewBag.StudentId = new SelectList(db.StudentProfiles, "StudentProfileId", "FacultyNumber", personaloffer.StudentId);
            return View(personaloffer);
        }

        //
        // GET: /PersonalOffer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonalOffer personaloffer = db.PersonalOffers.Find(id);
            if (personaloffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName", personaloffer.BusinessUserId);
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name", personaloffer.PositionTypeId);
            ViewBag.StudentId = new SelectList(db.StudentProfiles, "StudentProfileId", "FacultyNumber", personaloffer.StudentId);
            return View(personaloffer);
        }

        //
        // POST: /PersonalOffer/Edit/5

        [HttpPost]
        public ActionResult Edit(PersonalOffer personaloffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personaloffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessUserId = new SelectList(db.UserProfiles, "UserId", "UserName", personaloffer.BusinessUserId);
            ViewBag.PositionTypeId = new SelectList(db.PositionTypes, "PositionTypeId", "Name", personaloffer.PositionTypeId);
            ViewBag.StudentId = new SelectList(db.StudentProfiles, "StudentProfileId", "FacultyNumber", personaloffer.StudentId);
            return View(personaloffer);
        }

        //
        // GET: /PersonalOffer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PersonalOffer personaloffer = db.PersonalOffers.Find(id);
            if (personaloffer == null)
            {
                return HttpNotFound();
            }
            return View(personaloffer);
        }

        //
        // POST: /PersonalOffer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalOffer personaloffer = db.PersonalOffers.Find(id);
            db.PersonalOffers.Remove(personaloffer);
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