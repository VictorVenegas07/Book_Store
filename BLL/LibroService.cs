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
        private readonly BookStoreContext context;
        public LibroService(BookStoreContext _context)
        {
            context = _context;
        }
        public async Task<GuardarLibroResponse> GuardarLibro(Libro libro)
        {
            try
            {
                if (context.Libros.Find(libro.IdLibro) != null)
                {
                    return new GuardarLibroResponse("No es posible guardar este libro porque ya existe");
                }
                    context.Libros.Add(libro);
                    await context.SaveChangesAsync();
                    return new GuardarLibroResponse(libro);
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
                if (context.Libros.Any())
                {
                    return new ConsultarLibrosResponse(context.Libros.ToList());
                }
                return new ConsultarLibrosResponse("No hay libros registrados");
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
                var libroBuscado = context.Libros.Find(idLibro);
                if (libroBuscado == null)
                {
                    return new GuardarLibroResponse("No es posible modificar este libro porque no existe");
                }
                libroBuscado.ModificarLibro(libroModificado);
                context.Libros.Update(libroBuscado);
                await context.SaveChangesAsync();
                return new GuardarLibroResponse(libroBuscado);
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
                var libroBuscado = context.Libros.Find(idLibro);
                if (libroBuscado == null)
                {
                    return new EliminarLibroResponse("No es posible modificar este libro porque no existe");
                }
                context.Libros.Remove(libroBuscado);
                await context.SaveChangesAsync();
                return new EliminarLibroResponse(libroBuscado,"Eliminado con exito");
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
