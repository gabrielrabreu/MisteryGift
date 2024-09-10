using Bargile.MinimalApis.Extensions;
using Microsoft.AspNetCore.Mvc;
using MisteryGift.Authentication;

namespace MisteryGift.WebApi.Endpoints.Accounts;

public class SignUpRequest
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class SignUp : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Accounts/SignUp", HandleAsync)
            .WithOpenApi()
            .WithTags("Accounts")
            .ProducesOk<TokenDto>()
            .ProducesBadRequest();
    }

    private async Task<IResult> HandleAsync(
        [FromBody] SignUpRequest request,
        IAuthenticationService authenticationService,
        CancellationToken cancellationToken)
    {
        var result = await authenticationService.SignUp(request.Username, request.Email, request.Password);
        return result.ToMinimalApiResult();
    }
}
