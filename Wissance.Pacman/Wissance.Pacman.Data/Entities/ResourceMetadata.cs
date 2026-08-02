using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///    This class describes configured HTTP Endpoints
    /// </summary>
    public class ResourceMetadata: IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        ///     Path is a relative path to Endpoint, consider if were are starting our server on nuget.wissance.com
        ///     and method URL is https://pacman.example.com/v3/registration, therefore we store in path v3/registration,
        /// </summary>
        public string Path { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
    }
}