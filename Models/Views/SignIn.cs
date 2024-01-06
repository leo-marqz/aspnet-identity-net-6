

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPNetIdentity.Models.Views
{
    public class SignIn
    {
        [Required(ErrorMessage = "El campo de correo electronico es requerido")]
        [DisplayName("Correo Electronico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo contraseña es requerido")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Recordar Datos ?")]
        public bool RememberMe { get; set; }
    }
}