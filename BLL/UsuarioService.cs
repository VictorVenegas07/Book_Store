using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly Encrypt encrypt;

        public UsuarioService(BookStoreContext _context)
        {
            usuarioRepository = new UsuarioRepository(_context);
            encrypt = new Encrypt();
        }

        public BuscarUsuarioResponse ValidarUsuario(string user, string password)
        {
            try
            {
                var usuario = usuarioRepository.BuscarUsuario(user, encrypt.GetSHA256(password));
                if (usuario == null)
                {
                    return new BuscarUsuarioResponse("Usuario no existe");
                }

                return new BuscarUsuarioResponse(usuario);
            }
            catch (Exception e)
            {

                return new BuscarUsuarioResponse("Ocurrio el siguiente error "+ e.Message);
            }
        }

    }
    public class BuscarUsuarioResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Usuario Usuario { get; set; }
        public BuscarUsuarioResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
        public BuscarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }


}

