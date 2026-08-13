using Wissance.Pacman.Data;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.WebAPI.Data;

namespace Wissance.Pacman.WebAPI.Initializer
{
    public static class DataInitializer
    {
        public static void Init(PacmanDbContext dbContext, bool isDevelopment)
        {
            InitResources(dbContext);
            if (isDevelopment)
            {
                InitAdminPackageOwner(dbContext);
            }
        }

        private static void InitResources(PacmanDbContext dbContext)
        {
            bool saveRequired = false;
            if (!dbContext.Resources.Any(m => string.Equals(m.Path, KnownNuGetResourceMethods.PackageMethodPath)))
            {
                ResourceMetadata packagesMethod = new ResourceMetadata()
                {
                    Path = KnownNuGetResourceMethods.PackageMethodPath,
                    Type = KnownNuGetResourceMethods.PackageMethodType,
                    Version = KnownNuGetResourceMethods.InitialVersion,
                    Comment = new Localization()
                    {
                        Id = KnownNuGetResourceMethods.PackageMethodCommentKey,
                        Localizations = new List<LocalizationString>()
                        {
                            new LocalizationString()
                            {
                                LanguageCode = "en",
                                Text = "Method for getting package files (.nupkg, .nuspec)"
                            },
                            new LocalizationString()
                            {
                                LanguageCode = "ru",
                                Text = "Метод для скачивания файлов пакетов (.nupkg, .nuspec)"
                            }
                        }
                    }
                };
                dbContext.Resources.Add(packagesMethod);
                saveRequired = true;
            }
            
            if (!dbContext.Resources.Any(m => string.Equals(m.Path, KnownNuGetResourceMethods.PackageMetadataMethodPath)))
            {
                ResourceMetadata packageMetadataMethod = new ResourceMetadata()
                {
                    Path = KnownNuGetResourceMethods.PackageMetadataMethodPath,
                    Type = KnownNuGetResourceMethods.PackageMetadataMethodType,
                    Version = KnownNuGetResourceMethods.InitialVersion,
                    Comment = new Localization()
                    {
                        Id = KnownNuGetResourceMethods.PackageMetadataMethodCommentKey,
                        Localizations = new List<LocalizationString>()
                        {
                            new LocalizationString()
                            {
                                LanguageCode = "en",
                                Text = "Method for getting package metadata (versions, dependancies)"
                            },
                            new LocalizationString()
                            {
                                LanguageCode = "ru",
                                Text = "Метод для получения метаданных пакетов (версии, зависисмости)"
                            }
                        }
                    }
                };
                dbContext.Resources.Add(packageMetadataMethod);
                saveRequired = true;
            }

            if (!dbContext.Resources.Any(m => string.Equals(m.Path, KnownNuGetResourceMethods.PublishMethodPath)))
            {
                ResourceMetadata publishMethod = new ResourceMetadata()
                {
                    Path = KnownNuGetResourceMethods.PublishMethodPath,
                    Type = KnownNuGetResourceMethods.PublishMethodType,
                    Version = KnownNuGetResourceMethods.InitialVersion,
                    Comment = new Localization()
                    {
                        Id = KnownNuGetResourceMethods.PublishMethodCommentKey,
                        Localizations = new List<LocalizationString>()
                        {
                            new LocalizationString()
                            {
                                LanguageCode = "en",
                                Text = "Method for package publish and unlist"
                            },
                            new LocalizationString()
                            {
                                LanguageCode = "ru",
                                Text = "Метод для публикации и удаления пакетов"
                            }
                        }
                    }
                };
                dbContext.Resources.Add(publishMethod);
                saveRequired = true;
            }

            if (!dbContext.Resources.Any(m => string.Equals(m.Type, KnownNuGetResourceMethods.SearchMethodType)))
            {
                ResourceMetadata searchMethod = new ResourceMetadata()
                {
                    Path = KnownNuGetResourceMethods.SearchMethodPath,
                    Type = KnownNuGetResourceMethods.SearchMethodType,
                    Version = KnownNuGetResourceMethods.InitialVersion,
                    Comment = new Localization()
                    {
                        Id = KnownNuGetResourceMethods.SearchMethodCommentKey,
                        Localizations = new List<LocalizationString>()
                        {
                            new LocalizationString()
                            {
                                LanguageCode = "en",
                                Text = "Method for package search by keywords"
                            },
                            new LocalizationString()
                            {
                                LanguageCode = "ru",
                                Text = "Метод для поиска пакетов по ключевым словам"
                            }
                        }
                    }
                };
                dbContext.Resources.Add(searchMethod);
                saveRequired = true;
            }
            
            if (!dbContext.Resources.Any(m => string.Equals(m.Type, KnownNuGetResourceMethods.SearchAutocompleteMethodType)))
            {
                ResourceMetadata searchAutocompletionMethod = new ResourceMetadata()
                {
                    Path = KnownNuGetResourceMethods.SearchAutocompleteMethodPath,
                    Type = KnownNuGetResourceMethods.SearchAutocompleteMethodType,
                    Version = KnownNuGetResourceMethods.InitialVersion,
                    Comment = new Localization()
                    {
                        Id = KnownNuGetResourceMethods.SearchAutocompleteMethodCommentKey,
                        Localizations = new List<LocalizationString>()
                        {
                            new LocalizationString()
                            {
                                LanguageCode = "en",
                                Text = "Method for package name autocompletion"
                            },
                            new LocalizationString()
                            {
                                LanguageCode = "ru",
                                Text = "Метод для автодополнения при вводе названия пакета"
                            }
                        }
                    }
                };
                dbContext.Resources.Add(searchAutocompletionMethod);
                saveRequired = true;
            }

            if (saveRequired)
                dbContext.SaveChanges();
        }

        // TODO(umv): this MUST be offed after 1.0 is released
        private static void InitAdminPackageOwner(PacmanDbContext dbContext)
        {
            if (!dbContext.PackageOwners.Any(p => p.Name == AdminPackageOwnerName))
            {
                PackageOwner admin = new PackageOwner()
                {
                    Name = AdminPackageOwnerName,
                    AdditionalInfo = "",
                    IsAdmin = true
                };
                dbContext.PackageOwners.Add(admin);
                dbContext.SaveChanges();
                // add key
                ApiKey adminApiKey = new ApiKey()
                {
                    Owner = admin,
                    IsActive = true,
                    // corresponds to wissance-pacman-test
                    KeyHash = "39340028fc9c0126cbdc7910650187f7490b00c5fa1f78a179ce69f967bb9117"
                };
                
                dbContext.ApiKeys.Add(adminApiKey);
                dbContext.SaveChanges();
            }
        }

        private const string AdminPackageOwnerName = "admin";
    }
}