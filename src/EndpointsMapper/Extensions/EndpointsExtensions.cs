using System.Reflection;
using EndpointsMapper.Types;
using Microsoft.AspNetCore.Builder;

namespace EndpointsMapper.Extensions;

public static class EndpointsExtensions
{
    /// <summary>
    /// Map endpoints from the current executing assembly
    /// </summary>
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapEndpointsFromAssemblies(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Map endpoints from the assembly of the specified types
    /// </summary>
    /// <param name="types">Types located in the assembly where the endpoints are implemented</param>
    public static void MapEndpointsFromAssemblyContaining(this WebApplication app, params Type[] types)
    {
        // Get the assemblies from types and call MapEndpointsfromassemblies
        var assemblies = types.Select(t => t.Assembly).ToArray();
        app.MapEndpointsFromAssemblies(assemblies);
    }


    /// <summary>
    /// Map endpoints from the specified assemblies
    /// </summary>
    /// <param name="assemblies">Assemblies where the endpoints are implemented</param>
    public static void MapEndpointsFromAssemblies(this WebApplication app, params Assembly[] assemblies)
    {
        foreach(var assembly in assemblies)
        {
            var endpoints = assembly.DefinedTypes
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IEndpoint).IsAssignableFrom(t))
                .Select(t => Activator.CreateInstance(t))
                .Cast<IEndpoint>();

            foreach(var endpoint in endpoints)
            {
                endpoint.MapEndpoints(app);
            }
        }
    }
}
