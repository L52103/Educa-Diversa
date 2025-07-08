// Services/IAuthService.cs
using System.Threading.Tasks;
using ApiPostgre.Models;

namespace ApiPostgre.Services
{
    // Definimos una clase para el resultado de la autenticación
    // Esta definición debería estar aquí o en un archivo Models/AuthResult.cs
    // Si ya la tienes en AuthService.cs, puedes dejarla allí, pero para claridad,
    // la incluyo aquí temporalmente si es la única forma de que compiles.
    // Lo ideal es que AuthResult sea un archivo Models/AuthResult.cs
    public class AuthResult
    {
        public required string Token { get; set; } 
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }

    public interface IAuthService
    {
        // El método Authenticate ahora devuelve AuthResult?
        Task<AuthResult?> Authenticate(string usuarioId, string password);
        string HashPassword(string password);
    }
}