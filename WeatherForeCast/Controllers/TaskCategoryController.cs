using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoTaskApi.Context;
using TodoTaskApi.Models;

namespace TodoTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public TaskCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TaskCategory> Get()
        {
            var cats = _db.taskCategories.ToList();
            if (cats.Count() > 0)
            {
                return Ok(cats);
            }
            return Ok("No Data Found");
        }

        [HttpPost]
        public ActionResult<TaskCategory> post(TaskCategory obj)
         {
            if (ModelState.IsValid){
                _db.taskCategories.Add(obj);
                _db.SaveChanges();
                return Ok(obj);

            }
          }

    }
}
