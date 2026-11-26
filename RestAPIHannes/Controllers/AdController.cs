using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIHannes.Data;
using RestAPIHannes.Models;

namespace RestAPIHannes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AdController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<Advert>>> GetAll()
        {
            return Ok(await _dbContext.Ads.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Advert>> Get(int id)
        {
            var hero = await _dbContext.Ads.FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }


      
    }
}
