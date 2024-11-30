using EatLess.Application.Meals.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatLess.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ApiController
    {
        public MealController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public string Get() { return ""; }

        [HttpPost]
        public async Task<IActionResult> SaveMeal(CancellationToken cancellationToken)
        {
            var command = new CreateMealCommand("meal1", DateTime.Now);
            var result = await Sender.Send(command,cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
