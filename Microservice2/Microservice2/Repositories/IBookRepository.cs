using Microservice2.Models;

namespace Microservice2.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBook(int id);
        // ...
    }

}
