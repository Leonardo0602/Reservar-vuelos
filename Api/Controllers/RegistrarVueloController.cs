using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitary.DTO;

namespace Api.Controllers
{
    [RoutePrefix("api/registrar")]
    public class RegistrarVueloController : ApiController
    {
        [HttpGet]
        [Route("vuelo")]
        [AllowAnonymous]
        // HttpGet api/<controller>
        public IHttpActionResult RegistrarVuelo(Dto_vuelo vuelo)
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
                return Ok(new LRegistro().registrarVuelo(vuelo));
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