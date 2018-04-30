using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDIN.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Profile()
        {
            ViewBag.Type = "Profile";
            return View();
        }
    }
}