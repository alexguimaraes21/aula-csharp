

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext _databaseContext;
        public AuthorRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(Author model)
        {
            _databaseContext.Authors.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Author? model = this.FindById(id);
            if (model != null) {
                _databaseContext.Authors.Remove(model);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Author model)
        {
            _databaseContext.Authors.Remove(model);
            _databaseContext.SaveChanges();
        }

        public ICollection<Author> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.Authors
                .OrderBy(g => g.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Author? FindById(long id)
        {
            return _databaseContext.Authors.Find(id);
        }

        public void Update(Author model)
        {
            _databaseContext.Authors.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}