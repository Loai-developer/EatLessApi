using EatLess.Application.Meals.Commands;
using EatLess.Application.ViewModels;
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

        [HttpPost]
        public async Task<IActionResult> SaveMeal(MealVM vm, CancellationToken cancellationToken)
        {
            var command = new CreateMealCommand(vm);
            var result = await Sender.Send(command,cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }


    }
}
