using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///     Package is a class representing Package Metadata (i.e. Nuget) that is responsible for storing common
    ///     for all versions metadata (Name, Description and so on ...).
    ///     Package files are calculating on Package.Name + PackageVersion.Version + file.ext
    /// </summary>
    public class Package : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        
        public virtual IList<PackageVersion> Versions { get; set; }
    }
}