using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BookStoreContext: DbContext
    {
        private readonly Encrypt encrypt;
        public BookStoreContext(DbContextOptions contextOptions_) : base(contextOptions_)
        {
           encrypt = new Encrypt();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
               .HasData(new Usuario { IdUser = 1, Name = "Victor Venegas", User = "vvenegas", Password = encrypt.GetSHA256("12345"), Role = "Administrador" });
            modelBuilder.Entity<Libro>()
                .HasData( new Libro {IdLibro=1, Titulo = "The Monk Who Sold His Ferrari", Autor = "Robin Sharma", Publicador = "Jaiko Publishing House", Genero = "Fictions", Precio = 141 , IdUsuario = 1},
                        new Libro { IdLibro = 2,Titulo = "The Theory Of Everything", Autor = "Stiphen Hawking", Publicador = "Jaiko Publishing House", Genero = "Engineering And Technology", Precio = 149, IdUsuario = 1 },
                        new Libro { IdLibro = 3, Titulo = "Rich Dad Poor Dad", Autor = "Robert Kiyosaki", Publicador = "Plata publishing", Genero = "Personal finance", Precio = 288, IdUsuario = 1 }
                );
           
            
            modelBuilder.Entity<Libro>()
                .HasOne<Usuario>(l => l.Usuario)
                .WithMany(u => u.Libros)
                .HasForeignKey(l => l.IdUsuario);

            modelBuilder.Entity<Log>()
               .HasOne<Usuario>(l => l.Usuario)
               .WithMany(u => u.Logs)
               .HasForeignKey(l => l.IdUsuario);

        }

        

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs  { get; set; }
    }
}
