using System.Text.Json.Serialization;

public class OpenLibrarySearchResult
{
    [JsonPropertyName("docs")]
    public List<OpenLibraryDoc> Docs { get; set; } = new();
}

public class OpenLibraryDoc
{
    [JsonPropertyName("key")]
    public string Key { get; set; } = "";

    [JsonPropertyName("title")]
    public string Title { get; set; } = "";

    [JsonPropertyName("author_name")]
    public List<string>? Authors { get; set; }

    [JsonPropertyName("first_sentence")]
    public List<string>? FirstSentence { get; set; }

    [JsonPropertyName("cover_i")]
    public int? CoverId { get; set; }
}