using Microsoft.AspNetCore.Mvc;

namespace CSharpToDo.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        // GET: api/todos
        [HttpGet]
        public IActionResult GetTodos()
        {
            // Implementation goes here
            return Ok();
        }
    }
}