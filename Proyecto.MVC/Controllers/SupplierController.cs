using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.UnitOfWork;

namespace Proyecto.MVC.Controllers
{
    public class SupplierController : BaseController
    {
        public SupplierController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Supplier
        public ActionResult Index()
        {
            return View(_unit.Supplier.GetList());
        }
    }
}