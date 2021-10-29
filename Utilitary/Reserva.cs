using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitary
{
    [Serializable]
    [Table("reserva", Schema = "usuarios_vuelos")]
    public class Reserva
    {
        private int id;
        private int idUsuario;
        private int idVuelo;
        private string correo;
        private string nombre;
        private string origen;
        private string destino;
        private DateTime fecha_hora;


        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("id_usuario")]
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        [Column("id_vuelo")]
        public int IdVuelo { get => idVuelo; set => idVuelo = value; }
        [NotMapped]
        public string Correo { get => correo; set => correo = value; }
        [NotMapped]
        public string Nombre { get => nombre; set => nombre = value; }
        [NotMapped]
        public string Origen { get => origen; set => origen = value; }
        [NotMapped]
        public string Destino { get => destino; set => destino = value; }
        [NotMapped]
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
    }
}
