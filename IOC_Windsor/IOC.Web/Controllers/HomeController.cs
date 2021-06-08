using IOC.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IOC.Web.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public void Login()
        {
            FormsAuthentication.SetAuthCookie("fabio.mota", true);
        }

        [HttpGet]
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
