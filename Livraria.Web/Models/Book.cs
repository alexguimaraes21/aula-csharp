namespace Livraria.Web.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Publisher { get; set; }
        public int Isbn { get; set; }
        public int TotalPages { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Summary { get; set; }
        public double Price { get; set; }
        public long AuthorId { get; set; }
        public Author? Author { get; set; }
        public long GenreId { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<SaleBook> SaleBooks { get; set; }
    }
}
