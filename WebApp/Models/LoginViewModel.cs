using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginViewModel
    {
        [Required]
        public required string Nombre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Contrasenia { get; set; }
    }
}
