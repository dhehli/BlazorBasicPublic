namespace BlazorBasic.Components.Layout;

public class NavItem
{
    public string Title { get; set; }
    public string IconName { get; set; }
    public string Link { get; set; }
    public List<NavItem> Children { get; set; } = new();
}