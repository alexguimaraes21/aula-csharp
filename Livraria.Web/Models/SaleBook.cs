namespace Livraria.Web.Models
{
    public class SaleBook
    {
        public long BookId { get; set; }
        public Book Book { get; set; }
        public long SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
