using Newtonsoft.Json;
using Proyecto.Models;
using Proyecto.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.MVC.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public HomeController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public ActionResult Index()
        {
            //ViewBag.lProduct = JsonConvert.SerializeObject();
            return View(_unit.Product.GetList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Proyecto MVC - CIBERTEC";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dessarrollado por Erick Gonzales";

            return View();
        }

        public ActionResult Unauthorized()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}