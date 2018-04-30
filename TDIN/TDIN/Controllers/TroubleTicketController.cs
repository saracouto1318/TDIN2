using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDIN.Controllers
{
    public class TroubleTicketController : Controller
    {
        public ActionResult Ticket()
        {
            ViewBag.Type = "TroubleTicket";
            return View();
        }
    }
}