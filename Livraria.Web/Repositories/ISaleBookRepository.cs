using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface ISaleBookRepository
    {
        ICollection<SaleBook> FindAll(int page = 1, int size = 10);
        SaleBook? FindById(long id);
        void Add(SaleBook model);
        void Update(SaleBook model);
        void Delete(long id);
        void Delete(SaleBook model);
    }
}