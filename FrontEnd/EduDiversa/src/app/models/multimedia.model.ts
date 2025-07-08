export interface Multimedia {
  codigo?: number;          
  nombre: string;
  descripcion: string;
  formato: string;
  url: string;
  codigoModulo: number;     // Clave foranea a Modulo
  personaCreadora: number;  // Clave foranea a Persona (la que creó la multimedia)
  vigencia: boolean;
  fecha: string;            // DateTime a string 
}