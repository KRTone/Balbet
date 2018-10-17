using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Balbet.WEB.Controllers
{
    public class LogOffController : Controller
    {
        // GET: LogOff
        public ActionResult Index()
        {
            if (Request.Cookies["login"] != null)
            {
                Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}