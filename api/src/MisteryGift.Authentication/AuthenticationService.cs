using Ardalis.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MisteryGift.Authentication;

public class AuthenticationService(UserManager<ApplicationUser> userManager, IOptions<AuthenticationSettings> authenticationSettings) : IAuthenticationService
{
    private readonly AuthenticationSettings _authenticationSettings = authenticationSettings.Value;

    public async Task<Result<TokenDto>> SignIn(string username, string password)
    {
        var user = await userManager.FindByNameAsync(username);

        if (user == null || !await userManager.CheckPasswordAsync(user, password))
        {
            return Result.Unauthorized();
        }

        return await CreateToken(user);
    }
    public async Task<Result<TokenDto>> SignUp(string username, string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email
        };

        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return Result.Invalid(result.AsErrors());
        }

        return await CreateToken(user);
    }

    private async Task<TokenDto> CreateToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName!)
        };

        var roles = await userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.SecretKey));

        var accessToken = new JwtSecurityToken(
            issuer: _authenticationSettings.Issuer,
            audience: _authenticationSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_authenticationSettings.AccessTokenValidityInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new TokenDto(new JwtSecurityTokenHandler().WriteToken(accessToken), user.UserName!, user.Email!);
    }
}
