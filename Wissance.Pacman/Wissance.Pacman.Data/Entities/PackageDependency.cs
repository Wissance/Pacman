using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///     This class describes package dependencies that are required for the package to be used.
    /// </summary>
    public class PackageDependency : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        ///     Package base url, i.e.
        ///     - NuGet V3 (Recommended): https://api.nuget.org/v3/
        ///     - NuGet V2 (Legacy): https://www.nuget.org/api/v2/
        /// </summary>
        public string PackageRepo { get; set; }
        /// <summary>
        ///     PackageId stands for the package name; it could be either a package from nuget.org or another repo
        ///     i.e. "Wissance.WebApiToolkit.Core"
        /// </summary>
        public string PackageId { get; set; }
        /// <summary>
        ///     Minimal version in SemVer format, see https://semver.org/
        ///     Briefly version in the following formats:
        ///     - MAJOR.MINOR.PATCH (i.e. 1.2.16)
        ///     - MAJOR.MINOR.PATCH-stage (i.e. 1.0.0-beta, 1.1.9-rc.2)
        ///     Usually if MinVersion set and MaxVersion is not it means that exact version = MinVersion
        /// </summary>
        public string MinVersion { get; set; }
        /// <summary>
        ///     Maximal version in SemVer format
        /// </summary>
        public string MaxVersion { get; set; }
        public Guid TargetFrameworkId { get; set; }
        
        public virtual TargetFramework Framework { get; set; }
    }
}