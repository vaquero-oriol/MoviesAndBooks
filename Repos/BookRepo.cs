using System.Net.Http.Json;
using Core;
using CSharpFunctionalExtensions;

namespace Repos;

public class BookRepo
{
    private static string querySearch ="?title=";
    private readonly HttpClient _httpClient;

    private BookRepo(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
    }

    public async Task<Result<Libro>> ObtenerLibro(string name)
    {
        string url=_httpClient.BaseAddress.ToString();
        
        
        string []elements=name.Split(" ");

        foreach (var element in elements)
        {
            url += elements + "+";
            
        }
        
        Console.WriteLine($"Complete Url:{url}");

        try
        {
            
        
        var response= await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();


        var book = await response.Content.ReadFromJsonAsync<Libro>();

        if (book == null)
        {
            return Result.Failure<Libro>($"No se ha podido obtener el libro con nombre: {name}");
            
        }
        return Result.Success(book);    
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return Result.Failure<Libro>($"Fallo la conexion con la api");
        }
        

    }
}