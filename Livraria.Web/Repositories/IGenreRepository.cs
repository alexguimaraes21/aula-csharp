
using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface IGenreRepository 
    {
        ICollection<Genre> FindAll(int page = 1, int size = 10);
        Genre? FindById(long id);
        void Add(Genre model);
        void Update(Genre model);
        void Delete(long id);
        void Delete(Genre genre);
    }
}