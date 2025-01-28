using System.Reflection;

namespace Addendum;

public interface IAddendumBuilder
{
    IAddendumBuilder WithAssembly(Assembly assembly);

    IAddendumBuilder WithRenderingProvider<TProvider>() where TProvider : IRenderingProvider;

    void Build();
}
