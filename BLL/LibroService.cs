using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class LibroService
    {
        private readonly LibroRepository libroRepository;
        private readonly LogRepository logRepository;
        public LibroService(BookStoreContext _context)
        {
            libroRepository = new LibroRepository(_context);
            logRepository = new LogRepository(_context);
        }
        public async Task<GuardarLibroResponse> GuardarLibro(LibroInputModels libroInput)
        {
            try
            {
                var libro = MapearLibro(libroInput);
                var libroBuscado = await libroRepository.BuscarLibro(libro.IdLibro);
                if (libroBuscado != null)
                {
                    return new GuardarLibroResponse("No es posible guardar este libro porque ya existe");
                }
                 return new GuardarLibroResponse(await libroRepository.Añadir(libro));
            }
            catch (Exception e)
            {
                return new GuardarLibroResponse("Se presento el siguiente error no se pudo guardar " + e.Message);
            }
            finally
            {
                var log = new Log { Accion = "Insert", IdUsuario = libroInput.IdUsuario };
                await logRepository.Agregar(log);
            }
        }

        private Libro MapearLibro(LibroInputModels libroInput)
        {
            return  new Libro(libroInput.Titulo, libroInput.Autor,
                libroInput.Publicador, libroInput.Genero, libroInput.Precio, libroInput.IdUsuario);
        }

        public ConsultarLibrosResponse ConsultarLibros()
        {
            try
            {
                return new ConsultarLibrosResponse(libroRepository.ConsultarLibros());
            }
            catch (Exception e)
            {
                return new ConsultarLibrosResponse("Se presento el siguiente error no se pudo guardar " + e.Message);
            }
        }

        public async Task<GuardarLibroResponse> ModificarLibro(int idLibro, LibroInputModels libroInput)
        {
            try
            {
                var libroBuscado = await libroRepository.BuscarLibro(idLibro);
                if (libroBuscado == null)
                {
                    return new GuardarLibroResponse("No es posible modificar este libro porque no existe");
                }

                return new GuardarLibroResponse(await libroRepository.Editar(MapearLibroBuscado(libroBuscado, libroInput)));
            }
            catch (Exception e)
            {
                return new GuardarLibroResponse("Se presento el siguiente error no se pudo guardar " + e.Message);
            }
        }

        private Libro MapearLibroBuscado(Libro libroBuscado, LibroInputModels libroInput)
        {
            libroBuscado.Autor = libroInput.Autor;
            libroBuscado.Titulo = libroInput.Titulo;
            libroBuscado.Genero = libroInput.Genero;
            libroBuscado.Precio = libroInput.Precio;
            libroBuscado.Publicador = libroInput.Publicador;
            return libroBuscado;
        }

        public async Task<EliminarLibroResponse> EliminarLibro(int idLibro)
        {
            try
            {
                var libroBuscado = await libroRepository.BuscarLibro(idLibro);
                if (libroBuscado == null)
                {
                    return new EliminarLibroResponse("No es posible eliminar este libro porque no existe");
                }
                return new EliminarLibroResponse(await libroRepository.Eliminar(libroBuscado),"Eliminado con exito");
            }
            catch (Exception e)
            {
                return new EliminarLibroResponse("Se presento el siguiente error no se pudo guardar " + e.Message);
            }
        }

    }

    public class GuardarLibroResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Libro Libro { get; set; }
        public GuardarLibroResponse(Libro libro)
        {
            Error = false;
            Libro = libro;
        }
        public GuardarLibroResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

    }

    public class ConsultarLibrosResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Libro> Libros{ get; set; }
        public ConsultarLibrosResponse(List<Libro> libros)
        {
            Error = false;
            Libros = libros;
        }
        public ConsultarLibrosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

    }

    public class EliminarLibroResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Libro Libro { get; set; }
        public EliminarLibroResponse(Libro libro, string mensaje)
        {
            Error = false;
            Mensaje= mensaje;
            Libro = libro;
        }
        public EliminarLibroResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

    }
}
