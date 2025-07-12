using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json;
using Core;
using CSharpFunctionalExtensions;

namespace Repos;

public class BookRepo
{
    private static string querySearch ="?title=";
    private readonly HttpClient _httpClient;

    public BookRepo(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
    }

    public async Task<Result<Libro>> ObtenerLibro(string name)
    {
        string url = _httpClient.BaseAddress.ToString() + querySearch;
        
        
        string []elements=name.Split(" ");

        foreach (var element in elements)
        {
            if(element==elements[elements.Length-1])
            {
                url += element;
                break;
                
            }
            else
            {
                url += element + "+";   
            }
            
            
        }
        
        Console.WriteLine($"Complete Url:{url}");

        try
        {
            
        
        var response= await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var resultado = await response.Content
            .ReadFromJsonAsync<OpenLibrarySearchResult>(new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
        
        var doc = resultado?.Docs?.FirstOrDefault();
        if (doc == null)
            return Result.Failure<Libro>("No se encontró ningún libro con ese título");
        
        string imagenUrl = doc.CoverId.HasValue
            ? $"https://covers.openlibrary.org/b/id/{doc.CoverId}-L.jpg"
            : "";

        var descripcion = "";
        if (doc.FirstSentence is null)
        {
            var libro = Libro.Reconstruir(doc.Key, doc.Title,
                descripcion,
                doc.Authors.FirstOrDefault(), imagenUrl);
            return Result.Success(libro);    

        }
        else
        {
            
            var libro = Libro.Reconstruir(doc.Key, doc.Title,
                doc.FirstSentence.FirstOrDefault(),
                doc.Authors.FirstOrDefault(), imagenUrl);
        
            return Result.Success(libro); 
        }

      
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return Result.Failure<Libro>($"Fallo la conexion con la api");
        }
        

    }
}