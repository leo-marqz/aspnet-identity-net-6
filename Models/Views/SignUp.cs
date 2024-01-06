
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPNetIdentity.Models.Views
{
    public class SignUp
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 5 y 50 caracteres", MinimumLength = 5)]
        [DisplayName("Nombre *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido debe tener entre 5 y 50 caracteres", MinimumLength = 5)]
        [DisplayName("Apellido *")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El correo electronico es requerido")]
        [DisplayName("Correo Electronico *")]
        [EmailAddress]
        public string Email { get; set; }

        [Url]
        [DisplayName("Sitio Web")]
        public string UrlWebSite { get; set; }

        [Required(ErrorMessage = "El numero de telefono es requerido")]
        [DisplayName("Telefono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Numero de telefono invalido")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El pais es requerido")]
        [StringLength(50, ErrorMessage = "El nombre de pais debe tener entre 3 y 50 caracteres", MinimumLength = 3)]
        [DisplayName("Pais *")]
        public string Country { get; set; }

        [Required(ErrorMessage = "El codigo de pais es requerido")]
        [StringLength(10, ErrorMessage = "El codigo de pais debe tener entre 2 y 10 caracteres", MinimumLength = 2)]
        [DisplayName("Codigo Pais *")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "La ciudad es requerida")]
        [StringLength(50, ErrorMessage = "El nombre de la ciudad debe tener entre 3 a 50 caracteres", MinimumLength = 3)]
        [DisplayName("Ciudad *")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "La direccion debe tener entre 5 a 50 caracteres", MinimumLength = 5)]
        [DisplayName("Direccion")]
        public string Address { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Nacimiento *")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DisplayName("Contraseña")]
        [StringLength(12, ErrorMessage = "El campo contraseña debe tener entre 4 y 12 caracteres", MinimumLength = 4)]
        [DataType(DataType.Password, ErrorMessage = "Contraseña invalida")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmacion de contraseña es requerido")]
        [DisplayName("Confirmar Contraseña")]
        [StringLength(12, ErrorMessage = "La confirmacion de contraseña debe tener entre 4 y 12 caracteres", MinimumLength = 4)]
        [Compare(nameof(Password), ErrorMessage = "La contraseña no es igual al valor en confirmacion de contraseña")]
        public string ConfirmPassword { get; set; }
    }
}