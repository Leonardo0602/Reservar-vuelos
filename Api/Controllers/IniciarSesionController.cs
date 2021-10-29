using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitary;
using Utilitary.DTO;

namespace Api.Controllers
{
    [RoutePrefix("api/iniciarSesion")]
    public class IniciarSesionController : ApiController
    {
        [HttpGet]
        [Route("usuario")]
        [AllowAnonymous]
        // GET api/<controller>

        public IHttpActionResult IniciarSesionUser(Dto_usuario user)
        {
            string error = "Los datos son incorrectos, por favor verifique.";

            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $"{item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                return Ok(new LRegistro().iniciarSesionUser(user));
            }
            catch (Exception ex)
            {
                error = $"¡Ups!, se presento un error al manejar su solicitud. Error: {ex.Message}";
                var HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(error, System.Text.Encoding.UTF8, "text/plain")
                };
                return ResponseMessage(HttpResponseMessage);
            }
        }
    }
}