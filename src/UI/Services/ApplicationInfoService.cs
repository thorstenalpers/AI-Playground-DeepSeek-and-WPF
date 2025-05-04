using System.Diagnostics;
using System.Reflection;
using DeepSeek.WPF.UI.Contracts.Services;

namespace DeepSeek.WPF.UI.Services;

public class ApplicationInfoService : IApplicationInfoService
{
    public ApplicationInfoService()
    {
    }

    public Version GetVersion()
    {
        // Set the app version in DeepSeek.WPF > Properties > Package > PackageVersion
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var version = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
        return new Version(version);
    }
}
