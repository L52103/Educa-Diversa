using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPostgre.Models
{
    public class Modulo
    {
        [Key]
        public int Codigo { get; set; }
        
        public string Descripcion { get; set; } = string.Empty;
        
        public int CodigoCategoria { get; set; }
        
        public bool Vigencia { get; set; }
        
        public decimal Valoracion { get; set; }
        
        public Categoria? Categoria { get; set; }
        
        public ICollection<Multimedia>? Multimedia { get; set; }
        
        public ICollection<Foro>? Foros { get; set; }
    }
}
