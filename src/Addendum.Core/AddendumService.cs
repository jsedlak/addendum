namespace Addendum;

internal sealed class AddendumService : IAddendumService
{
    private IEnumerable<ComponentCategory> _componentCategories = [];

    internal AddendumService(IEnumerable<ComponentCategory> componentCategories)
    {
        _componentCategories = componentCategories;
    }

    public IEnumerable<ComponentCategory> GetCategories() => _componentCategories;
}
