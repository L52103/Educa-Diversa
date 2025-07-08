export interface Modulo {
  codigo?: number;           
  descripcion: string;
  codigoCategoria: number;  // Clave foranea a Categoria
  vigencia: boolean;
  valoracion: number;       // decimal a number
}