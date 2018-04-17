﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.UnitOfWork;

namespace Proyecto.MVC.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Categorie
        public ActionResult Index()
        {
            return View(_unit.Categories.GetList());
        }
    }
}