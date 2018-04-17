using Proyecto.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}