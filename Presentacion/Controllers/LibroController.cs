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
                return BadRequest(response.Mensaje);
            return Ok(response.Libros.Select(e => new LibroViewModels(e)));
            
        }

        // POST api/<LibroController>
        [HttpPost]
        public async Task<ActionResult<LibroViewModels>> Post(LibroInputModels libroInput)
        {
            var respuesta = await libroService.GuardarLibro( new Libro(libroInput.Titulo, libroInput.Autor,
                libroInput.Publicador, libroInput.Genero, libroInput.Precio));
            if (respuesta.Error)
                return BadRequest(respuesta.Mensaje);
          
            return Ok(new LibroViewModels(respuesta.Libro));

        }


        // PUT api/<LibroController>/5
        [HttpPut("{idLibro}")]
        public async Task<ActionResult<LibroViewModels>> Put(int idLibro,LibroInputModels libroInput)
        {
            var respuesta = await libroService.ModificarLibro(idLibro, new Libro(libroInput.Titulo, libroInput.Autor,
                libroInput.Publicador, libroInput.Genero, libroInput.Precio));
            if (respuesta.Error)
                return BadRequest(respuesta.Mensaje);
            
            return Ok(new LibroViewModels(respuesta.Libro));
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LibroViewModels>> Delete(int id)
        {
            var respuesta = await libroService.EliminarLibro(id);
            if (respuesta.Error)
             return BadRequest(respuesta.Mensaje);
            
            return Ok(new LibroViewModels(respuesta.Libro));
        }
    }
}
