
namespace EatLess.Domain.Abstractions
{
    public interface IJwtProvider
    {
        string GetJwtToken(string UserId, string Email);
    }
}
