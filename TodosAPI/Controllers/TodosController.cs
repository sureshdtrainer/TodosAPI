using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodosAPI.Models;
using TodosAPI.Repositories;

namespace TodosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public List<Todo> GetAllTodos()
        {
            return TodosRespository.Todos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Todo> GetTodoById(int id)
        {
            if (id <= 0)
                return BadRequest();
        Todo todo = TodosRespository.Todos.Where(x => x.Id == id).FirstOrDefault();
            if (todo == null)
                return NotFound($"The todos with {id} not found");
            return Ok(todo);
        }

        [HttpGet("{title}")]
        public ActionResult<Todo> GetTodoByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return BadRequest();
            Todo todo = TodosRespository.Todos.FirstOrDefault(x => x.Title == title);
            if (todo == null)
                return NotFound($"The todos with {title} not found");
            return Ok(todo);
        }

        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo todo)
        {
            int newId = TodosRespository.Todos.LastOrDefault().Id + 1;
            todo.Id = newId;
            TodosRespository.Todos.Add(todo);
            return Ok(todo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteTodoById(int id)
        {
            if (id <= 0)
                return BadRequest();
            Todo todo = TodosRespository.Todos.Where(x => x.Id == id).FirstOrDefault();
            if (todo == null)
                return NotFound($"The todos with {id} not found");
            return Ok(TodosRespository.Todos.Remove(todo));
        }
    }
}
