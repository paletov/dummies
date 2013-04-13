using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dummies.Filters;
using WebMatrix.WebData;

namespace Dummies.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            //---------------------------MOCKUP
            if (WebSecurity.CurrentUserName == "bigboss")
            {
                return RedirectToAction("BusinessProfile");
            }
            //-----------------------------
            return View();
        }

        //-------------------------------MOCKUP
        public ActionResult BusinessProfile()
        {
            return View();
        }

        public ActionResult JavaDeveloper()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
        //----------------------------------



    }
}
