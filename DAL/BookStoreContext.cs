using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BookStoreContext: DbContext
    {
        public BookStoreContext(DbContextOptions contextOptions_) : base(contextOptions_)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasData( new Libro {IdLibro=1, Titulo = "The Monk Who Sold His Ferrari", Autor = "Robin Sharma", Publicador = "Jaiko Publishing House", Genero = "Fictions", Precio = 141 },
                        new Libro { IdLibro = 2,Titulo = "The Theory Of Everything", Autor = "Stiphen Hawking", Publicador = "Jaiko Publishing House", Genero = "Engineering And Technology", Precio = 149 },
                        new Libro { IdLibro = 3, Titulo = "Rich Dad Poor Dad", Autor = "Robert Kiyosaki", Publicador = "Plata publishing", Genero = "Personal finance", Precio = 288 }
                );
            modelBuilder.Entity<Usuario>()
                .HasData(new Usuario { Name = "Victor Venegas", User = "vvenegas", Password = "12345", Role = "Administrador" });
        }

        

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
