using Core;
using CSharpFunctionalExtensions;
using Repos;

namespace App;

public class ObtainBookService
{
    private readonly BookRepo _repo;


    public ObtainBookService(BookRepo bookRepo)
    {
        _repo = bookRepo;
    }

    public async Task<Result<Libro>> ObtenerLibro(string name)
    {
        var libro = await _repo.ObtenerLibro(name);

        if (libro.IsFailure)
        {
            return Result.Failure<Libro>(libro.Error);
        }
        
        return libro;
    }
    
    
    
}