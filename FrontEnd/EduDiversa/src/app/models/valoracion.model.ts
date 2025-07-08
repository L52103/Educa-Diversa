export interface Valoracion {
  codigoValoracion?: number; 
  codigoPersona: number;    // FK Persona
  tipo: string;             
}