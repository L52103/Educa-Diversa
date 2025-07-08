using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPostgre.Models
{
    public class Persona
    {
        [Key]
        [Column("codigo")] 
        public int Codigo { get; set; }

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
        public bool Vigencia { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Multimedia>? MultimediaCreadas { get; set; }
        public ICollection<PersonaMultimedia>? MultimediaRelacionadas { get; set; }
        public ICollection<Valoracion>? Valoraciones { get; set; }
        public ICollection<Foro>? Foros { get; set; }
        public ICollection<Publicacion>? Publicaciones { get; set; }
    }
}