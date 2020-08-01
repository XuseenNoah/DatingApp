using Microsoft.AspNetCore.Mvc;
using DatingApp.api.Data;
using System.Threading.Tasks;
using DatingApp.api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Value>> get()
        {
            return await _context.Values.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            var getValue = await _context.Values.FirstOrDefaultAsync(values => values.Id == id);
            return Ok(getValue);
        }


    }
}
