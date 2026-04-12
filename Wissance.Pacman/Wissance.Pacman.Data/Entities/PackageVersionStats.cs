using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PackageVersionStats : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid PackageVersionId { get; set; }
        public long Downloads { get; set; }
        
        public virtual PackageVersion PackageVersion { get; set; }
    }
}