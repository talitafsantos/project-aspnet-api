using Microservice2.Models;

namespace Microservice2.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        public Task<Book> GetBook(int id)
        {
            // Logic to get book
            return Task.FromResult(new Book { Id = id, Title = "Book Title", Author = "Book Author" });
        }

        // ...
    }
}
