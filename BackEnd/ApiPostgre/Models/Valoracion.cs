using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models
{
    [Table("valoraciones", Schema = "public")]
    public class Valoracion
    {

        [Key]
        [Column("codigo_valoracion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoValoracion { get; set; }


        [Column("codigo_persona")]
        public int CodigoPersona { get; set; }


        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;


        [JsonIgnore]
        [ForeignKey(nameof(CodigoPersona))]
        public Persona? Persona { get; set; }
    }
}
