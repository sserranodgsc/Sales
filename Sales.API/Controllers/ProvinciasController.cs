﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var provincia = await _context.Provincias.FirstOrDefaultAsync(p => p.Id == id);
            if (provincia is null)
            {
                return NotFound();
            }

            return Ok(provincia);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Provincia provincia)
        {
            _context.Add(provincia);
            await _context.SaveChangesAsync();
            return Ok(provincia);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Provincia provincia)
        {
            _context.Update(provincia);
            await _context.SaveChangesAsync();
            return Ok(provincia);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Provincias
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
