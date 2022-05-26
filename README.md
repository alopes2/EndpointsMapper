# EndpointsMapper

A simple package to assist you in organizing your endpoints for your minimal API.

To get started you just need a class implementing the interface IEndpoint.

```csharp
using EndpointsMapper.Core;

public class MyEndpoint : IEndpoint
{
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/hello-world", () => 
        {
            return "Hello World!";
        });
    }
}
```

Now you just need to add the registration in your startup class with:

* For mapping from the current project

```csharp
app.MapEndpoints();
```

* For mapping from the assembly of an specific type or types

```csharp
app.MapEndpoints(typeof(MarkerType));
```

`MarkerType` is a class where your endpoints are located.
Note that this method accepts multiple types.

* For mapping from an specifc assembly or assemblies

```csharp
app.MapEndpoints(assembly);
```

Where `assembly` is the assembly where your endpoints are defined.
