using System.Text.Json.Serialization;

namespace Wissance.Pacman.Dto
{
    /// <summary>
    ///    Dto representing available endpoints
    ///    {
    ///        "@id": "https://pacman.example.com/v3/package-content",
    ///        "@type": "PackageBaseAddress/3.0.0",
    ///        "comment": "Для скачивания .nupkg и .nuspec файлов"
    ///    }
    /// </summary>
    public class ResourceMetadataDto
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }
        [JsonPropertyName("@type")]
        public string Type { get; set; }
        [JsonPropertyName("comment")]
        public string Comment { get; set; } 
    }
}