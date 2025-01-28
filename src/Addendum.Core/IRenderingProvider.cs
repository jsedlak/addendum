using Microsoft.AspNetCore.Components;

namespace Addendum;

public interface IRenderingProvider
{
    bool CanRender(Type componentType, string parameterName);

    RenderFragment GetRendering(Type componentType, string parameterName);
}
