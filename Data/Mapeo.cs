using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitary;

namespace Data
{
    public class Mapeo :DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }

        public Mapeo() : base("name = Cadena_Conexion") { }

        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
