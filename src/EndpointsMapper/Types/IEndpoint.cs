using Microsoft.AspNetCore.Builder;

namespace EndpointsMapper.Types;

public interface IEndpoint
{
    void MapEndpoints(WebApplication app);
}
