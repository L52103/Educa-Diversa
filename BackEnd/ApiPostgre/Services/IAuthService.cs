using System.Threading.Tasks;
using ApiPostgre.Models;

namespace ApiPostgre.Services
{
    public class AuthResult
    {
        public required string Token { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public int CodigoPersona { get; set; }
    }

    public interface IAuthService
    {
        Task<AuthResult?> Authenticate(string usuarioId, string password);
        string HashPassword(string password);
    }
}