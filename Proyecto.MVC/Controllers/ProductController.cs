using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        //public byte[] imgChange = null;

        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductsPaged(ProductVM entity, int start, int end)
        {
            var lProducts = _unit.Product.GetProducstPaged(entity, start, end);
            var count = _unit.Product.CountProductsPaged(entity);
            return Json(new { lProducts, count });
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.cmbSupplier = _unit.Supplier.GetList();
            ViewBag.cmbCategory = _unit.Categories.GetList();
            return PartialView("_Create");
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

            Session["imgChange"] = null;
            ViewBag.cmbSupplier = _unit.Supplier.GetList();
            ViewBag.cmbCategory = _unit.Categories.GetList();

            return PartialView("_Edit", productVM);
        }

        [HttpPost]
        public ActionResult Edit(ProductVM entity)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    CategoryID = entity.CategoryID,
                    Discontinued = entity.Discontinued,
                    ProductID = entity.ProductID,
                    ProductName = entity.ProductName,
                    QuantityPerUnit = entity.QuantityPerUnit,
                    ReorderLevel = entity.ReorderLevel,
                    SupplierID = entity.SupplierID,
                    UnitPrice = entity.UnitPrice,
                    UnitsInStock = entity.UnitsInStock,
                    UnitsOnOrder = entity.UnitsOnOrder
                };

                if (Session["imgChange"] != null)
                {
                    product.Picture = (byte[])Session["imgChange"];
                }

                _unit.Product.Update(product);
            }
            return Json(new { option = "edit" });
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
            var myFile = Request.Files["imgFile"];

            using (var binaryReader = new BinaryReader(myFile.InputStream))
            {
                Session["imgChange"] = binaryReader.ReadBytes(myFile.ContentLength);
            }

            return Json(new { option = "complete!" });
        }
    }
}