namespace Addendum;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AutoDocAttribute : Attribute
{
    public AutoDocAttribute()
    {

    }

    public AutoDocAttribute(string name, string categoryName)
    {
        Name = name;
        Category = categoryName;
    }

    public string? Name { get; set; }

    public string? Category { get; set; }
}
