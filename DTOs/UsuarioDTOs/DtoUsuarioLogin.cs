using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UsuarioDTOs
{
    public class DtoUsuarioLogin
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo ingresado no es valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Se pide una contraseña")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe de tener al menos 6 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!]).{6,}$",
     ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación (.,;!).")]
        public string Password { get; set; }
        public string Rol {  get; set; }

        public int IdUsuario { get; set; }
        
    }
}
