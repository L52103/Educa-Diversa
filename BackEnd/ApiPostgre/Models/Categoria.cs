using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ApiPostgre.Models
{
    public class Categoria
    {
        [Key] 
        [Column("codigo")] 
        public int Codigo { get; set; }

        [Column("descripcion")] 
        public string? Descripcion { get; set; } 

        [Column("vigencia")] 
        public bool Vigencia { get; set; }

        
        public ICollection<Modulo>? Modulos { get; set; } 
    }
}