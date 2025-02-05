namespace NetliveComponents.Models;

/// <summary>
/// Predefined set of contextual text colors.
/// </summary>
public record NetliveTextColor : Enumeration<NetliveTextColor>
{
    /// <inheritdoc/>
    public NetliveTextColor(string name) : base(name)
    {
    }

    /// <inheritdoc/>
    private NetliveTextColor(NetliveTextColor parent, string name) : base(parent, name)
    {
    }

    /// <summary>
    /// Creates the new custom text color based on the supplied enum value.
    /// </summary>
    /// <param name="name">Name value of the enum.</param>
    public static implicit operator NetliveTextColor(string name)
    {
        return new NetliveTextColor(name);
    }

    /// <summary>
    /// No color will be applied to an element, meaning it will appear as default to whatever current theme is set to.
    /// </summary>
    public static readonly NetliveTextColor Default = new((string)null);

    /// <summary>
    /// Primary color.
    /// </summary>
    public static readonly NetliveTextColor Primary = new("primary");

    /// <summary>
    /// Secondary color.
    /// </summary>
    public static readonly NetliveTextColor Secondary = new("secondary");

    /// <summary>
    /// Success color.
    /// </summary>
    public static readonly NetliveTextColor Success = new("success");

    /// <summary>
    /// Danger color.
    /// </summary>
    public static readonly NetliveTextColor Danger = new("danger");

    /// <summary>
    /// Warning color.
    /// </summary>
    public static readonly NetliveTextColor Warning = new("warning");

    /// <summary>
    /// Info color.
    /// </summary>
    public static readonly NetliveTextColor Info = new("info");

    /// <summary>
    /// Light color.
    /// </summary>
    public static readonly NetliveTextColor Light = new("light");

    /// <summary>
    /// Dark color.
    /// </summary>
    public static readonly NetliveTextColor Dark = new("dark");

    /// <summary>
    /// Body color.
    /// </summary>
    public static readonly NetliveTextColor Body = new("body");

    /// <summary>
    /// Muted color.
    /// </summary>
    public static readonly NetliveTextColor Muted = new("muted");

    /// <summary>
    /// White color.
    /// </summary>
    public static readonly NetliveTextColor White = new("white");

    /// <summary>
    /// Black text with 50% opacity on white background.
    /// </summary>
    public static readonly NetliveTextColor Black50 = new("black-50");

    /// <summary>
    /// White text with 50% opacity on black background.
    /// </summary>
    public static readonly NetliveTextColor White50 = new("white-50");
}