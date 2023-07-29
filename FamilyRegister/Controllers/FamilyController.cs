using Data.AppDBContext;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyRegister.Controllers
{
    [ApiController]
    [Route("api/family")]
    public class FamilyController : Controller
    {
        private readonly FamilyRegisterDbContext _db;
        public FamilyController(FamilyRegisterDbContext db)
        {
            _db = db;
        }


        [HttpGet("read")]
        public async Task<IActionResult> Read()
        {
            try
            {
                return Ok(await _db.Families.ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("id")]
        public async Task<IActionResult> ReadById(int Id)
        {
            try
            {
                return Ok(await _db.Families.FirstOrDefaultAsync(x => x.Id == Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {

                var model = await _db.Families.FirstOrDefaultAsync(x => x.Id == Id);
                _db.Families.Remove(model); 
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Family model)
        {
            try
            {
                await _db.Families.AddAsync(model);

                await _db.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
