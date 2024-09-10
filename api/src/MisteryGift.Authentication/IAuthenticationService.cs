using Ardalis.Result;

namespace MisteryGift.Authentication;

public interface IAuthenticationService
{
    Task<Result<TokenDto>> SignIn(string username, string password);
    Task<Result<TokenDto>> SignUp(string username, string email, string password);
}
