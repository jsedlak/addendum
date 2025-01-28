namespace Addendum;

public sealed class ComponentCategory
{
    public required string Name { get; set; }

    public IEnumerable<ComponentMetaData> Components { get; set; } = [];

    public bool IsUntitledCategory { get; set; }
}
