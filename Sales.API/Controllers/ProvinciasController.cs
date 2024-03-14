using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly DataContext _context;

        public ProvinciasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Provincias.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Provincia provincia)
        {
            _context.Add(provincia);
            await _context.SaveChangesAsync();
            return Ok(provincia);
        }
    }
}
