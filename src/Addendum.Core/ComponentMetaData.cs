namespace Addendum;

public class ComponentMetaData
{
    public required string Name { get; set; }

    public required string ComponentType { get; set; }

    public IEnumerable<ComponentParameter> Parameters { get; set; } = [];
}
