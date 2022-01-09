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

        public async Task<Libro> Añadir(Libro libro)
        {
            using (context)
            { 
                context.Libros.Add(libro);
                await context.SaveChangesAsync();
                return libro;
            }
        }

        public async Task<Libro> Editar( Libro libroModificado)
        {
            using (context)
            {
                context.Libros.Update(libroModificado);
                await context.SaveChangesAsync();
                return libroModificado;
            }
        }

        public async Task<Libro> Eliminar(Libro libro)
        {
            using (context)
            {
                context.Libros.Remove(libro);
                await context.SaveChangesAsync();
                return libro;
            }
        }

        public async Task<Libro> BuscarLibro(int idLibro)
        {
                return await context.Libros.FindAsync(idLibro);
        }

        public List<Libro> ConsultarLibros()
        {
            using (context)
            {
                return context.Libros.ToList();
            };
        }
    }
}
