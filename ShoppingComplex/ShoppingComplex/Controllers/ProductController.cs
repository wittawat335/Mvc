using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using ShoppingComplex.Models;
using PagedList;

namespace ShoppingComplex.Controllers
{
    public class ProductController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        // GET: Product
       

        public ActionResult Category(int CategoryID = 0)
        {
            
            if (CategoryID != 0)
            {
                var model = db.Products.Where(p => p.CategoryId == CategoryID);
                return View(model);
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            var model = db.Products.Find(id);

            //ถ้ามีคนเข้ามาดูจะนำไปนับและบันทึกไว้
            model.Views++;
            db.SaveChanges();

            var views = Request.Cookies["views"];

            if (views == null)
            {
                views = new HttpCookie("views");
            }

            views.Values[id.ToString()] = id.ToString();

            views.Expires = DateTime.Now.AddMonths(1);

            Response.Cookies.Add(views);

            var keys = views.Values.AllKeys.Select(k => int.Parse(k)).ToList();

            ViewBag.Views = db.Products
                .Where(p => keys.Contains(p.Id));
            
            //Top 10 
            ViewBag.Top = db.Products.Where(p => p.Id > 0).OrderByDescending(o => o.Views).Take(10).ToList();
            return View(model);
        }

        public ActionResult Search(String Keywords = "")
        {
            if (Keywords != "")
            {
                var model = db.Products
                    .Where(p => p.Name.Contains(Keywords));

               
                return View(model);
            }
            return View(db.Products);
        }

        public ActionResult New(int page = 1, int pagesize = 15)
        {
            List<Product> listProduct = db.Products.Where(p => p.Latest).ToList();
            PagedList<Product> model = new PagedList<Product>(listProduct, page, pagesize);
           
            return View(model);
        }

        public ActionResult BestSeller(int page = 1, int pagesize = 15)
        {
            List<Product> listProduct = db.Products.Where(p => p.Special).ToList();
            PagedList<Product> model = new PagedList<Product>(listProduct, page, pagesize);

            return View(model);
        }

        public ActionResult SaleOff(int page = 1, int pagesize = 15)
        {
            List<Product> listProduct = db.Products.Where(p => p.Discount > 0).ToList();
            PagedList<Product> model = new PagedList<Product>(listProduct, page, pagesize);
         
            return View(model);
        }

        public ActionResult All(int page = 1, int pagesize = 15)
        {
            List<Product> listProduct = db.Products.ToList();
            PagedList<Product> model = new PagedList<Product>(listProduct, page, pagesize);
        
            return View(model);
        }
    }
}