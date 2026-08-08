using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    public class Localization : IModelIdentifiable<string>
    {
        /// <summary>
        ///    Id here is an id plus a key that shows where this line is using, i.e. - package_publish_comment 
        /// </summary>
        public string Id { get; set; }
        
        public virtual IList<LocalizationString> Localizations { get; set; }
    }
}