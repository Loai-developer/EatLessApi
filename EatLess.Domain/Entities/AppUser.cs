using Microsoft.AspNetCore.Identity;

namespace EatLess.Domain.Entities
{
    public sealed class AppUser : IdentityUser
    {
        public int? Age { get; init; }
    }
}
