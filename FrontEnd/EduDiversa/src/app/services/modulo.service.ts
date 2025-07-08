import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Modulo } from '../models/modulo.model'; 

@Injectable({
  providedIn: 'root'
})
export class ModuloService {
  private apiUrl = 'http://localhost:5079/modulos';

  constructor(private http: HttpClient) { }

  getModulos(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getModuloById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  // --- MÉTODOS NUEVOS ---
  createModulo(modulo: Partial<Modulo>): Observable<Modulo> {
    return this.http.post<Modulo>(this.apiUrl, modulo);
  }

  updateModulo(id: number, modulo: Partial<Modulo>): Observable<Modulo> {
    return this.http.put<Modulo>(`${this.apiUrl}/${id}`, modulo);
  }

  deleteModulo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}