﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingComplex.Models;

namespace ShoppingComplex.Controllers
{
    public class OrderController : Controller
    {
        ShoppingDbContext db = new ShoppingDbContext();
        //
        // GET: /Order/
        public ActionResult Checkout()
        {
            var model = new Order();
            model.CustomerId = User.Identity.Name;
            model.OrderDate = DateTime.Now.Date;
            model.Amount = ShoppingCart.Cart.Total;

            return View(model);
        }

        public ActionResult Purchase(Order model)
        {
            db.Orders.Add(model);

            var cart = ShoppingCart.Cart;
            foreach (var p in cart.Items)
            {
                var d = new OrderDetail
                {
                    Order = model,
                    ProductId = p.Id,
                    UnitPrice = p.UnitPrice,
                    Discount = p.Discount,
                    Quantity = p.Quantity
                };

                db.OrderDetails.Add(d);
            }
            db.SaveChanges();
            
            return RedirectToAction("Detail", new { id = model.Id });
        }

        public ActionResult Detail(int id)
        {
            var order = db.Orders.Find(id);
            return View(order);
        }

        public ActionResult List()
        {
            var orders = db.Orders
                .Where(o => o.CustomerId == User.Identity.Name);
            return View(orders);
        }
	}
}