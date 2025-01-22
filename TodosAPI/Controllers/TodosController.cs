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
    }
}
