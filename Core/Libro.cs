namespace Core;

public class Libro
{
    
    
    public static Libro Reconstruir(string id, string titulo, string? descripcion, string autor, string imagen)
    {
        return new Libro(id, titulo, descripcion, autor, imagen);
    }

    private Libro(string id, string titulo,string? descripcion,string autor, string imagen)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Autor = autor;
        Imagen = imagen;
    }
    public string Id { get; set; }
    public string Titulo { get; set; }
    public string? Descripcion { get; set; }
    public string Autor { get; set; }
    public string Imagen { get; set; }
 
    
    
}