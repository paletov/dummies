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
    public class StudentProfileController : Controller
    {
        private DummiesContext db = new DummiesContext();

        //
        // GET: /StudentProfile/

        public ActionResult Index()
        {
            var studentprofiles = db.StudentProfiles.Include(s => s.UserProfile).Include(s => s.Semester);
            return View(studentprofiles.ToList());
        }

        //
        // GET: /StudentProfile/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentProfile studentprofile = db.StudentProfiles.Find(id);
            if (studentprofile == null)
            {
                return HttpNotFound();
            }
            return View(studentprofile);
        }

        //
        // GET: /StudentProfile/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Season");
            return View();
        }

        //
        // POST: /StudentProfile/Create

        [HttpPost]
        public ActionResult Create(StudentProfile studentprofile)
        {
            if (ModelState.IsValid)
            {
                db.StudentProfiles.Add(studentprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", studentprofile.UserId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Season", studentprofile.SemesterId);
            return View(studentprofile);
        }

        //
        // GET: /StudentProfile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentProfile studentprofile = db.StudentProfiles.Find(id);
            if (studentprofile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", studentprofile.UserId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Season", studentprofile.SemesterId);
            return View(studentprofile);
        }

        //
        // POST: /StudentProfile/Edit/5

        [HttpPost]
        public ActionResult Edit(StudentProfile studentprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", studentprofile.UserId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "Season", studentprofile.SemesterId);
            return View(studentprofile);
        }

        //
        // GET: /StudentProfile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentProfile studentprofile = db.StudentProfiles.Find(id);
            if (studentprofile == null)
            {
                return HttpNotFound();
            }
            return View(studentprofile);
        }

        //
        // POST: /StudentProfile/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentProfile studentprofile = db.StudentProfiles.Find(id);
            db.StudentProfiles.Remove(studentprofile);
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