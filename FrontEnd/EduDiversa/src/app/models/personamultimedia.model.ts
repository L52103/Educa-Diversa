export interface PersonaMultimedia {
  codigoPersona: number;    // clave primaria compuesta y clave foranea a Persona
  codigoMultimedia: number; // clave primaria compuesta y clave foranea a Multimedia
  fecha: string;            // DateTime a string 
}