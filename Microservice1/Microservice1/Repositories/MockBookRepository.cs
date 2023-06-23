using Microservice1.Models;

namespace Microservice1.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        public Task<Book> AddBook(Book book)
        {
            // Logic to add book
            return Task.FromResult(book);
        }
    }

}
