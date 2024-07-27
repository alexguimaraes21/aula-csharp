using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface IStockRepository
    {
        ICollection<Stock> FindAll(int page = 1, int size = 10);
        Stock? FindById(long id);
        void Add(Stock model);
        void Update(Stock model);
        void Delete(long id);
        void Delete(Stock model);
    }
}