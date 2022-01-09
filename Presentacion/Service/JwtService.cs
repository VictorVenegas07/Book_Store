using Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentacion.Config;
using Presentacion.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL;

namespace Presentacion.Service
{
    public class JwtService
    {
        private readonly AppSetting _appSetting;
        public JwtService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public UsuarioViewModels GenerarToken(Usuario usuario)
        {
            if (usuario == null)
            {
                return null;
            }

            var response = new UsuarioViewModels(usuario);
            var tokenManejo = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Name),
                    new Claim(ClaimTypes.Role, usuario.Role.ToString()),
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenManejo.CreateToken(tokenDescriptor);
            response.Token = tokenManejo.WriteToken(token);
            return response;
        }

    }
}
