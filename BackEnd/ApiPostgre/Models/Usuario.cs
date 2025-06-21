namespace ApiPostgre.Models
{
    public enum TipoUsuarioEnum
    {
        admin,
        personal,
        normal
    }

    public class Usuario
    {
        public string UsuarioId { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public int CodigoPersona { get; set; }
        public bool Vigencia { get; set; }

        public Persona? Persona { get; set; }
    }
}