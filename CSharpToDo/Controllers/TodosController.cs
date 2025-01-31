using CSharpToDo.Data;
using CSharpToDo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpToDo.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly DataContext _dbContext;

        public TodosController(ILogger<TodosController> logger, DataContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            var dummyTodos = _dbContext.Todos.ToListAsync();

            return Ok(dummyTodos);
        }

        [HttpPost]
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();

            return Ok(todo);
        }
    }
}
