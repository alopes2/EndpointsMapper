using Microsoft.AspNetCore.Builder;

namespace EndpointsMapper.Core.Types;

public interface IEndpoint
{
    void MapEndpoints(WebApplication app);
}
