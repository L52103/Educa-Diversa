using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Persona
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string Rut { get; set; } = string.Empty;
        public bool Vigencia { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Multimedia>? MultimediaCreadas { get; set; }
        public ICollection<PersonaMultimedia>? MultimediaRelacionadas { get; set; }
        public ICollection<Valoracion>? Valoraciones { get; set; }
        public ICollection<Foro>? Foros { get; set; }
        public ICollection<Publicacion>? Publicaciones { get; set; }
    }
}
