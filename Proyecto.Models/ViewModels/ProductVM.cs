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
        [Display(Name = "Proveedor")]
        public int SupplierID { get; set; }
        [Display(Name = "Categoria")]
        public int CategoryID { get; set; }
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
        [Display(Name = "Descontinuado")]
        public bool Discontinued { get; set; }
    }
}
