namespace Core;

public class Libro
{
    private Libro(long id, string titulo,string descripcion,string autor, string imagen)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Autor = autor;
        Imagen = imagen;
    }
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Autor { get; set; }
    public string Imagen { get; set; }
 
    
    
}