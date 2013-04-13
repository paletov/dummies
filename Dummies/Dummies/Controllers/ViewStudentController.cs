using Dummies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dummies.CustomHelpers;

namespace Dummies.Controllers
{
    public class ViewStudentController : Controller
    {
        //
        // GET: /ViwStudent/

        public ActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Name = "Slav Petkov"
                },

                new Student()
                {
                    Name = "Rumen Paletov"
                },
                new Student()
                {
                    Name = "Dimo Uzunov"
                },
                new Student()
                {
                    Name = "Sasho Panaiotov"
                }
            };

            return View(students);
        }

        public ActionResult Dummy()
        {
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Name = "Dimo Uzunov"
                },
            };
            return View(students);
        }

        public ActionResult GoBack()
        {
            return View("Index");
        }

        public ActionResult ShowDetails(string name)
        {
            Student student = new Student()
            {
                Name = name
            };
            
            return View("ShowDetails", student);
        }

        //
        // GET: /ViwStudent/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ViwStudent/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ViwStudent/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ViwStudent/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ViwStudent/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ViwStudent/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ViwStudent/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
