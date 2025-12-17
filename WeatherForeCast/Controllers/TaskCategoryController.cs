using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async  Task<ActionResult<List<TaskCategory>>> Get()
        {
            var cats = await _db.taskCategories.ToListAsync();
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
        public async Task<ActionResult<CatWithoutList>> GetById(int id)
        { 
            if(id <= 0 )
            {
                return BadRequest();
            }
            
            var cat = await _db.taskCategories.FirstOrDefaultAsync(c => c.Id == id);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TaskCategory>> post(TaskCategory obj)
         {
            if (ModelState.IsValid)
            {
                await _db.taskCategories.AddAsync(obj);
                await _db.SaveChangesAsync();
                return Ok(obj);
            }
            return BadRequest();
        }
        [HttpPut("int:id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]

        public async Task<ActionResult<TaskCategory>> Update(int id ,  CatWithoutList cat)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var cate =  await _db.taskCategories.FirstOrDefaultAsync(w => w.Id == id); 
            if(cate is null)
            {
                return NotFound();
            }
            cate.Name= cat.Name;
             _db.taskCategories.Update(cate);
            await _db.SaveChangesAsync();
            return Ok(cate);
        }


        [HttpDelete("int:id")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id) {

            if (id <= 0)
            {
                return BadRequest();
            }
            var cate =  _db.taskCategories.FirstOrDefault(w => w.Id == id);
            if (cate is null)
            {
                return NotFound();
            }
            _db.taskCategories.Remove(cate);
            _db.SaveChanges();
            return Ok();

        }
    }
}
