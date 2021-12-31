using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Presentacion.Config;
using Presentacion.Models;
using Presentacion.Service;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentacion.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService usuarioService;
        private readonly JwtService jwtService;

        public UsuarioController(BookStoreContext bookStoreDb, IOptions<AppSetting> appSetting)
        {
            jwtService = new JwtService(appSetting);
            usuarioService = new UsuarioService(bookStoreDb);
            
        }
        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<UsuarioViewModels> Post(UsuarioInputModels usuarioInput)
        {
            var response = usuarioService.ValidarUsuario(usuarioInput.User, usuarioInput.Password);
            if (response.Error == true)
            {
                ModelState.AddModelError("Usuario no valido", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var respuesta = jwtService.GenerarToken(response.Usuario);
            return Ok(respuesta);
        }
    }
}
