import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MovieServiceService {
  private apiUrl = 'https://localhost:7251/api/Movie';


  constructor(private http: HttpClient) {}

  getPelicula(id: number) {
    return this.http.get(`${this.apiUrl}/GetMovieById/${id}`);
  }
}
