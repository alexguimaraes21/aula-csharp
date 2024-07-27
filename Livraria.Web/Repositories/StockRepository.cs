

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class StockRepository : IStockRepository
    {
        private readonly DatabaseContext _databaseContext;
        public StockRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(Stock model)
        {
            _databaseContext.Stocks.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Stock? model = this.FindById(id);
            if (model != null) {
                _databaseContext.Stocks.Remove(model);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Stock model)
        {
            _databaseContext.Stocks.Remove(model);
            _databaseContext.SaveChanges();
        }

        public ICollection<Stock> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.Stocks
                .OrderBy(g => g.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Stock? FindById(long id)
        {
            return _databaseContext.Stocks.Find(id);
        }

        public void Update(Stock model)
        {
            _databaseContext.Stocks.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}