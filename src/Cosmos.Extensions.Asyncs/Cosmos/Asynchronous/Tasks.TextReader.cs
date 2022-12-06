namespace Cosmos.Asynchronous;

/// <summary>
/// TextReader Extensions
/// </summary>
public static partial class TaskExtensions
{
    /// <summary>
    /// Get enumerable
    /// </summary>
    /// <param name="textReader"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<string> GetEnumerable(this TextReader textReader)
    {
        ArgumentNullException.ThrowIfNull(textReader);

        string line;

        while ((line = textReader.ReadLine()) != null)
            yield return line;
    }
}