using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///     PackageVersion is a class representing every package changes and statistics (download, popularity)
    /// </summary>
    public class PackageVersion : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Guid PackageVersionStats { get; set; }
        public string Version { get; set; }
        public DateTimeOffset UploadedAt { get; set; }
        public string Summary { get; set; }
        
        public virtual Package Package { get; set; }
        public virtual PackageVersionStats Stats { get; set; }
    }
}