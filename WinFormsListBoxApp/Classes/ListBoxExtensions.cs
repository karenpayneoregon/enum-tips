namespace WinFormsListBoxApp.Classes;

using System.Windows.Forms;

/// <summary>
/// Provides extension methods for the <see cref="ListBox.ObjectCollection"/> class,
/// enabling additional functionality such as saving to and loading from files.
/// </summary>
/// <remarks>
/// No exception handling provided as each developer may have different requirements like, log or other actions.
/// </remarks>
public static class ListBoxExtensions
{
    /// <summary>
    /// Saves the contents of the <see cref="ListBox.ObjectCollection"/> to a specified file.
    /// </summary>
    /// <param name="sender">The <see cref="ListBox.ObjectCollection"/> containing the items to save.</param>
    /// <param name="fileName">The path of the file where the contents will be saved.</param>
    /// <remarks>
    /// Each item in the collection is written as a separate line in the file.
    /// </remarks>
    public static void SaveToFile(this ListBox.ObjectCollection sender, string fileName)
    {
        File.WriteAllLines(fileName, sender.Cast<string>().Select(line => line).ToArray());
    }

    /// <summary>
    /// Loads the contents of a specified file into the <see cref="ListBox.ObjectCollection"/>.
    /// </summary>
    /// <param name="sender">The <see cref="ListBox.ObjectCollection"/> where the file contents will be loaded.</param>
    /// <param name="fileName">The path of the file to load the contents from.</param>
    /// <remarks>
    /// If the specified file does not exist, the method does nothing.
    /// Each line in the file is added as a separate item in the collection.
    /// </remarks>
    public static void LoadFromFile(this ListBox.ObjectCollection sender, string fileName)
    {
        if (!File.Exists(fileName)) return;
        sender.Clear();
        sender.AddRange(File.ReadAllLines(fileName).Cast<object>().ToArray());
    }
}