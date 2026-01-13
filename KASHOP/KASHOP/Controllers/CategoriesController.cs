using KASHOP.Data;
using KASHOP.DTO.requests;
using KASHOP.DTO.Response;
using KASHOP.Models;
using KASHOP.Models.Categoy;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KASHOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApplicationDBContext context = new ApplicationDBContext();

        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategoriesController(IStringLocalizer<SharedResource>  localizer)
        {
            _localizer=localizer;
        }

        [HttpGet("")]
        public IActionResult GetAll([FromQuery]string lang = "en") {
            
            var cats = context.categories.Include(c => c.CategoryTranslations).Where(c => c.status==Status.Active).ToList().Adapt<List<CategoriesResponseDTO>>();

            var result = cats.Select(
                cat => new
                {
                    Id = cat.Id,
                    name = cat.CategoriesTranslation.FirstOrDefault(t=>t.Language== lang).Name
                }
               
                
                );
            
            return Ok(new { message =_localizer["success"].Value, result });
        }
        [HttpPost("")]
        public IActionResult create([FromBody]CategoryRequestDTO request)
        {
            var catsInDB = request.Adapt<Category>();
            context.Add(catsInDB);
            context.SaveChanges();
            return Ok(new { message =_localizer["success"].Value});
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var cats = context.categories.Find(id);
            if (cats is null)
            {
                return NotFound(new { message = _localizer["Not Found"].Value });
            }
            return Ok(cats.Adapt<CategoriesResponseDTO>());
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]CategoryRequestDTO request)
        {
            var cats = context.categories.Find(id);
            if(cats is null){
                    return NotFound(new { message = _localizer["Not Found"].Value });
                }
            //cats.Name = request.Name;
                context.SaveChanges();

            return Ok();
        }

        [HttpPatch("{id}/toggle=status")]

        public IActionResult Togglestatus([FromRoute]int id)
        {
            var cats =context.categories.Find(id);
            if(cats is null)
            {
                return NotFound(new { message = _localizer["Not Found"].Value });
            }
            cats.status = cats.status == Status.Active ? Status.In_Active : Status.Active;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            var cats = context.categories.Find(id);
            if(cats is null)
            {
                return NotFound(new { message = _localizer["Not Found"].Value, id });
            }

            context.Remove(cats);
            context.SaveChanges();
            return Ok(new { cats, message =_localizer["success"].Value });
        }

        [HttpDelete("delete-all")]
        public IActionResult Delete()
        {
            var cats = context.categories.ToList();
            if (!cats.Any())
            {
                return NotFound(new { message = _localizer["Not Found"].Value });
            }
            context.RemoveRange(cats);
            context.SaveChanges();
            return Ok(new { message =_localizer["success"].Value });
        }
    }
}
