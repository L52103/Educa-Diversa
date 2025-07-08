using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models
{
    [Table("multimedia", Schema = "public")]
    public class Multimedia
    {
        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Column("codigo_modulo")]
        public int CodigoModulo { get; set; }

        [Column("persona_creadora")]
        public int PersonaCreadora { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("formato")]
        public string? Formato { get; set; }

        [Column("url")]
        public string? Url { get; set; }

        [Column("vigencia")]
        public bool Vigencia { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CodigoModulo))]
        public Modulo? Modulo { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PersonaCreadora))]
        public Persona? Creador { get; set; }

        [JsonIgnore]
        public ICollection<PersonaMultimedia>? PersonasRelacionadas { get; set; }
    }
}
