using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CARPINTEC_App.Models;
using Microsoft.IdentityModel.Tokens;

namespace CARPINTEC_App.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarToken(Usuario usuario)
        {
            string clave = _configuration["Jwt:ClaveSecreta"]!;
            string emisor = _configuration["Jwt:Emisor"]!;
            string audiencia = _configuration["Jwt:Audiencia"]!;
            int minutos = int.Parse(_configuration["Jwt:MinutosVida"]!);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Correo ?? ""),
                new Claim(ClaimTypes.Role, usuario.Rol ?? "Usuario"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: emisor,
                audience: audiencia,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(minutos),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}