

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DatabaseContext _databaseContext;
        public SaleRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(Sale model)
        {
            _databaseContext.Sales.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Sale? model = this.FindById(id);
            if (model != null) {
                _databaseContext.Sales.Remove(model);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Sale model)
        {
            _databaseContext.Sales.Remove(model);
            _databaseContext.SaveChanges();
        }

        public ICollection<Sale> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.Sales
                .OrderBy(g => g.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Sale? FindById(long id)
        {
            return _databaseContext.Sales.Find(id);
        }

        public void Update(Sale model)
        {
            _databaseContext.Sales.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}