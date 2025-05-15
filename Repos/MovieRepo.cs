using Core;
using CSharpFunctionalExtensions;
using System.Net.Http;
using System.Net.Http.Json;

namespace Repos
{
    public class MovieRepo
    {
        private readonly HttpClient _httpClient;

        public MovieRepo( HttpClient httpClient)  
        {
            _httpClient = httpClient;

        }
        public async Task<Result<Pelicula>> ObtenerPeliculaAsync(int id)
        {
            try
            {
                Console.WriteLine($" URL completa: {_httpClient.BaseAddress}movie/{id}");

                var response = await _httpClient.GetAsync($"movie/{id}");
                response.EnsureSuccessStatusCode();

                var movie = await response.Content.ReadFromJsonAsync<Pelicula>();

                if (movie == null)
                {
                    return Result.Failure<Pelicula>("No se ha podido obtener ");
                }
                return Result.Success(movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Result.Failure<Pelicula>("Error al obtener la película");
            }
        }

    }
}
