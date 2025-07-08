using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models
{
    [Table("persona_multimedia", Schema = "public")]
    public class PersonaMultimedia
    {

        [Key]
        [Column("codigo_persona", Order = 0)]
        public int CodigoPersona { get; set; }

        [Key]
        [Column("codigo_multimedia", Order = 1)]
        public int CodigoMultimedia { get; set; }


        [Column("fecha")]
        public DateTime Fecha { get; set; }


        [JsonIgnore]
        [ForeignKey(nameof(CodigoPersona))]
        public Persona? Persona { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CodigoMultimedia))]
        public Multimedia? Multimedia { get; set; }
    }
}
