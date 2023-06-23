using Microservice1.Models;
using Microservice1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Microservice1.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            var addedBook = await repository.AddBook(book);
            return Ok(addedBook);
        }
    }

}
