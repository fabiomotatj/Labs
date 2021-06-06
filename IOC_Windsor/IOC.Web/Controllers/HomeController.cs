using IOC.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC.Web.Controllers
{
    public class HomeController : Controller
    {

        IUsuarioBus _usuario;
        // GET: api/Usuario

        public HomeController(IUsuarioBus usuarioBus)
        {
            _usuario = usuarioBus;
        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
