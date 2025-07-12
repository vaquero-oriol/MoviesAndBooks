import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovieServiceService {
  private apiUrl = 'https://localhost:7251/api/Book';


  constructor(private http: HttpClient) {}

  getPelicula(name: string) {
    return this.http.get(`${this.apiUrl}/GetBookByName/${name}`);
  }
}
