// Services/AuthService.cs
using ApiPostgre.Data;
using ApiPostgre.Models; // Asegúrate de que este using esté presente si AuthResult está en Models
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Threading.Tasks; // Asegúrate de que este using esté presente

namespace ApiPostgre.Services
{
    // Si AuthResult está en un archivo separado (ej. Models/AuthResult.cs),
    // asegúrate de que el using ApiPostgre.Models esté arriba.
    // Si la definiste aquí mismo en este archivo, déjala.
    // public class AuthResult // Si AuthResult no está en Models ni en IAuthService.cs
    // {
    //     public string Token { get; set; }
    //     public TipoUsuarioEnum TipoUsuario { get; set; }
    // }


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

        // El método Authenticate debe coincidir con la interfaz, devolviendo AuthResult?
        public async Task<AuthResult?> Authenticate(string usuarioId, string password)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);

            if (user == null)
            {
                return null; // Usuario no encontrado
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.ContrasenaHash))
            {
                // Devolvemos el token y el TipoUsuario
                return new AuthResult
                {
                    Token = "dummy-jwt-token-para-usuario-" + user.UsuarioId,
                    TipoUsuario = user.TipoUsuario
                };
            }

            return null; // Contraseña incorrecta
        }
    }
}