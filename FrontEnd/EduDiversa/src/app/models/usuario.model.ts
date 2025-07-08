export enum TipoUsuarioEnum {
  admin = 0,
  personal = 1,
  normal = 2
}

export interface Usuario {
  usuarioId: string; 
  correo: string;
  contrasena: string;
  tipoUsuario: TipoUsuarioEnum; 
  codigoPersona: number;
  vigencia: boolean;
}
