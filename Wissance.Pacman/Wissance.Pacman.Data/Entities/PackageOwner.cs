using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///    This class represents a package owner : user or organization, on this stage Owner is not related to login
    /// </summary>
    public class PackageOwner: IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        // Name is a virtual user Name (i.e. EvilLord666) or Organization (i.e. Wissance LLC)
        public string Name { get; set; }
        public bool IsOrganization { get; set; }
        // Additional non-sql structured data, i.e. JSON
        public string AdditionalInfo { get; set; }
    }
}