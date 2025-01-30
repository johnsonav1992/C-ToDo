using Microsoft.AspNetCore.Mvc;

namespace CSharpToDo.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok("Sup!!");
        }
    }
}