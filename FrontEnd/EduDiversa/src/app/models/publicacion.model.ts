export interface Publicacion {
  codigo?: number;          
  descripcion: string;      // Contenido de la publicacion
  fecha: string;            // DateTime a string 
  codigoPersona: number;
  codigoForo: number;
}