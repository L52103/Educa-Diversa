using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPostgre.Models
{
    public class Multimedia
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("formato")]
        public string Formato { get; set; } = string.Empty;

        [Column("url")]
        public string Url { get; set; } = string.Empty;

        [Column("codigo_modulo")] 
        public int CodigoModulo { get; set; }

        [Column("persona_creadora")] 
        public int PersonaCreadora { get; set; }

        [Column("vigencia")]
        public bool Vigencia { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        public Modulo? Modulo { get; set; }
        public Persona? Creador { get; set; }
        public ICollection<PersonaMultimedia>? PersonasRelacionadas { get; set; }
    }
}