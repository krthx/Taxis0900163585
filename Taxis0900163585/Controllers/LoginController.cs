using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxis0900163585.Data;

namespace Taxis0900163585.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            (new TaxisContextMigration()).Initialize();
        }
        public ActionResult Sesion()
        {
            TaxisContext context = new TaxisContext();

            ViewBag.Conductores = context.Conductores;

            return View();
        }

	}
}