using Microsoft.AspNetCore.Mvc;

namespace EatLess.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {

        [HttpGet]
        public string Get() { return ""; }
    }
}
