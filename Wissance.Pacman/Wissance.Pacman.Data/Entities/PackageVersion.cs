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
        public Guid PackageVersionStatsId { get; set; }
        // Version in SemVer 2.0  format (i.e, "1.2.3-beta.1")
        public string Version { get; set; }
        
        public string Summary { get; set; }
        public string ReleaseNotes { get; set; }
        // Comma-separated line with authors, i.e.: "John Doe, Jane Smith"
        public string Authors { get; set; }  
        public string ProjectUrl { get; set; }
        public string LicenseUrl { get; set; }
        public string IconUrl { get; set; }
        public string RepositoryUrl { get; set; }
        // Type of repo "hg", "git", ....
        public string RepositoryType { get; set; }  
        // Size of .nupkg in bytes
        public long PackageSize { get; set; }
        // Hash value
        public string PackageHash { get; set; }
        // Hash type i.e, "SHA512"
        public string PackageHashAlgorithm { get; set; } 
        
        public bool IsListed { get; set; }
        public DateTimeOffset PublishedAt { get; set; }
        
        public virtual IList<PackageDependency> Dependencies { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual Package Package { get; set; }
        public virtual PackageVersionStats Stats { get; set; }
    }
}