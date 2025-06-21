using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Valoracion
    {
        [Key]
        public int CodigoValoracion { get; set; }  // clave primaria

        public int CodigoPersona { get; set; }

        public string Tipo { get; set; } = string.Empty; // tu enum como string o enum C#

        public Persona? Persona { get; set; }
    }
}

