using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///     This is a NuGet API Key, for version 1.0.0 we are going to use own db after 1.0 it should be possible to configure
    ///     and use Ferrum Authorization
    ///     Key could be generated via online tool https://emn178.github.io/online-tools/sha256.html
    /// </summary>
    public class ApiKey : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        ///    Todo: UMV use salt in the future ...
        /// </summary>
        public string KeyHash { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual PackageOwner Owner { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ExpiresAt { get; set; } // Опционально
        public bool IsActive { get; set; }
    }
}