using Microservice1.Models;

namespace Microservice1.Repositories
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);
    }

}
