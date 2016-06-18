using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingComplex.Models;

namespace ShoppingComplex.Controllers
{
    public class HomeController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        public ActionResult Index()
        {
            var model = db.Categories
               .Where(c => c.Products.Count >= 5)
               .OrderBy(c => Guid.NewGuid()).ToList()
               .Take(4);

            ViewBag.Suppliers = db.Suppliers
                .Where(c => c.Products.Count >= 5)
                .OrderBy(c => Guid.NewGuid()).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            var name = Request["term"];

            var data = db.Products
                .Where(p => p.Name.Contains(name))
                .Select(p => p.Name).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult Category()
        {
            var model = db.Categories;
            return PartialView("_Category", model);
        }

        public ActionResult Special()
        {
            var model = db.Products.Where(p => p.Special == true).Take(3).OrderBy(p => Guid.NewGuid()).ToList();
            return PartialView("_Special", model);
        }
        
        public ActionResult Saleoff()
        {
            var model = db.Products.Where(p => p.Discount > 0).Take(3).OrderBy(p => Guid.NewGuid()).ToList();
            return PartialView("_Saleoff", model);
        }
    }
}