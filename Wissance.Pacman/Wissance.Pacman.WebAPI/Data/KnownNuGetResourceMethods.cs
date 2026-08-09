namespace Wissance.Pacman.WebAPI.Data
{
    public static class KnownNuGetResourceMethods
    {
        // 1. packages method
        public const string PackageMethodPath = "v3/package";
        // @type = Type from this field + method version
        public const string PackageMethodType = "PackageBaseAddress";
        public const string PackageMethodCommentKey = "package_method_comment";
        // 2. packages metadata
        public const string PackageMetadataMethodPath = "v3/package/metadata";
        public const string PackageMetadataMethodType = "RegistrationsBaseUrl";
        public const string PackageMetadataMethodCommentKey = "package_metadata_method_comment";
        // 3. search 
        public const string SearchMethodPath = "v3/package/search";
        public const string SearchMethodType = "SearchQueryService";
        // 4. search autocomplete
        public const string SearchAutocompleteMethodPath = "v3/package/search";
        public const string SearchAutocompleteMethodType = "SearchAutocompleteService";
        // publish package
        public const string PublishMethodPath = "v3/package/publish";
        public const string PublishMethodType = "PackagePublish";
        public const string PublishMethodCommentKey = "publish_method_comment";

        public const string InitialVersion = "3.0.0";
    }
}