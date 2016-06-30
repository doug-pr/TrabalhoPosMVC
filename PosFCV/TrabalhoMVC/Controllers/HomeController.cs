using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "CRUD simples de teste";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "E-mail: doug-pr@hotmail.com";

            return View();
        }
    }
}