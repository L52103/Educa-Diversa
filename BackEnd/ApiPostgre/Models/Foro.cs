using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Foro
    {
        [Key]
        public int Codigo { get; set; }  

        public int CodigoPersona { get; set; }
        public int CodigoModulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = string.Empty;

        public Persona? Persona { get; set; }
        public Modulo? Modulo { get; set; }
        public ICollection<Publicacion>? Publicaciones { get; set; }
    }
}
