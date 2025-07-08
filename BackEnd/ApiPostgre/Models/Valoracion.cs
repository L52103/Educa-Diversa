using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPostgre.Models
{
    public class Valoracion
    {
        [Key]
        [Column("codigo_valoracion")] 
        public int CodigoValoracion { get; set; }

        [Column("codigo_persona")] 
        public int CodigoPersona { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        public Persona? Persona { get; set; }
    }
}