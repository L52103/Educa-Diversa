import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap } from 'rxjs'; 
import { LoginRequest } from '../models/login.model';
import { AuthResponse, TipoUsuarioEnum } from '../models/auth-response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5079'; 

  
  private _userType = new BehaviorSubject<TipoUsuarioEnum | null>(null);
  userType$ = this._userType.asObservable(); // Observable para que los componentes se suscriban

  constructor(private http: HttpClient) {
    // Intentar cargar el tipo de usuario del localStorage al iniciar el servicio
    const storedUserType = localStorage.getItem('userType');
    if (storedUserType) {
      this._userType.next(TipoUsuarioEnum[storedUserType as keyof typeof TipoUsuarioEnum]);
    }
  }

  // Modifica el metodo login para que devuelva AuthResponse
  login(request: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, request).pipe(
      tap(response => {
        // Almacenar el token y el tipo de usuario en localStorage
        localStorage.setItem('token', response.token);
        localStorage.setItem('userType', TipoUsuarioEnum[response.tipoUsuario]); // Guardar como string del enum
        this._userType.next(response.tipoUsuario); 
      })
    );
  }

  // Metodo para cerrar sesión
  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('userType');
    this._userType.next(null); // Limpiar el tipo de usuario al cerrar sesión
  }

  // Obtiene token 
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  // obtener el tipo de usuario
  getUserType(): TipoUsuarioEnum | null {
    return this._userType.value;
  }
}