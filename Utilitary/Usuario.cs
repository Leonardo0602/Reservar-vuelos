using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitary
{
    [Serializable]
    [Table("usuario", Schema = "usuarios_vuelos")]
    public class Usuario
    {
        private int id;
        private string correo;
        private string password;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("email")]
        public string Correo { get => correo; set => correo = value; }
        [Column("password")]
        public string Password { get => password; set => password = value; }
    }
}
