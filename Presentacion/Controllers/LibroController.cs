using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentacion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroService libroService;
        public LibroController(BookStoreContext bookStoreDb)
        {
            libroService = new LibroService(bookStoreDb);
        }
        // GET: api/<LibroController>
        [HttpGet]
        public ActionResult<IEnumerable<LibroViewModels>> Get()
        {
            var response = libroService.ConsultarLibros();
            if (response.Error == true)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Libros.Select(e => new LibroViewModels(e)));
            
        }

        // POST api/<LibroController>
        [HttpPost]
        public async Task<ActionResult<LibroViewModels>> Post(LibroInputModels libroInput)
        {
            var respuesta = await libroService.GuardarLibro(MapearLibro(libroInput));
            if (respuesta.Error)
            {
                ModelState.AddModelError("Guardar Libro", respuesta.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(respuesta.Libro);

        }

        private Libro MapearLibro(LibroInputModels libroInput)
        {
            var libro = new Libro
            {
                Titulo = libroInput.Titulo,
                Genero = libroInput.Genero,
                Autor = libroInput.Autor,
                Precio = libroInput.Precio,
                Publicador = libroInput.Publicador
            };
            return libro;
        }

        // PUT api/<LibroController>/5
        [HttpPut("{idLibro}")]
        public async Task<ActionResult<LibroViewModels>> Put(int idLibro,LibroInputModels libroInput)
        {
            var respuesta = await libroService.ModificarLibro(idLibro,MapearLibro(libroInput));
            if (respuesta.Error)
            {
                ModelState.AddModelError("Modificar libro", respuesta.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(new LibroViewModels(respuesta.Libro));
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LibroViewModels>> Delete(int id)
        {
            var respuesta = await libroService.EliminarLibro(id);
            if (respuesta.Error)
            {
                ModelState.AddModelError("Eliminar libro", respuesta.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(respuesta.Libro);
        }
    }
}
