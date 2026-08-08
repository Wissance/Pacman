using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    public class LocalizationString : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        /// <summary>
        ///    LanguageCode is 2 letter code i.e. ru, en, fr
        /// </summary>
        public string LanguageCode { get; set; }
        public string Text { get; set; }
        
        public string LocalizationId { get; set; }
        public virtual Localization Loc { get; set; }
    }
}