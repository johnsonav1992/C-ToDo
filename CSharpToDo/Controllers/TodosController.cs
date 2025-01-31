using System.Threading.Tasks;
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
        public async Task<IActionResult> GetTodos()
        {
            var dummyTodos = await _dbContext.Todos.ToListAsync();

            return Ok(dummyTodos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            try
            {
                await _dbContext.Todos.AddAsync(todo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating todo");
                return BadRequest();
            }

            return Ok(todo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody] Todo todo)
        {
            try
            {
                _dbContext.Todos.Update(todo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating todo");
                return BadRequest();
            }

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            try
            {
                _dbContext.Todos.Remove(todo);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting todo");
                return BadRequest();
            }

            return Ok();
        }
    }
}
