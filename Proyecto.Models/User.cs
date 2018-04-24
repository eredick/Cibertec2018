using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class User
    {
        [ExplicitKey]
        public int Id { get; set; }
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}
