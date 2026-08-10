namespace Wissance.Pacman.WebAPI.Configuration
{
    public enum StorageType
    {
        Folder,
        S3AWS,
        S3CloudFlare,
        S3Yandex
    }
    /// <summary>
    ///    This configuration stores info about where to save Nuget package files, it could be:
    ///    1. Local folder
    ///    2. S3 cloud storage 
    /// </summary>
    public class StorageConfig
    {
        /// <summary>
        ///    Name of the source, required in IFileManager
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///    Type is a combined enum of Local folder and available S3 cloud services types
        /// </summary>
        public StorageType Type { get; set; }
        /// <summary>
        ///    Src represents for folder path to folder, for cloud S3 - Endpoint
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        ///    Credentials file is actual for S3 (Wissance.WebApiToolkit supports work with S3, but here it is reserved for
        ///    the future versions > 1.0, CredentialsFile is a JSON with AccessKey and SecretAccessKey properties
        /// </summary>
        public string CredentialsFile { get; set; }
    }
}