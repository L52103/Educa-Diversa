export interface Valoracion {
  codigoValoracion?: number; 
  codigoPersona: number;    // Clave foranea a Persona
  tipo: string;             // texto (ej. "Like", "Dislike")
}