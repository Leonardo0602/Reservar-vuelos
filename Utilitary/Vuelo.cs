using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitary
{
    [Serializable]
    [Table("vuelo", Schema ="usuarios_vuelos")]
    public class Vuelo
    {
        private int id;
        private string nombre;
        private string origen;
        private string destino;
        private DateTime fecha_hora;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("origen")]
        public string Origen { get => origen; set => origen = value; }
        [Column("destino")]
        public string Destino { get => destino; set => destino = value; }
        [Column("fecha/hora")]
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
    }
}
