using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LibroRepository
    {
        private readonly BookStoreContext context;
        public LibroRepository(BookStoreContext context_)
        {
            context = context_;
        }

        public async Task<Libro> GuardarLirbo(Libro libro)
        {
            context.Libros.Add(libro);
            await context.SaveChangesAsync();
            return libro;
        }

        public async Task<Libro> ModificarLibro(int idLibro, Libro libroModificado)
        {
            var libroBuscado = context.Libros.Find(idLibro);
            libroBuscado.ModificarLibro(libroModificado);
            context.Libros.Update(libroBuscado);
            await context.SaveChangesAsync();
            return libroBuscado;
        }

        public async Task<Libro> EliminarLibro(int idLibro)
        {
            var libroBuscado = context.Libros.Find(idLibro);
            context.Libros.Remove(libroBuscado);
            await context.SaveChangesAsync();
            return libroBuscado;
        }

        public Boolean BuscarLibro(int idLibro)
        {
            return context.Libros.Any(l => l.IdLibro == idLibro);
        }

        public List<Libro> ConsultarLibros()
        {
            return context.Libros.ToList();
        }
    }
}
