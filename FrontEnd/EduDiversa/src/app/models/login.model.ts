export interface LoginRequest {
  usuarioId: string;
  password: string;
}

export interface LoginResponse {
  token: string;
}