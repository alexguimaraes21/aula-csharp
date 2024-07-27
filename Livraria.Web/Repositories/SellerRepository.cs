

using Livraria.Web.Context;
using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Repositories 
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DatabaseContext _databaseContext;
        public SellerRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public void Add(Seller model)
        {
            _databaseContext.Sellers.Add(model);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Seller? model = this.FindById(id);
            if (model != null) {
                _databaseContext.Sellers.Remove(model);
                _databaseContext.SaveChanges();
            }
        }

        public void Delete(Seller model)
        {
            _databaseContext.Sellers.Remove(model);
            _databaseContext.SaveChanges();
        }

        public ICollection<Seller> FindAll(int page = 1, int size = 10)
        {
            return _databaseContext.Sellers
                .OrderBy(g => g.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public Seller? FindById(long id)
        {
            return _databaseContext.Sellers.Find(id);
        }

        public void Update(Seller model)
        {
            _databaseContext.Sellers.Update(model);
            _databaseContext.SaveChanges();
        }
    }
}