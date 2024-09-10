using Ardalis.Result;
using Microsoft.AspNetCore.Identity;

namespace MisteryGift.Authentication;

public static class IdentityResultExtensions
{
    public static List<ValidationError> AsErrors(this IdentityResult identityResult)
    {
        var resultErrors = new List<ValidationError>();

        foreach (var error in identityResult.Errors)
        {
            resultErrors.Add(new ValidationError()
            {
                ErrorCode = error.Code,
                ErrorMessage = error.Description,
                Severity = ValidationSeverity.Error
            });
        }

        return resultErrors;
    }
}