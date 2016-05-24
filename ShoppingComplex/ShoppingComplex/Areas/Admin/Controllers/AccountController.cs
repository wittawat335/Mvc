﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using ShoppingComplex.Models;
using Microsoft.AspNet.Identity;

namespace ShoppingComplex.Areas.Admin.Controllers
{
    public class AccountController : SecurityController
    {
        // GET: Admin/Account
        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("SignIn");
        }

        public ActionResult SignIn(String returnUrl)
        {
            if (returnUrl.Contains("/Admin/"))
            {
                Response.Redirect("/Admin/Account/SignIn?returnUrl=" + returnUrl);
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(String UserName, String Password, string returnUrl)
        {
            var user = await UserManager.FindAsync(UserName, Password);
            if (user != null)
            {
                await SignInAsync(user, false);
                if (returnUrl == null)
                {
                    returnUrl = "/Admin/Master";
                }
                return Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}