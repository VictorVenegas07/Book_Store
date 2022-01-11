using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Log
    {
        [Key]
        public int IdLog { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Log()
        {
            Fecha = DateTime.Now;
        }

     }
    }

