using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIHannes.Data;
using RestAPIHannes.Models;

namespace RestAPIHannes.Controllers
{
    [Route("Ads")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AdController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAll()
        {
            return Ok(await _dbContext.Ads.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ad>> Get(int id)
        {
            var ad = await _dbContext.Ads.FirstOrDefaultAsync(h => h.Id == id);
            if (ad == null)
            {
                return NotFound();
            }
            return Ok(ad);
        }

        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(NewAd newAd)
        {
            Ad ad = new Ad
            {
                Title = newAd.Title,
                Description = newAd.Description,
                Price = newAd.Price,
                Category = newAd.Category,
                CreatedAt = newAd.CreatedAt,
                IsActive = newAd.IsActive,
                SellerName = newAd.SellerName,
                SellerEmail = newAd.SellerEmail

            };
            _dbContext.Ads.Add(ad);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ad.Id }, ad);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Ad>> UpdateAd(int id, UpdateAd updateAd)
        {
            var adToUpdate = await _dbContext.Ads.FirstOrDefaultAsync(s => s.Id == id);

            if (adToUpdate == null) { return NotFound(); }
            adToUpdate.Title = updateAd.Title;
            adToUpdate.Description = updateAd.Description;
            adToUpdate.Price= updateAd.Price;
            adToUpdate.Category = updateAd.Category;
            adToUpdate.CreatedAt = updateAd.CreatedAt;
            adToUpdate.IsActive = updateAd.IsActive;
            adToUpdate.SellerName = updateAd.SellerName;
            adToUpdate.SellerEmail = updateAd.SellerEmail;

            await _dbContext.SaveChangesAsync();
            return Ok(adToUpdate);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var adToDelete = await _dbContext.Ads.FirstOrDefaultAsync(h => h.Id == id);
            if (adToDelete == null) { return NotFound(); }
            _dbContext.Ads.Remove(adToDelete);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }



        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Ad>>
    PatchAd(JsonPatchDocument<Ad> ad, int id)
        {
            var AdToPatch = await
                _dbContext.Ads.FindAsync(id);

            if (AdToPatch == null)
            {
                return NotFound("Ad not found");
            }

            if (ad.Operations.Any(o =>
      string.Equals(o.path?.Trim('/'), "id", StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest("Id cannot be changed.");
            }


            ad.ApplyTo(AdToPatch, error =>
            {
                ModelState.AddModelError(
                    string.Empty,
                    error.ErrorMessage
                );
            });

            AdToPatch.Id = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(AdToPatch))
            {
                return BadRequest(ModelState);
            }

          


            await _dbContext.SaveChangesAsync();

            return Ok(AdToPatch);
        }
    }
}
