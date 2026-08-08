namespace Wissance.Pacman.WebAPI.Data
{
    public static class KnownNuGetResourceMethods
    {
        // 1. packages method
        public const string PackageMethodPath = "v3/package";
        // @type = Type from this field + method version
        public const string PackageMethodType = "PackageBaseAddress";
        // localizable str with Id = 1
        //public const string PackageMethodComment = "#1";
        // 2. packages metadata
        public const string PackageMetadataMethodPath = "v3/package/metadata";
        public const string PackageMetadataMethodType = "RegistrationsBaseUrl";
        // localizable str with Id = 2
        //public const string PackageMetadataMethodComment = "#2";
        // 3. search 
        public const string SearchMethodPath = "v3/package/search";
        public const string SearchMethodType = "SearchQueryService";
        // localizable str with Id = 3
        //public const string SearchMethodComment = "#3";
        // 4. search autocomplete
        public const string SearchAutocompleteMethodPath = "v3/package/search";
        public const string SearchAutocompleteMethodType = "SearchAutocompleteService";
        //localizable str with Id = 4
        //public const string SearchAutocompleteMethodComment = "#4";
        // publish package
        public const string PublishMethodPath = "v3/package/publish";
        public const string PublishMethodType = "SearchAutocompleteService";
        //localizable str with Id = 4
        //public const string PublishMethodComment = "#4";
    }
}