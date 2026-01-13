using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DAL.Data;
using ProjectDAL.Models;
namespace Projectaccessla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        Category category = new Category();

        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
    }
}
