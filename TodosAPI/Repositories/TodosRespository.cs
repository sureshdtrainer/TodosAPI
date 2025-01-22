using TodosAPI.Models;

namespace TodosAPI.Repositories
{
    public class TodosRespository
    {
        public static List<Todo> Todos = new List<Todo>()
        {
            new Todo{ Id=1, Title="Learn Web API", Status=false},
            new Todo{ Id=2, Title="Learn SDLC API", Status=true},
            new Todo{ Id=3, Title="Learn C#", Status=true}
        };
    }
}
