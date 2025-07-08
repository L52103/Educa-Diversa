using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models
{
    [Table("publicacion", Schema = "public")]
    public class Publicacion
    {

        [Key]
        [Column("codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey(nameof(CodigoPersona))]
        public Persona? Persona { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CodigoForo))]
        public Foro? Foro { get; set; }
    }
}
