using BooksApp.dto;
using BooksApp.Model;
using BooksApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _bookService;
        private readonly ILogger _logger;
        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            _bookService = new BookService();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_bookService.GetAllBooks());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("SearchBook/")]
        public IActionResult Get([FromBody] SearchBook search)
        {
            try
            {
                var book = _bookService.SearchBook(search);

                if (book is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                validateProperties(book);
                _bookService.CreateBook(book);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private void validateProperties(Book book)
        {
            if (book == null)
            {
                throw new Exception("Book cannot be null");
            }
            else if (string.IsNullOrEmpty(book.Title))
            {
                throw new Exception("Book title is required");
            }
            else if (string.IsNullOrEmpty(book.Author))
            {
                throw new Exception("Book author is required");
            }
            else if (book.Year <1 || book.Year > 9999)
            {
                throw new Exception("A valid book year is required");
            }
        }

    }
}
