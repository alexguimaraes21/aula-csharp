namespace Livraria.Web.Models
{
    public class Seller
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SellerCode { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
