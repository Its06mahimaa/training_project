using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trainingproject.Models;

namespace trainingproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Roles2Controller : ControllerBase
    {
        private readonly BooksContext _context;

        public Roles2Controller(BooksContext context)
        {
            _context = context;
        }

        // GET: api/Roles2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Roles2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

      
    }
}