using System.Text.Json.Serialization;

namespace Core
{
    public class Pelicula
    {

        public static Pelicula Reconstruir(int id, string titulo, string descripcion, string fehcaEstreno, string PosterPath)
        {
            return new Pelicula(id, titulo, descripcion, fehcaEstreno, PosterPath);
        }
        public Pelicula() { }

        [JsonConstructor]
        public Pelicula(
        int id,
        string titulo,
        string descripcion,
        string fechaEstreno,
        string imagen)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaEstreno = fechaEstreno;
            Imagen = imagen;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Titulo { get; set; }

        [JsonPropertyName("overview")]
        public string Descripcion { get; set; }

        [JsonPropertyName("release_date")]
        public string FechaEstreno { get; set; }

        [JsonPropertyName("poster_path")]
        public string Imagen { get; set; }
    }
}