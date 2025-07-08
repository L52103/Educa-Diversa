export interface Persona {
  codigo?: number;           
  nombre: string;
  apellidoPaterno: string;
  apellidoMaterno: string;
  fechaNacimiento: string;  //  DateTime se mapea a string
  sexo: string;             // char de 1 carácter (ej "M", "F")
  rut: string;
  vigencia: boolean;
}