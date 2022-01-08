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

        public void ModificarLibro(Libro libroModificado)
        {
            Titulo = libroModificado.Titulo;
            Autor = libroModificado.Autor;
            Publicador = libroModificado.Publicador;
            Genero = libroModificado.Genero;   
            Precio = libroModificado.Precio;
        }

        public Libro( string titulo, string autor, string publicador, string genero, double precio)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Publicador = publicador;
            this.Genero = genero;
            this.Precio = precio;
        }
        public Libro()
        {

        }


    }

   
}
