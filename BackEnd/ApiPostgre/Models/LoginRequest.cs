namespace ApiPostgre.Models
{
    public class LoginRequest
    {
        public string UsuarioId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}