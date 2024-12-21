using EatLess.Application.Meals.Commands.CreateMeal;
using EatLess.Application.Meals.Queries.GetMailById;
using EatLess.Application.Users.Commands.Login;
using EatLess.Application.ViewModels;
using EatLess.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace EatLess.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiController
    {
        public UserController(ISender sender) : base(sender)
        {
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody]LoginUserRequest request , CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.Email, request.Password);
            Result<string> result = await Sender.Send(command, cancellationToken);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
        
    }
}
