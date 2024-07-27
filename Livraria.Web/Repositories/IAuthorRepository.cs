using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface IAuthorRepository
    {
        ICollection<Author> FindAll(int page = 1, int size = 10);
        Author? FindById(long id);
        void Add(Author model);
        void Update(Author model);
        void Delete(long id);
        void Delete(Author model);
    }
}