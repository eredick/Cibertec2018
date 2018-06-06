using Newtonsoft.Json;
using Proyecto.Models.ViewModels;
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
            return View();
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

        public int Count(ProductVM product, int itemNum)
        {
            var total = _unit.Product.CountProductsPaged(product);
            return total % itemNum != 0 ? (total / itemNum) + 1 : (total / itemNum);
        }

        public PartialViewResult GetList(ProductVM product, int page, int itemNum)
        {
            if (page <= 0 || itemNum <= 0) return PartialView("_List", new List<ProductVM>());
            var start = ((page - 1) * itemNum) + 1;
            var end = itemNum;
            return PartialView("_List", _unit.Product.GetAllProducstPaged(product, start, end));
        }
    }
}