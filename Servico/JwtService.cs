using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Servico
{
    public class JwtService
    {
        private string _key;

        public JwtService(IConfiguration configuration)
        {
            _key = configuration.GetSection("Jwt")["Key"];
        }

        public string GerarTokenUsuario(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim("Id", usuario.Id),
                    new Claim("Nome", usuario.Nome),
                    new Claim("Email", usuario.Email),
                },
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: credentials
            );

            // Gerar o token como uma string compactada
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }     
    }
}