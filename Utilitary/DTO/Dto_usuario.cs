using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitary.DTO
{
    public class Dto_usuario
    {
        private string correo;
        private string clave;

        [Required(ErrorMessage = "El correo es un campo requerido para generar la solicitud")]
        public string Correo { get => correo; set => correo = value; }
        [Required(ErrorMessage = "La contraseña es un campo requerido para generar la solicitud")]
        public string Clave { get => clave; set => clave = value; }
    }
}
