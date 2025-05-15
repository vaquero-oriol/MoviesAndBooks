import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MovieServiceService } from './services/movie-service.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  pelicula: any; 
readonly TMDB_IMAGE_BASE_URL = 'https://image.tmdb.org/t/p/w500';

  constructor(private http: HttpClient, private peliculaService: MovieServiceService) {}

  ngOnInit() {
    this.getPelicula(950387);
  }

  getPelicula(id: number): void {
    this.peliculaService.getPelicula(id).subscribe({
      next: (data) => {
        this.pelicula = data;
            this.pelicula.posterUrl = `${this.TMDB_IMAGE_BASE_URL}${this.pelicula.poster_path}`;

        console.log("Datos de la película:", this.pelicula);
      },
      error: (error) => {
        console.error("Error al obtener la película:", error);
      }
    });
  }

  title = 'weread.client';
}
