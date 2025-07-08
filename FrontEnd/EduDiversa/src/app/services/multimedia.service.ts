import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Multimedia } from '../models/multimedia.model';

@Injectable({
  providedIn: 'root'
})
export class MultimediaService {
  private apiUrl = 'http://localhost:5079';

  constructor(private http: HttpClient) { }

  getMultimediaForModule(moduleId: number): Observable<Multimedia[]> {
    return this.http.get<Multimedia[]>(`${this.apiUrl}/modulos/${moduleId}/multimedia`);
  }

  createMultimedia(media: Partial<Multimedia>): Observable<Multimedia> {
    return this.http.post<Multimedia>(`${this.apiUrl}/multimedia`, media);
  }

  updateMultimedia(id: number, media: Partial<Multimedia>): Observable<Multimedia> {
    return this.http.put<Multimedia>(`${this.apiUrl}/multimedia/${id}`, media);
  }

  deleteMultimedia(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/multimedia/${id}`);
  }
}