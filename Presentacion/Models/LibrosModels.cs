using Entity;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models
{
    public class LibroInputModels
    {
        [Required(ErrorMessage = "El Titulo es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El Autor es requerido")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "El Publicador es requerido")]
        public string Publicador { get; set; }
        [Required(ErrorMessage = "El Genero es requerido")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El Precio es requerido")]
        public double Precio { get; set; }
    }

    public class LibroViewModels : LibroInputModels
    {
        public int IdLibro { get; set; }
        public LibroViewModels(Libro libro)
        {   
            IdLibro = libro.IdLibro;
            Titulo = libro.Titulo;
            Autor = libro.Autor;
            Publicador = libro.Publicador;
            Genero = libro.Genero;
            Precio = libro.Precio;
        }
    }
}
