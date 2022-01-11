using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }



    }
}
