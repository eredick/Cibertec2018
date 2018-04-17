using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.UnitOfWork;

namespace Proyecto.MVC.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_unit.Customers.GetList());
        }
    }
}