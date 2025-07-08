using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPostgre.Models
{
    public class PersonaMultimedia
    {
        [Column("codigo_persona")] 
        public int CodigoPersona { get; set; }

        [Column("codigo_multimedia")] 
        public int CodigoMultimedia { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        public Persona? Persona { get; set; }
        public Multimedia? Multimedia { get; set; }
    }
}