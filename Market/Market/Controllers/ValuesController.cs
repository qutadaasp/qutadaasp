using Market.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MarketDBcontext contx;

        public ValuesController(MarketDBcontext contx)
        {
            this.contx = contx;
        }

        [HttpGet]
        public async Task<IActionResult> show()
        {
            var genres = await contx.Computermarket.OrderBy(e => e.price).ToListAsync();
            return Ok();
        }
        [HttpPut]
        
        public async Task<IActionResult> update([FromBody]marketdto dto)
        {
            var genres = await contx.Computermarket.AnyAsync(e =>e.Id == dto.Id);
            if (!genres)
            {
                
                return BadRequest("wrong id");
            }
            var dat = new MarketComputer
            {
                Id = dto.Id,
                Name = dto.Name,
                price = dto.price,
                numberofComputers = dto.numberofComputers
            };
            contx.AddAsync(dat);
            contx.SaveChanges();
            return Ok(dat);
        }
    }
}
