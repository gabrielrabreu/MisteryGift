using Bargile.MinimalApis.Extensions;
using Microsoft.AspNetCore.Mvc;
using MisteryGift.Authentication;

namespace MisteryGift.WebApi.Endpoints.Accounts;

public class SignInRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class SignIn : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Accounts/SignIn", HandleAsync)
            .WithOpenApi()
            .WithTags("Accounts")
            .ProducesOk<TokenDto>()
            .ProducesUnauthorized();
    }

    private async Task<IResult> HandleAsync(
        [FromBody] SignInRequest request,
        IAuthenticationService authenticationService,
        CancellationToken cancellationToken)
    {
        var result = await authenticationService.SignIn(request.Username, request.Password);
        return result.ToMinimalApiResult();
    }
}
