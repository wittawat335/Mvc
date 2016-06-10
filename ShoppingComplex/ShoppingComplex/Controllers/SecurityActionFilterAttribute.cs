﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Threading;
using System.Web.Mvc;

using System.Linq;

using ShoppingComplex.Models;

namespace ShoppingComplex.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class SecurityActionFilterAttribute : ActionFilterAttribute
    {
        ApplicationDbContext sdb = new ApplicationDbContext();
        
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public SecurityActionFilterAttribute()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(sdb));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            
            var uri = context.HttpContext.Request.Url.AbsoluteUri;
            if (uri.ToLower().Contains("/admin/")) 
            { 
                var ControllerName = context.ActionDescriptor.ControllerDescriptor.ControllerName;
                var ActionName = context.ActionDescriptor.ActionName;

                if (!context.HttpContext.Request.IsAuthenticated) 
                {
                    if (!uri.ToLower().Contains("/login"))
                    {
                        context.HttpContext.Response.Redirect("/Admin/Account/Login?returnUrl=" + uri);
                    }
                }
                else
                {
                    var user = UserManager.FindByName(context.HttpContext.User.Identity.Name);
                    if (user.Roles.Count == 0) 
                    {
                        context.HttpContext.Response.Redirect("/Admin/Account/Login?returnUrl=" + uri);
                    }
                    else
                    {
                        var roleIds = user.Roles.Select(r => r.RoleId).ToList();
                        var perms = sdb.Permissions
                            .Where(p => roleIds.Contains(p.RoleId))
                            .Where(p => p.Action.Name == ActionName 
                                && p.Action.Controller == ControllerName).ToList();
                        if (perms.Count == 0) 
                        {
                        }
                        else if (!perms.First().Allowable) 
                        {
                            context.HttpContext.Response.Redirect("/Admin/Account/Login?returnUrl=" + uri);
                        }
                        else // Cho phép
                        {
                            var actions = sdb.Permissions
                                .Where(p => roleIds.Contains(p.RoleId))
                                .Where(p => p.Action.Controller == ControllerName).ToList();
                            foreach (var a in actions)
                            {
                                context.Controller.ViewData[a.Action.Name] = a.Allowable;
                            }
                        }
                    }
                }
            }
        }
    }
}