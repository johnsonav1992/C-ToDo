using CSharpToDo.Models;
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
            var dummyTodos = new List<Todo>
            {
                new ()
                {
                    Title = "A Todo",
                    Description = "A Description",
                    IsCompleted = false
                }
            };

            return Ok(dummyTodos);
        }
    }
}
