using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; 

namespace ApiPostgre.Models
{
    public class Publicacion
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("fecha")]
        public DateTime Fecha { get; set; } 

        [Column("codigo_persona")]
        public int CodigoPersona { get; set; }

        [Column("codigo_foro")]
        public int CodigoForo { get; set; }

        [JsonIgnore]
        public Persona? Persona { get; set; }

        [JsonIgnore]
        public Foro? Foro { get; set; }
    }
}
