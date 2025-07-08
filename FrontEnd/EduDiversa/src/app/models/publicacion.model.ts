export interface Publicacion {
  codigo?: number;          
  descripcion: string;      // Contenido de la publicacion
  fecha: string;            // DateTime a string 
  codigoPersona: number;    // Clave foranea a Persona (autor de la publicacion)
  codigoForo: number;       // Clave foranea a Foro (foro al que pertenece la publicacion)
}