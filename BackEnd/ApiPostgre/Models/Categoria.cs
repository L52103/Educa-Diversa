using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo { get; set; }
        
        public string Descripcion { get; set; } = string.Empty;
        
        public bool Vigencia { get; set; }

        public ICollection<Modulo>? Modulos { get; set; }
    }
}
