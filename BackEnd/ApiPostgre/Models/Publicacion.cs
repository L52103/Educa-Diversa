using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Publicacion
    {
        [Key]
        public int Codigo { get; set; }  // Clave primaria

        public string Descripcion { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public int CodigoPersona { get; set; }

        public int CodigoForo { get; set; }

        public Persona? Persona { get; set; }
        public Foro? Foro { get; set; }
    }
}
