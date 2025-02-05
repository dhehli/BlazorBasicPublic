using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetliveComponents.Models;

/// <summary>
/// Predefined set of contextual colors for Netlive.
/// </summary>
public record NetliveColor : Enumeration<NetliveColor>
{
    /// <inheritdoc/>
    public NetliveColor(string name) : base(name)
    {
    }

    /// <inheritdoc/>
    private NetliveColor(NetliveColor parent, string name) : base(parent, name)
    {
    }

    /// <summary>
    /// Creates the new custom color based on the supplied enum value.
    /// </summary>
    /// <param name="name">Name value of the enum.</param>
    public static implicit operator NetliveColor(string name)
    {
        return new NetliveColor(name);
    }

    /// <summary>
    /// No color will be applied to an element, meaning it will appear as default to whatever current theme is set to.
    /// </summary>
    public static readonly NetliveColor Default = new(null);

    /// <summary>
    /// Primary color.
    /// </summary>
    public static readonly NetliveColor Primary = new("primary");

    /// <summary>
    /// Secondary color.
    /// </summary>
    public static readonly NetliveColor Secondary = new("secondary");

    /// <summary>
    /// Success color.
    /// </summary>
    public static readonly NetliveColor Success = new("success");

    /// <summary>
    /// Danger color.
    /// </summary>
    public static readonly NetliveColor Danger = new("danger");

    /// <summary>
    /// Warning color.
    /// </summary>
    public static readonly NetliveColor Warning = new("warning");

    /// <summary>
    /// Info color.
    /// </summary>
    public static readonly NetliveColor Info = new("info");

    /// <summary>
    /// Light color.
    /// </summary>
    public static readonly NetliveColor Light = new("light");

    /// <summary>
    /// Dark color.
    /// </summary>
    public static readonly NetliveColor Dark = new("dark");

    /// <summary>
    /// Link color.
    /// </summary>
    public static readonly NetliveColor Link = new("link");
}