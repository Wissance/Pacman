using Wissance.Pacman.Data;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.WebAPI.Data;

namespace Wissance.Pacman.WebAPI.Initializer
{
    public static class DataInitializer
    {
        public static void Init(PacmanDbContext dbContext)
        {
            InitResources(dbContext);
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
                        Id = KnownNuGetResourceMethods.PackageMetadataMethodPath,
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

            if (saveRequired)
                dbContext.SaveChanges();
        }
    }
}