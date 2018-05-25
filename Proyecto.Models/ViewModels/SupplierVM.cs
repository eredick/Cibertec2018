using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models.ViewModels
{
    public class SupplierVM
    {
        public int SupplierID { get; set; }
        [Required]
        [Display(Name = "Comapañía")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Nombre del Contacto")]
        public string ContactName { get; set; }
        [Display(Name = "Puesto del Contacto")]
        public string ContactTitle { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [Display(Name = "Región")]
        public string Region { get; set; }
        [Display(Name = "Código Postal")]
        public string PostalCode { get; set; }
        [Display(Name = "País")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Display(Name = "Página Web")]
        public string HomePage { get; set; }
    }
}
