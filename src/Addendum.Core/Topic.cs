namespace Addendum;

public class Topic
{
    public required string Name { get; set; }

    public IEnumerable<ComponentParameter> Parameters { get; set; } = [];
}
