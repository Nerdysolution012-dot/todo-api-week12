using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoDbContext _context;
        public TodosController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoResponseDto>>> GetTodos()
        {
            var todos = await _context.TodoItems.ToListAsync();

            var response = todos.Select(t => new TodoResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate,
                Priority = t.Priority
            });

            return Ok(response);
        }


        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<TodoResponseDto>> GetTodo(int id)
        //        {
        //            var todo = await _context.TodoItems.FindAsync(id);

        //            if (todo == null)
        //            {
        //                return NotFound(new ErrorResponse
        //                {
        //                    StatusCode = 404,
        //                    Message = $"TODO with ID {id} not found",
        //                    Timestamp = DateTime.UtcNow
        //                });
        //            }

        //            var response = new TodoResponseDto
        //            {
        //                Id = todo.Id,
        //                Title = todo.Title,
        //                Description = todo.Description,
        //                IsCompleted = todo.IsCompleted,
        //                CreatedAt = todo.CreatedAt,
        //                DueDate = todo.DueDate,
        //                Priority = todo.Priority
        //            };

        //            return Ok(response);
        //        }

        //        [HttpPost]
        //public async Task<ActionResult<TodoResponseDto>> CreateTodo(CreateTodoDto dto)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }

        //            var todo = new TodoItem
        //            {
        //                Title = dto.Title,
        //                Description = dto.Description,
        //                DueDate = dto.DueDate,
        //                Priority = dto.Priority ?? "Medium",
        //                CreatedAt = DateTime.UtcNow,
        //                IsCompleted = false
        //            };

        //            _context.TodoItems.Add(todo);
        //            await _context.SaveChangesAsync();

        //            var response = new TodoResponseDto
        //            {
        //                Id = todo.Id,
        //                Title = todo.Title,
        //                Description = todo.Description,
        //                IsCompleted = todo.IsCompleted,
        //                CreatedAt = todo.CreatedAt,
        //                DueDate = todo.DueDate,
        //                Priority = todo.Priority
        //            };

        //            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, response);
        //        }

        //        [HttpPut("{id}")]
        //        public async Task<ActionResult<TodoResponseDto>> UpdateTodo(int id, UpdateTodoDto dto)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }

        //            var todo = await _context.TodoItems.FindAsync(id);

        //            if (todo == null)
        //            {
        //                return NotFound(new ErrorResponse
        //                {
        //                    StatusCode = 404,
        //                    Message = $"TODO with ID {id} not found",
        //                    Timestamp = DateTime.UtcNow
        //                });
        //            }

        //            todo.Title = dto.Title;
        //            todo.Description = dto.Description;
        //            todo.IsCompleted = dto.IsCompleted;
        //            todo.DueDate = dto.DueDate;
        //            todo.Priority = dto.Priority ?? "Medium";

        //            await _context.SaveChangesAsync();

        //            var response = new TodoResponseDto
        //            {
        //                Id = todo.Id,
        //                Title = todo.Title,
        //                Description = todo.Description,
        //                IsCompleted = todo.IsCompleted,
        //                CreatedAt = todo.CreatedAt,
        //                DueDate = todo.DueDate,
        //                Priority = todo.Priority
        //            };

        //            return Ok(response);
        //        }

        //        [HttpDelete("{id}")]
        //        public async Task<ActionResult> DeleteTodo(int id)
        //        {
        //            var todo = await _context.TodoItems.FindAsync(id);

        //            if (todo == null)
        //            {
        //                return NotFound(new ErrorResponse
        //                {
        //                    StatusCode = 404,
        //                    Message = $"TODO with ID {id} not found",
        //                    Timestamp = DateTime.UtcNow
        //                });
        //            }

        //            _context.TodoItems.Remove(todo);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }
    }
}
