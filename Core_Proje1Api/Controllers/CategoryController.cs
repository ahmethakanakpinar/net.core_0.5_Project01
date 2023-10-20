using Core_Proje1Api.DAL.ApiConcrete;
using Core_Proje1Api.DAL.ApiEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje1Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id) 
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value == null)
                return NotFound();
            else
                return Ok(c.Categories.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("",p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category p) 
        {
            var c = new Context();
            var value = c.Categories.Find(p.CategoryID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
