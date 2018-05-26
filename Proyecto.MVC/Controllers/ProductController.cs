using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;
using Proyecto.Models.ViewModels;
using Proyecto.MVC.ActionFilters;
using Proyecto.UnitOfWork;

namespace Proyecto.MVC.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductsPaged(Product entity, int start, int end)
        {
            var lProducts = _unit.Product.GetProducstPaged(entity, start, end);
            var count = _unit.Product.CountProductsPaged();
            return Json(new { lProducts, count });
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            var product = _unit.Product.GetById(Id);
            var productVM = new ProductVM
            {
                CategoryID = product.CategoryID,
                Discontinued = product.Discontinued,
                Picture = product.Picture,
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                SupplierID = product.SupplierID,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder
            };
            return PartialView("_Edit", productVM);
        }

        [HttpPost]
        public ActionResult Edit(ProductVM entity)
        {
            var product = new Product
            {
                CategoryID = entity.CategoryID,
                Discontinued = entity.Discontinued,
                Picture = entity.Picture,
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                QuantityPerUnit = entity.QuantityPerUnit,
                ReorderLevel = entity.ReorderLevel,
                SupplierID = entity.SupplierID,
                UnitPrice = entity.UnitPrice,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder
            };
            return Json(new { value = _unit.Product.Update(product) });
        }
    }
}