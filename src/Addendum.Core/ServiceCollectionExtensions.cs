using Microsoft.Extensions.DependencyInjection;

namespace Addendum;

public static class ServiceCollectionExtensions
{
    public static IAddendumBuilder AddAddendum(this IServiceCollection services)
    {
        return new AddendumBuilder(services);
    }
}