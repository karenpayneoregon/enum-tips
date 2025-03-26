using System.Reflection;

namespace WineToJsonApp.Classes;

/// <summary>
/// Provides utility methods for working with directories, including functionality
/// to retrieve project folder information and access assembly-related details.
/// </summary>
public static class DirectoryHelper
{

    /// <summary>
    /// Retrieves information about the current project folder by traversing the directory structure
    /// upwards until a folder containing a .csproj file is found.
    /// </summary>
    /// <param name="path">
    /// An optional path to start the search from. If <c>null</c>, the current working directory is used.
    /// </param>
    /// <returns>
    /// A <see cref="DirectoryInfo"/> object representing the project folder, or <c>null</c> if no project folder is found.
    /// </returns>
    public static DirectoryInfo GetProjectInfo(string path = null)
    {
        DirectoryInfo directory = new(path ?? Directory.GetCurrentDirectory());
        while (directory is not null && directory.GetFiles("*.csproj").Length == 0)
        {
            directory = directory.Parent;
        }

        return directory;

    }
    /// <summary>
    /// Gets the name of the currently executing assembly.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> representing the name of the assembly.
    /// </value>
    public static string AssemblyName => Assembly.GetExecutingAssembly().GetName().Name;
}