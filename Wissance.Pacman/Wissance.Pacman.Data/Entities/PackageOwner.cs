using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    public class PackageOwner: IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsOrganization { get; set; }
        // Additional non-sql structured data, i.e. JSON
        public string AdditionalInfo { get; set; }
    }
}