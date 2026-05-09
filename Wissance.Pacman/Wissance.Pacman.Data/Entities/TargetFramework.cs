using Wissance.WebApiToolkit.Data.Entity;

namespace Wissance.Pacman.Data.Entities
{
    /// <summary>
    ///     TargetFramework represents required system .Net platform to use package,
    ///     this is a dictionary class with the following platforms: 
    ///     .NET 5+ (and .NET Core)       net5.0, net6.0, net7.0, net8.0, net9.0, net10.0.NET
    ///     Core 1.x - 3.1                netcoreapp1.0, netcoreapp2.1, netcoreapp3.1
    ///     .NET Standard                 netstandard1.0 through netstandard2.1
    ///     .NET Framework                net11, net20, net35, net40, net45, net462, net472, net48, net481
    ///      Windows Platform             uap10.0 (UWP), net8.0-windows
    ///      Mobile (Xamarin/MAUI)        net8.0-android, net8.0-ios, net8.0-maccatalyst
    /// </summary>
    public class TargetFramework : IModelIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        // framework name, i.e. net6.0, netcore3.1, full list will be added further, Probably there should be a enum here
        public string Name { get; set; }
    }
}