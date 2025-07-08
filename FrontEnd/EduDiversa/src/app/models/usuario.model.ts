export enum TipoUsuarioEnum {
  Admin = 0,
  Docente = 1,
  Familia = 2
}

export interface Usuario {
  usuarioId: string; 
  correo: string;
  contrasena: string;
  tipoUsuario: TipoUsuarioEnum; 
  codigoPersona: number;
  vigencia: boolean;
}
