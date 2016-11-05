﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Login(LoginViewModel login,string ReturnUrl)
        {
            if(login.Email=="givemin5@gmail.com" && login.Password=="test")
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, false);

                return Redirect(ReturnUrl ?? "/");

            }

            return View();
        }
    }
}