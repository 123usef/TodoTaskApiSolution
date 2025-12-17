using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoTaskApi.Context;
using TodoTaskApi.Models;

namespace TodoTaskApi.Controllers
{
   
    public class TodoTaskController : BaseController
    {
        private readonly ApplicationDbContext _db;
        public TodoTaskController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TodoTask> Get()
        {
            var todo = _db.todoTasks.ToList();
            if(todo.Count() > 0)
            {
                return Ok(todo);
            }
            return Ok("No Data Found");
        }
    }
}
