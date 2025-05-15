namespace App;

using Core;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Microsoft.Extensions.Configuration;
using Repos;
using System.Net.Http.Json;

public class TmbdService
{
    private readonly MovieRepo _movieRepo;
   
    public TmbdService(MovieRepo movierepo)
    {
        _movieRepo = movierepo;
    }

    public async Task<Result<Pelicula>> ObtenerPelicula(int id)
    {
        var pelicula= await _movieRepo.ObtenerPeliculaAsync(id);

        if (pelicula.IsFailure)
        {
            return Result.Failure<Pelicula>("No se ha podido obtener la pelicula");
        }
       
        return Result.Success(pelicula.Value);


    }
}