

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class SaleBookRepository : ISaleBookRepository
    {
        private readonly DatabaseContext _databaseContext;
        public SaleBookRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(SaleBook model)
        {
            _databaseContext.SaleBooks.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            SaleBook? model = this.FindById(id);
            if (model != null) {
                _databaseContext.SaleBooks.Remove(model);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(SaleBook model)
        {
            _databaseContext.SaleBooks.Remove(model);
            _databaseContext.SaveChanges();
        }

        public ICollection<SaleBook> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.SaleBooks
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public SaleBook? FindById(long id)
        {
            return _databaseContext.SaleBooks.Find(id);
        }

        public void Update(SaleBook model)
        {
            _databaseContext.SaleBooks.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}