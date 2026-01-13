using KAshop.BLL.Services;
using KAshop.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KAshop.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController (ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAllCategories());
        }

        [HttpGet("id")]
        public IActionResult GetbyId([FromRoute]int id)
        {
            var category = categoryService.GetCategoryByid(id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            categoryService.CreateCategory(request);
            return Ok(request);
        }

        [HttpPatch]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var Updated = categoryService.UpdateCategory(request , id);
            return Updated>0 ? Ok(Updated) : NotFound();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatusUpdate([FromRoute] int id)
        {
            var Updated = categoryService.ToggleStatus( id);
            return Ok();
        }

        [HttpDelete("")]
        public IActionResult Delete(int id) { 
         var deleted = categoryService.DeleteCategory(id);
          return deleted > 0? Ok():NotFound();
        }
    }
}
