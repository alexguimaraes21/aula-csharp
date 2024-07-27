

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _databaseContext;
        public BookRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(Book model)
        {
            _databaseContext.Books.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Book? model = this.FindById(id);
            if (model != null) {
                _databaseContext.Books.Remove(model);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Book model)
        {
            _databaseContext.Books.Remove(model);
            _databaseContext.SaveChanges();
        }

        public ICollection<Book> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.Books
                .OrderBy(g => g.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Book? FindById(long id)
        {
            return _databaseContext.Books.Find(id);
        }

        public void Update(Book model)
        {
            _databaseContext.Books.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}