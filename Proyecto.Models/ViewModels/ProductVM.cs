using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.ViewModels
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Producto")]
        public string ProductName { get; set; }
        [Display(Name = "Cod.Proveedor")]
        public int SupplierID { get; set; }
        [Display(Name = "Compañía")]
        public string CompanyName { get; set; }
        [Display(Name = "Cod.Categoria")]
        public int CategoryID { get; set; }
        [Display(Name = "Categoría")]
        public string CategoryName { get; set; }
        [Display(Name = "Cantidad Por Unidad")]
        public string QuantityPerUnit { get; set; }
        [Required]
        [Display(Name = "Precio Unitario")]
        public double UnitPrice { get; set; }
        [Display(Name = "En Stock")]
        public int UnitsInStock { get; set; }
        [Display(Name = "En Ordenes")]
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        [Display(Name = "Imagen")]
        public byte[] Picture { get; set; }
        [Display(Name = "Descontinuado")]
        public bool Discontinued { get; set; }
    }
}
