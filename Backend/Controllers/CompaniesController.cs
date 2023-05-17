using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend;
using Backend.Data;
using Backend.Dtos.Company;
using AutoMapper;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly BackendDbContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(BackendDbContext context,IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
            
            var companies= await _context.Companies.ToListAsync();
            var record = _mapper.Map<List<GetCompanyDto>>(companies);
            return Ok(record);
        }
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<SearchCompanyDto>>> GetSearch()
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
           // var record = mapper.Map<GetCompanyDto>(Company);
            var record= await _context.Companies.Include(e => e.Models).ToListAsync();
            var mapping = _mapper.Map<List<SearchCompanyDto>>(record);
            return mapping;
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompanyDetailsDto>> GetCompany(int id)
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
          var company = await _context.Companies.Include(e=>e.Models).Where(e=>e.Id==id).FirstOrDefaultAsync();

            if (company == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetCompanyDetailsDto>(company);
            return Ok(record);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, UpdateCompanyDto company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }
            var mapping = _mapper.Map<Company>(company);

            _context.Entry(mapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CreateCompanyDto company)
        {
          if (_context.Companies == null)
          {
              return Problem("Entity set 'BackendDbContext.Companies'  is null.");
          }
            var company1 = _mapper.Map<Company>(company);
            _context.Companies.Add(company1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

