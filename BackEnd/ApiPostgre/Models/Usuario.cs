using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BCryptNet = BCrypt.Net.BCrypt;      

namespace ApiPostgre.Models
{
    public enum TipoUsuarioEnum { Admin, Docente, Familia }

    [Table("usuarios", Schema = "public")]
    public class Usuario
    {
        [Key]
        [Column("usuario")]
        public required string UsuarioId { get; set; }

        [Column("codigo_persona")]
        public int CodigoPersona { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CodigoPersona))]
        public Persona? Persona { get; set; }

        [Required]
        [Column("contrasena_hash")]
        public string ContrasenaHash { get; private set; } = string.Empty;

        [Column("tipo_usuario")]
        public TipoUsuarioEnum TipoUsuario { get; set; }

        [NotMapped]
        public string? Contrasena
        {
            private get => null;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    ContrasenaHash = BCryptNet.HashPassword(value);   
            }
        }

        public bool VerificarContrasena(string intento)
            => BCryptNet.Verify(intento, ContrasenaHash);            
    }
}
