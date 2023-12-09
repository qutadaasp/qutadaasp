using Contact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ContactDBcontext dbcontext;

        public RegistrationController(ContactDBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> regist(dto dt)
        {
            var regst = new register()
            {

                email = dt.email,
                password = dt.password,
                name = dt.name
            };
            dbcontext.AddAsync(regst);
            dbcontext.SaveChanges();
            return Ok("done");
        }
    }
}
