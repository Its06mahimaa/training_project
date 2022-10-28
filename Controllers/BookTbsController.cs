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
    public class BookTbsController : ControllerBase
    {
        private readonly BooksContext _context;

        public BookTbsController(BooksContext context)
        {
            _context = context;
        }

        // GET: api/BookTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTb>>> GetBookTbs()
        {
            return await _context.BookTbs.ToListAsync();
        }

      
    

        // POST: api/BookTbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookTb>> PostBookTb(BookTb bookTb)
        {
            _context.BookTbs.Add(bookTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookTbExists(bookTb.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookTb", new { id = bookTb.BookId }, bookTb);
        }

        // DELETE: api/BookTbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookTb(int id)
        {
            var bookTb = await _context.BookTbs.FindAsync(id);
            if (bookTb == null)
            {
                return NotFound();
            }

            _context.BookTbs.Remove(bookTb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookTbExists(int id)
        {
            return _context.BookTbs.Any(e => e.BookId == id);
        }
    }
}
