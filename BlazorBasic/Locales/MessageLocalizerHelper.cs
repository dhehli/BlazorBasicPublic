using Microsoft.Extensions.Localization;

public class MessageLocalizerHelper<T> : IMessageLocalizerHelper<T>
{
    private readonly IStringLocalizer<T> stringLocalizer;

    public MessageLocalizerHelper(IStringLocalizer<T> stringLocalizer)
    {
        this.stringLocalizer = stringLocalizer;
    }

    public string Localize(string message, IEnumerable<string>? arguments)
    {
        try
        {
            if (arguments?.Any() != true)
                return stringLocalizer[message];

            var localizedArguments = LocalizeMessageArguments(arguments).ToArray();
            return stringLocalizer[message, localizedArguments];
        }
        catch
        {
            return stringLocalizer[message];
        }
    }

    private IEnumerable<string> LocalizeMessageArguments(IEnumerable<string> arguments)
    {
        foreach (var argument in arguments)
        {
            // Try to get localization for "DisplayName:{argument}"
            var displayNameKey = $"DisplayName:{argument}";
            var localization = stringLocalizer[displayNameKey];

            if (!localization.ResourceNotFound)
            {
                yield return localization.Value;
            }
            else
            {
                // Fallback to original argument if no translation found
                yield return argument;
            }
        }
    }
}