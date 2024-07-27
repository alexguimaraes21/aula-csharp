using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface ISaleRepository
    {
        ICollection<Sale> FindAll(int page = 1, int size = 10);
        Sale? FindById(long id);
        void Add(Sale model);
        void Update(Sale model);
        void Delete(long id);
        void Delete(Sale model);
    }
}