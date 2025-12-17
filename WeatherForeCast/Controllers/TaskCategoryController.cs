using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoTaskApi.Context;
using TodoTaskApi.DTO;
using TodoTaskApi.Models;

namespace TodoTaskApi.Controllers
{
   
    public class TaskCategoryController : BaseController
    {
        private readonly ApplicationDbContext _db;
        public TaskCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<TaskCategory>> Get()
        {
            var cats = _db.taskCategories.ToList();
            if (cats.Count() > 0)
            {
                return Ok(cats);
            }
            return Ok("No Data Found");
        }


        [HttpGet("int:id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CatWithoutList> GetById(int id)
        { 
            if(id <= 0 )
            {
                return BadRequest();
            }
            
            var cat = _db.taskCategories.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return NotFound();
              }
            var catwithout = new CatWithoutList()
            {
                Id = cat.Id,
                Name = cat.Name,
            };
            //return Ok(cat);
           
            return Ok(catwithout);
        }
        [HttpPost]
        public ActionResult<TaskCategory> post(TaskCategory obj)
         {
            if (ModelState.IsValid)
            {
                _db.taskCategories.Add(obj);
                _db.SaveChanges();
                return Ok(obj);
            }
            return BadRequest();
        }

    }
}
