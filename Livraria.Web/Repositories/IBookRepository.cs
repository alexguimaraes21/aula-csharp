using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface IBookRepository
    {
        ICollection<Book> FindAll(int page = 1, int size = 10);
        Book? FindById(long id);
        void Add(Book model);
        void Update(Book model);
        void Delete(long id);
        void Delete(Book model);
    }
}