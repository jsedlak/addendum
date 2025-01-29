using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Addendum;

internal class AddendumBuilder : IAddendumBuilder
{
    private const string DefaultCategory = "Uncategorized";

    private readonly IServiceCollection _serviceCollection;

    private readonly List<ComponentCategory> _componentCategories = new();
    private readonly List<Type> _renderingProviders = new();

    internal AddendumBuilder(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public void Build()
    {
        _serviceCollection.AddScoped<IAddendumService>(sp =>
            new AddendumService(_componentCategories)
        );

        foreach(var providerType in _renderingProviders)
        {
            _serviceCollection.AddScoped(typeof(IRenderingProvider), providerType);
        }
    }

    public IAddendumBuilder WithAssembly(Assembly assembly)
    {
        var autoTypes = assembly.GetTypes()
            .Where(m => m.GetCustomAttribute<AutoDocAttribute>() is not null);

        Func<string, bool, ComponentCategory> getOrSetCategory = (__name, __isUncategorized) =>
        {
            var __cat = _componentCategories.FirstOrDefault(m => m.Name == __name);
            if (__cat is null)
            {
                __cat = new ComponentCategory
                {
                    Name = __name,
                    IsUntitledCategory = __isUncategorized
                };

                _componentCategories.Add(__cat);
            }

            return __cat;
        };

        foreach(var componentType in autoTypes)
        {
            var attr = componentType.GetCustomAttribute<AutoDocAttribute>()!;

            var category = getOrSetCategory(attr.Category ?? DefaultCategory, attr.Category == null);

            category.Components = [
                ..category.Components,
                new ComponentMetaData() {
                    Name = attr.Name ?? componentType.Name,
                    ComponentType = componentType.AssemblyQualifiedName!
                }
            ];
        }

        return this;
    }

    public IAddendumBuilder WithRenderingProvider<TProvider>() where TProvider : IRenderingProvider
    {
        _renderingProviders.Add(typeof(TProvider));

        return this;
    }
}
