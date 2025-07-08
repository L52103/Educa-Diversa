export interface Foro {
  codigo?: number;           
  codigoPersona: number;    // Clave foranea a Persona (creador del foro)
  codigoModulo: number;     // Clave foranea a Modulo (módulo al que pertenece el foro)
  fecha: string;            // DateTime se mapea a string
  estado: string;           // texto (ej. "Abierto", "Cerrado")
}