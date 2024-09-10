using Bargile.MinimalApis.Extensions;
using System.Security.Claims;

namespace MisteryGift.WebApi.Endpoints.Samples;

public class Anonymous : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/Samples/Anonymous", Handle)
            .WithOpenApi()
            .WithTags("Samples");
    }

    private IResult Handle(ClaimsPrincipal user)
    {
        var claims = user.Claims.Select(x => new { x.Type, x.Value });

        return TypedResults.Ok(new
        {
            user.Identity?.Name,
            claims
        });
    }
}
