
export enum TipoUsuarioEnum {
  Admin = 0,
  Docente = 1,
  Familia = 2
}

export interface AuthResponse {
  token: string;
  tipoUsuario: TipoUsuarioEnum; // coincidir con 'tipoUsuario' del backend
}