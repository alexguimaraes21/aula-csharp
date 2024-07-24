namespace Livraria.Web.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public double SaleTotal { get; set; }
        public long SellerId { get; set; }
        public Seller Seller { get; set; }
        public ICollection<SaleBook> SaleBooks { get; set; }
    }
}
