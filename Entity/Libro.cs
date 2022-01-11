using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Publicador { get; set; }
        public string Genero { get; set; }
        public double Precio { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Libro( string titulo,string autor, string publicador, string genero, double precio, int idUsuario)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Publicador = publicador;
            this.Genero = genero;
            this.Precio = precio;
            this.IdUsuario = idUsuario;
        }
        public Libro()
        {

        }


    }

   
}
