using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public int IdUser { get; set; }
        public string User { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public List<Libro> Libros { get; set; }
        public List<Log> Logs { get; set; }
    }
}
