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
        public LibroService(BookStoreContext _context)
        {
            libroRepository = new LibroRepository(_context);
        }
        public async Task<GuardarLibroResponse> GuardarLibro(Libro libro)
        {
            try
            {
                if (libroRepository.BuscarLibro(libro.IdLibro))
                {
                    return new GuardarLibroResponse("No es posible guardar este libro porque ya existe");
                }
                 return new GuardarLibroResponse(await libroRepository.GuardarLirbo(libro));
            }
            catch (Exception e)
            {
                return new GuardarLibroResponse("Se presento el siguiente error no se pudo guardar " + e.Message);
            }
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

        public async Task<GuardarLibroResponse> ModificarLibro(int idLibro ,Libro libroModificado)
        {
            try
            {
                if (!libroRepository.BuscarLibro(idLibro))
                {
                    return new GuardarLibroResponse("No es posible modificar este libro porque no existe");
                } 
                return new GuardarLibroResponse(await libroRepository.ModificarLibro(idLibro, libroModificado));
            }
            catch (Exception e)
            {
                return new GuardarLibroResponse("Se presento el siguiente error no se pudo guardar " + e.Message);
            }
        }

        public async Task<EliminarLibroResponse> EliminarLibro(int idLibro)
        {
            try
            {              
                if (!libroRepository.BuscarLibro(idLibro))
                {
                    return new EliminarLibroResponse("No es posible eliminar este libro porque no existe");
                }
                return new EliminarLibroResponse(await libroRepository.EliminarLibro(idLibro),"Eliminado con exito");
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
