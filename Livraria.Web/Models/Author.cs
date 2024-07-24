namespace Livraria.Web.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
