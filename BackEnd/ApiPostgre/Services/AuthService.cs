using ApiPostgre.Data;
using ApiPostgre.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiPostgre.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<AuthResult?> Authenticate(string usuarioId, string password)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);

            if (user == null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.ContrasenaHash))
            {
                return new AuthResult
                {
                    Token = "dummy-jwt-token-para-usuario-" + user.UsuarioId,
                    TipoUsuario = user.TipoUsuario,
                    CodigoPersona = user.CodigoPersona
                };
            }

            return null;
        }
    }
}