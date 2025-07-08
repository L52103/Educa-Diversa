import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Publicacion } from '../models/publicacion.model';
import { Foro } from '../models/foro.model'; 

@Injectable({
  providedIn: 'root'
})
export class ForoService {
  private apiUrl = 'http://localhost:5079';

  constructor(private http: HttpClient) { }

  // lista de todos los foros
  getForos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/foros`);
  }

  // creacion de un nuevo foro
  createForo(foro: Partial<Foro>): Observable<Foro> {
    return this.http.post<Foro>(`${this.apiUrl}/foros`, foro);
  }
  
  // obitnee publicaciones por foro
  getPublicacionesByForoId(foroId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/foros/${foroId}/publicaciones`);
  }
  // crea una publicacion
  createPublicacion(publicacion: Partial<Publicacion>): Observable<Publicacion> {
    return this.http.post<Publicacion>(`${this.apiUrl}/publicaciones`, publicacion);
  }
}