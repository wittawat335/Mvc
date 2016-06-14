using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingComplex.Models;

namespace ShoppingComplex.Areas.Admin.Controllers
{
    
    public class HomeController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            ViewBag.Order = db.Orders.Count(o => o.view == false);
            ViewBag.Customers = db.Customers.Count();
            ViewBag.Products = db.Products.Count();
            ViewBag.Categories = db.Categories.Count();
            return View();
        }
	}
}