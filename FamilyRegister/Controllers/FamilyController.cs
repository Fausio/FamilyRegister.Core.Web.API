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
                return Ok(await _db.Families.OrderByDescending(x => x.Id).ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ReadById([FromRoute] int id)
        {
            try
            {
                return Ok(await _db.Families.FirstOrDefaultAsync(x => x.Id == id));
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Family model)
        {
            try
            {
                _db.Families.Update(model);

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
