using System.Text.Json.Serialization;

namespace Wissance.Pacman.Dto
{
    public class ServiceIndexDto
    {
        public ServiceIndexDto()
        {
            Resources = new List<ResourceMetadataDto>();
        }

        [JsonPropertyName("version")]
        public string Version { get; set; }
        
        [JsonPropertyName("resources")] 
        public IList<ResourceMetadataDto> Resources { get; set; }
    }
}