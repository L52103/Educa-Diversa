import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, tap } from 'rxjs';
import { LoginRequest } from '../models/login.model';
import { AuthResponse } from '../models/auth-response.model';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5079/';

  private _userType = new BehaviorSubject<string | null>(null);
  userType$ = this._userType.asObservable();

  constructor(private http: HttpClient) {
    const storedType = localStorage.getItem('userType');
    if (storedType) this._userType.next(storedType);
  }

  login(request: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.apiUrl}login`, request)  
      .pipe(
        tap(res => {
          localStorage.setItem('token', res.token);
          localStorage.setItem('userType', res.tipoUsuario);
          localStorage.setItem('codigoPersona', res.codigoPersona.toString());
          this._userType.next(res.tipoUsuario);
        })
      );
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('userType');
    localStorage.removeItem('codigoPersona');
    this._userType.next(null);
  }

  getToken(): string | null       { return localStorage.getItem('token'); }
  getUserType(): string | null    { return this._userType.value; }
  getCodigoPersona(): number | null {
    const codigo = localStorage.getItem('codigoPersona');
    return codigo ? +codigo : null;
  }
}
