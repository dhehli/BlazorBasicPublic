using Microsoft.Extensions.Localization;

public interface IMessageLocalizerHelper<T>
{
    /// <summary>
    /// Localizes a message with optional arguments
    /// </summary>
    /// <param name="message">The message key to localize</param>
    /// <param name="arguments">Optional arguments to be localized and inserted into the message</param>
    /// <returns>The localized string</returns>
    string Localize(string message, IEnumerable<string>? arguments);
}