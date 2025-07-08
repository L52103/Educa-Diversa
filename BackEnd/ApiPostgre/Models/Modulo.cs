using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models;

[Table("modulos", Schema = "public")]
public class Modulo
{
    [Key]
    [Column("codigo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

    [Column("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [Column("codigo_categoria")]
    public int CodigoCategoria { get; set; }

    [Column("vigencia")]
    public bool Vigencia { get; set; }

    [Column("valoracion")]
    public decimal Valoracion { get; set; }

    [JsonIgnore] public Categoria? Categoria { get; set; }
    [JsonIgnore] public ICollection<Multimedia>? Multimedia { get; set; }
    [JsonIgnore] public ICollection<Foro>? Foros { get; set; }
}