 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Backend.Data;
using Backend.Dtos.Trim;
using AutoMapper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrimsController : ControllerBase
    {
        private readonly BackendDbContext _context;
        private readonly IMapper _mapper;

        public TrimsController(BackendDbContext context,IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Trims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTrimDto>>> GetTrims()
        {
          if (_context.Trims == null)
          {
              return NotFound();
          }
            var record=await _context.Trims.ToListAsync();
            var result = _mapper.Map<List<GetTrimDto>>(record);
            return Ok(result);
        }

        // GET: api/Trims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDetailsTrimDto>> GetTrim(int id)
        {
          if (_context.Trims == null)
          {
              return NotFound();
          }
            var trim = await _context.Trims.FirstOrDefaultAsync(e =>e.Id==id);

            if (trim == null)
            {
                return NotFound();
            }
            var mapping = _mapper.Map<GetDetailsTrimDto>(trim);

            return mapping;
        }

        // PUT: api/Trims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrim(int id, UpdateTrimDto trim)
        {
            if (id != trim.Id)
            {
                return BadRequest();
            }
            var mapping = _mapper.Map<Trim>(trim);
            _context.Entry(mapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrimExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trim>> PostTrim(CreateTrimDto trim)
        {
          if (_context.Trims == null)
          {
              return Problem("Entity set 'BackendDbContext.Trims'  is null.");
          }
            var mapping = _mapper.Map<Trim>(trim);
            var result= await _context.Trims.AddAsync(mapping);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Trims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrim(int id)
        {
            if (_context.Trims == null)
            {
                return NotFound();
            }
            var trim = await _context.Trims.FindAsync(id);
            if (trim == null)
            {
                return NotFound();
            }

            _context.Trims.Remove(trim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrimExists(int id)
        {
            return (_context.Trims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
