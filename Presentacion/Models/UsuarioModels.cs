using Entity;
using System.Text.Json.Serialization;

namespace Presentacion.Models
{
    public class UsuarioInputModels
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioViewModels:UsuarioInputModels
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public UsuarioViewModels(Usuario usuario)
        {
            User = usuario.User;
            Role = usuario.Role;
            Name = usuario.Name;
            Password = usuario.Password;

        }
    }
}
