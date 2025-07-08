import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs'; 
import { Categoria } from '../models/categoria.model'; 

@Injectable({
  providedIn: 'root' 
})
export class CategoriaService {

  private apiUrl = 'http://localhost:5079'; 

  constructor(private http: HttpClient) { } // inyecta el servicio HttpClient

  /** 
    Obtiene todas las categorías de la API.
  */

  getCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${this.apiUrl}/categorias`);
  }

  /**
    Obtiene una categoría específica por su código.
  */
  getCategoriaById(id: number): Observable<Categoria> {
    return this.http.get<Categoria>(`${this.apiUrl}/categorias/${id}`);
  }

  /**
   Crea una nueva categoría en la API.
  */

  createCategoria(categoria: Categoria): Observable<Categoria> {
    // Se envia el objeto categoria al endpoint /categorias
    return this.http.post<Categoria>(`${this.apiUrl}/categorias`, categoria);
  }

  /**
   Actualiza una categoría existente en la API.
  */

  updateCategoria(id: number, categoria: Categoria): Observable<Categoria> {
    // El ID se pasa en la URL, y el objeto categoria completo en el cuerpo de la petición.
    return this.http.put<Categoria>(`${this.apiUrl}/categorias/${id}`, categoria);
  }

  /**
   Elimina una categoría de la API.
  */
  deleteCategoria(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/categorias/${id}`);
  }
}