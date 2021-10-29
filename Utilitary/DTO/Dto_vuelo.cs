using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitary.DTO
{
    public class Dto_vuelo
    {
        private string nombre;
        private string origen;
        private string destino;
        private DateTime fecha_hora;

        [Required(ErrorMessage = "El nombre del vuelo es requerido")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required(ErrorMessage = "El origen es requerido")]
        public string Origen { get => origen; set => origen = value; }

        [Required(ErrorMessage = "El destino es requerido")]
        public string Destino { get => destino; set => destino = value; }

        [Required(ErrorMessage = "El fecha y hora es requerido")]
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
    }
}
