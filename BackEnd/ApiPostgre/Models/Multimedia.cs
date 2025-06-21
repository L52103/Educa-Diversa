using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Multimedia
    {
        [Key]
        public int Codigo { get; set; }
        
        public string Nombre { get; set; } = string.Empty;
        
        public string Descripcion { get; set; } = string.Empty;
        
        public string Formato { get; set; } = string.Empty;
        
        public string Url { get; set; } = string.Empty;
        
        public int CodigoModulo { get; set; }
        
        public int PersonaCreadora { get; set; }
        
        public bool Vigencia { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public Modulo? Modulo { get; set; }
        
        public Persona? Creador { get; set; }
        
        public ICollection<PersonaMultimedia>? PersonasRelacionadas { get; set; }
    }
}
