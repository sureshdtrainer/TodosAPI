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

        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo todo)
        {
            int newId = TodosRespository.Todos.LastOrDefault().Id + 1;
            todo.Id = newId;
            TodosRespository.Todos.Add(todo);
            return Ok(todo);
        }
    }
}
