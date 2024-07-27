using Livraria.Web.Models;

namespace Livraria.Web.Repositories 
{
    public interface ISellerRepository
    {
        ICollection<Seller> FindAll(int page = 1, int size = 10);
        Seller? FindById(long id);
        void Add(Seller model);
        void Update(Seller model);
        void Delete(long id);
        void Delete(Seller model);
    }
}