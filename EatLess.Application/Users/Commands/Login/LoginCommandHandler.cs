using EatLess.Domain.Abstractions;
using EatLess.Domain.Abstractions.Messaging;
using EatLess.Domain.Shared;

namespace EatLess.Application.Users.Commands.Login
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IJwtProvider _jwtProvider;
        public LoginCommandHandler(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //Fetch the user from the DB

            // if(Member is null)


            //Generate JWT
            string Token = _jwtProvider.GetJwtToken("1", request.Email);

            return Token;
        }
    }
}
