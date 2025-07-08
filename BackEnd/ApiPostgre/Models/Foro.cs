using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models;

[Table("foro", Schema = "public")]
public class Foro
{
    [Key]
    [Column("codigo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

    [Column("codigo_persona")]
    public int CodigoPersona { get; set; }

    [Column("codigo_modulo")]
    public int CodigoModulo { get; set; }

    [Column("fecha")]
    public DateTime Fecha { get; set; }

    [Column("estado")]
    public string Estado { get; set; } = string.Empty;

    [JsonIgnore] public Persona? Persona { get; set; }
    [JsonIgnore] public Modulo? Modulo { get; set; }
    [JsonIgnore] public ICollection<Publicacion>? Publicaciones { get; set; }
}
