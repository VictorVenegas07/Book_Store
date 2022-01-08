using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository
    {
        private readonly BookStoreContext context;
        public UsuarioRepository(BookStoreContext storeContext)
        {
            context = storeContext;
        }

        public Usuario BuscarUsuario(string user, string password)
        {
            return context.Usuarios.FirstOrDefault(u => u.User == user && u.Password == password);
        }

    }
}
