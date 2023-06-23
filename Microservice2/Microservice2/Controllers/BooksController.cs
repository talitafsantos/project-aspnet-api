using Microservice2.Models;
using Microservice2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;

        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await repository.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            // Process the book here
            // ...

            var bookDto = new BookDto { Id = book.Id, Title = book.Title };

            return Ok(bookDto);
        }
    }

}
