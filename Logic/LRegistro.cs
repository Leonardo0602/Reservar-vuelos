using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitary;
using Utilitary.DTO;

namespace Logic
{
    public class LRegistro
    {
        public Mensaje RegistroUser(Dto_usuario user) 
        {
            bool verificarEmail =  new Dao_registro().BuscarRegistroUsuarioxEmail(user);
            Mensaje alerta = new Mensaje();

            if (verificarEmail != true)
            {
                Usuario usuario = new Usuario();
                usuario.Correo = user.Correo;
                usuario.Password = user.Clave;

                new Dao_registro().RegistroUsuario(usuario);
                alerta.Respuesta = "Registrado";
            }
            else
            {
                alerta.Respuesta = "Correo ya resgistrado por favor ingrese otro";
            }

            return alerta;
        }

        public Mensaje iniciarSesionUser(Dto_usuario usuario) 
        {
            bool alerta = new Dao_registro().iniciarSesion(usuario);
            Mensaje respuesta = new Mensaje();
            if (alerta != true)
            {
                respuesta.Respuesta = "Cedenciales incorrectar o no se encuentra registrado"; 
            }
            else 
            {
                respuesta.Respuesta = "Bienvenido "+usuario.Correo+" a su perfil";
            }

            return respuesta;
        }

        public Mensaje registrarVuelo(Dto_vuelo vuelo) 
        {
            Vuelo flight = new Dao_registro().BuscarRegistroVuelo(vuelo);
            Mensaje alerta = new Mensaje();

            if (flight != null)
            {
                DateTime fechaFound = new DateTime();
                fechaFound = DateTime.Parse(flight.Fecha_hora.ToString());

                DateTime fechaVuelo = new DateTime();
                fechaVuelo = DateTime.Parse(vuelo.Fecha_hora.ToString());

                var hora = fechaFound < fechaVuelo && ((fechaVuelo - fechaFound).TotalHours > 2) ? true :
                    fechaFound > fechaVuelo && ((fechaFound - fechaVuelo).TotalHours > 2) ? true : false;

                if (hora == true)
                {
                    alerta = new LRegistro().registrarVuelo(vuelo);
                }
                else 
                {
                    alerta.Respuesta = "Lo sentimos el vuelo no cumple con las dos horas de anticipacion entre origen y destino";
                }

            }
            else 
            {
                alerta = new LRegistro().registrarVuelo(vuelo);
            }

            return alerta;
        }
    }
}
