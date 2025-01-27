namespace Addendum;

public class ComponentMetaData
{
    public required string Name { get; set; }

    public required Type Component { get; set; }

    public IEnumerable<ComponentParameter> Parameters { get; set; } = [];
}
