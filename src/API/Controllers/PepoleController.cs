using API.Data;
using API.Data.Models.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PepoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PepoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPepole()
        {
            var pepole = await _context.Pepole!
                .Include(x => x.Address)
                .ToListAsync();

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(pepole, options);

            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> AddPepole(int numberOfPepole)
        {
            IEnumerable<Person> pepoles = SeedData.GenerateSeedData(numberOfPepole);

            await _context.AddRangeAsync(pepoles);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
