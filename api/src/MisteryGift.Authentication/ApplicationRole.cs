using Microsoft.AspNetCore.Identity;

namespace MisteryGift.Authentication;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole()
    {
    }
};