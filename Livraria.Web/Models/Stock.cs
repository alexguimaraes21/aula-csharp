namespace Livraria.Web.Models
{
    public class Stock
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public Book? Book { get; set; }
        public int Qty { get; set; }
    }
}
