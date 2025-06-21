namespace ApiPostgre.Models
{
    public class PersonaMultimedia
    {
        public int CodigoPersona { get; set; }
        public int CodigoMultimedia { get; set; }
        public DateTime Fecha { get; set; }

        public Persona? Persona { get; set; }
        public Multimedia? Multimedia { get; set; }
    }
}
