using BookStoreApp.Data;
using BookStoreApp.Model;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var records = await _bookRepository.GetAllBooks();
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var record = await _bookRepository.GetBookByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            var records = await _bookRepository.AddBookAsync(bookModel);
            if (records == null)
            {
                return NotFound();
            }
            return Accepted(records);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id,[FromBody] BookModel bookModel)
        {
           var records = await _bookRepository.UpdateBookById(id,bookModel);
            return Ok(records);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            var record =await _bookRepository.DeleteBookAsync(id);
            if(record==null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}
