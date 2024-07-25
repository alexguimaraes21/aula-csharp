

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext _databaseContext;
        public GenreRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(Genre model)
        {
            _databaseContext.Genres.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Genre genre = this.FindById(id);
            if (genre != null) {
                _databaseContext.Genres.Remove(genre);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Genre genre)
        {
            _databaseContext.Genres.Remove(genre);
            _databaseContext.SaveChanges();
        }

        public ICollection<Genre> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.Genres
                .OrderBy(g => g.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Genre? FindById(long id)
        {
            return _databaseContext.Genres.Find(id);
        }

        public void Update(Genre model)
        {
            _databaseContext.Genres.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}