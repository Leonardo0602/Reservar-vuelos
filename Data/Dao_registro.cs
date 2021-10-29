using System.Collections.Generic;
using System.Linq;
using Utilitary;
using Utilitary.DTO;

namespace Data
{
   
    public class Dao_registro
    {
        Mapeo database = new Mapeo();

        public bool RegistroUsuario(Usuario usuario) 
        {
            if (usuario != null)
            {
                database.Usuarios.Add(usuario);
                database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool BuscarRegistroUsuarioxEmail(Dto_usuario usuario)
        {
            Usuario user = database.Usuarios.Where(x => x.Correo.Equals(usuario.Correo)).FirstOrDefault();

            if (user != null )
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool iniciarSesion(Dto_usuario usuario) 
        {
            var user = database.Usuarios.Where(x => x.Correo.Equals(usuario.Correo) && x.Password.Equals(usuario.Clave)).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public bool RegistrarVuelo(Vuelo vuelo)
        {   
            database.Vuelos.Add(vuelo);
            database.SaveChanges();
            return true;
        }

        public Vuelo BuscarRegistroVuelo(Dto_vuelo viaje)
        {
            Vuelo vuelo = database.Vuelos.Where(x => x.Nombre == viaje.Nombre.ToLower() 
                                                && x.Origen == viaje.Origen.ToLower() && x.Destino == viaje.Destino.ToLower() 
                                                && x.Fecha_hora == viaje.Fecha_hora).FirstOrDefault();

            return vuelo;
        }

        public bool RegistrarReserva(int idUser, int idVuelo) 
        {
            Reserva reserva = new Reserva();
            reserva.IdUsuario = idUser;
            reserva.IdVuelo = idVuelo;

            database.Reservas.Add(reserva);
            database.SaveChanges();
            return true;
        }

        public List<Reserva> BuscarReservaxIdUser(int idUser) 
        {
            var reserves = (from r in database.Reservas
                            join u in database.Usuarios on r.IdUsuario equals u.Id
                            join v in database.Vuelos on r.IdVuelo equals v.Id
                            where r.IdUsuario == idUser

                            select new
                            {
                                r,
                                u.Correo,
                                v.Nombre,
                                v.Origen,
                                v.Destino,
                                v.Fecha_hora

                            }).ToList().Select(x => new Reserva {

                                IdUsuario = x.r.IdUsuario,
                                IdVuelo = x.r.IdVuelo,
                                Correo = x.Correo,
                                Nombre = x.Nombre,
                                Origen = x.Origen,
                                Destino = x.Destino,
                                Fecha_hora = x.Fecha_hora

                            }).OrderBy(x => x.Fecha_hora).ToList();

            return reserves;
        }
    }
}
