using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingComplex.Areas.Admin.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Admin/Navbar
        public ActionResult Navbar(string controller, string action)
        {
            
            return View();
        }
    }
}