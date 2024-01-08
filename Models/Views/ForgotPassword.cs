using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetIdentity.Models.Views
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        [DisplayName("Correo electronico")]
        [EmailAddress]
        public string Email { get; set; }
    }
}