using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    //Api
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AplicationContext _context;

        public BookController(AplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getBooks()
        {
            try
            {
                var listBooks = await _context.book.ToListAsync();
                return Ok(listBooks);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getBookId(int id)
        {
            try
            {
                var Book = await _context.book.FindAsync(id);
                return Ok(Book);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Books book) 
        {
            try
            {
                _context.book.Add(book);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El libro se agrego con exito!!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Books book)
        {
            try
            {
                if (id != book.BookId)
                {
                    return NotFound();
                }

                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "Libro editado con exito!!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var libro = await _context.book.FindAsync(id);
                if (libro == null)
                {
                    return NotFound();
                }

                _context.book.Remove(libro);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Libro eliminado con exito!!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
