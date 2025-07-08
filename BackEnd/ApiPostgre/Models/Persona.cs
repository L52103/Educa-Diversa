using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPostgre.Models;

[Table("personas", Schema = "public")]
public class Persona
{
    // ───────────────────────────────── Clave primaria
    [Key]
    [Column("codigo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }

    // ───────────────────────────────── Datos básicos
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Column("apellido_paterno")]
    public string ApellidoPaterno { get; set; } = string.Empty;

    [Column("apellido_materno")]
    public string ApellidoMaterno { get; set; } = string.Empty;

    [Column("fecha_nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Column("sexo")]
    public char Sexo { get; set; }

    [Column("rut")]
    public string Rut { get; set; } = string.Empty;

    [Column("vigencia")]
    public bool Vigencia { get; set; } = true;


    [JsonIgnore] public ICollection<Usuario>? Usuarios { get; set; }
    [JsonIgnore] public ICollection<Multimedia>? MultimediaCreadas { get; set; }
    [JsonIgnore] public ICollection<PersonaMultimedia>? MultimediaRelacionadas { get; set; }
    [JsonIgnore] public ICollection<Valoracion>? Valoraciones { get; set; }
    [JsonIgnore] public ICollection<Foro>? Foros { get; set; }
    [JsonIgnore] public ICollection<Publicacion>? Publicaciones { get; set; }
}
