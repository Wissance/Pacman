using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///     Tag is a class representing package category, i.e. REST, TCP, Socket and so on
    ///     This is class maps to the Dictionary table, and tags rows could be reused by other packages
    /// </summary>
    public class Tag : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}